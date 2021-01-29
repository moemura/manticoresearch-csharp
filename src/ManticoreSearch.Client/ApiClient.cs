using ManticoreSearch.Client.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace ManticoreSearch.Client
{
    public class ApiClient
    {
        protected Dictionary<string, string> defaultHeaderDictionary = new Dictionary<string, string>();
        protected Dictionary<string, string> defaultCookieDictionary = new Dictionary<string, string>();
        protected string basePath = "http://127.0.0.1:9308";
        protected string userAgent;
        //private static readonly Logger log = //TODO

        protected List<ServerConfiguration> servers = new List<ServerConfiguration>();
        protected int serverIndex = 0;
        protected Dictionary<string, string> serverVariables = null;
        protected Dictionary<string, List<ServerConfiguration>> operationServers = new Dictionary<string, List<ServerConfiguration>>();
        protected Dictionary<string, int> operationServerIndex = new Dictionary<string, int>();
        protected Dictionary<string, Dictionary<string, string>> operationServerVariables = new Dictionary<string, Dictionary<string, string>>();
        protected bool debugging = false;
        protected int connectionTimeout = 0;
        private int readTimeout = 0;

        protected HttpClient httpClient;
        protected string json;
        protected string tempFolderPath = null;

        protected Dictionary<string, IAuthentication> authentications;
        protected Dictionary<string, string> authenticationLookup;

        public ApiClient()
        {
            Init();
        }

        public ApiClient(Dictionary<string, IAuthentication> authDictionary)
        {
            Init();
        }

        private void Init()
        {
            servers.Add(new ServerConfiguration(
                "http://127.0.0.1:9308/",
                "Default Manticore Search HTTP",
                new Dictionary<string, ServerVariable>()
            ));

            httpClient = new HttpClient();
        }

        public string BasePath
        {
            get
            {
                return basePath;
            }
            set
            {
                basePath = value;
            }
        }

        ///
        /// Format the given Date object into string.
        /// @param date Date
        /// @return Date in string format
        ///
        public string FormatDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz", DateTimeFormatInfo.InvariantInfo);
        }

        /**
       * Format the given parameter object into string.
       * @param param object
       * @return object in string format
       */
        public string ParameterToString(object param)
        {
            if (param == null)
            {
                return "";
            }
            else if (param is DateTime)
            {
                return FormatDate((DateTime)param);
            }
            else if (param.GetType().GetInterface(typeof(IEnumerable<>).FullName) != null)
            {
                StringBuilder b = new StringBuilder();
                foreach (object o in (IEnumerable<object>)param)
                {
                    if (b.Length > 0)
                    {
                        b.Append(',');
                    }
                    b.Append(Convert.ToString(o));
                }
                return b.ToString();
            }
            else
            {
                return Convert.ToString(param);
            }
        }

        /*
         * Format to {@code Pair} objects.
         * @param collectionFormat Collection format
         * @param name Name
         * @param value Value
         * @return List of pairs
         */
        public List<Pair> ParameterToPairs(string collectionFormat, string name, object value)
        {
            List<Pair> listparams = new List<Pair>();

            // preconditions
            if (name == null || string.IsNullOrEmpty(name) || value == null) return listparams;

            IEnumerable<object> valueCollection;
            if (value.GetType().GetInterface(typeof(IEnumerable<>).FullName) != null)
            {
                valueCollection = (IEnumerable<object>)value;
            }
            else
            {
                listparams.Add(new Pair(name, ParameterToString(value)));
                return listparams;
            }

            if (valueCollection.Count() == 0)
            {
                return listparams;
            }

            // get the collection format (default: csv)
            string format = (collectionFormat == null || string.IsNullOrEmpty(collectionFormat) ? "csv" : collectionFormat);

            // create the params based on the collection format
            if ("multi".Equals(format))
            {
                foreach (object item in valueCollection)
                {
                    listparams.Add(new Pair(name, ParameterToString(item)));
                }

                return listparams;
            }

            string delimiter = ",";

            if ("csv".Equals(format))
            {
                delimiter = ",";
            }
            else if ("ssv".Equals(format))
            {
                delimiter = " ";
            }
            else if ("tsv".Equals(format))
            {
                delimiter = "\t";
            }
            else if ("pipes".Equals(format))
            {
                delimiter = "|";
            }

            StringBuilder sb = new StringBuilder();
            foreach (object item in valueCollection)
            {
                sb.Append(delimiter);
                sb.Append(ParameterToString(item));
            }

            listparams.Add(new Pair(name, sb.ToString().Substring(1)));

            return listparams;
        }

        /**
        * Check if the given MIME is a JSON MIME.
        * JSON MIME examples:
        *   application/json
        *   application/json; charset=UTF8
        *   APPLICATION/JSON
        *   application/vnd.company+json
        * "* / *" is also default to JSON
        * @param mime MIME
        * @return True if the MIME type is JSON
        */
        public bool isJsonMime(string mime)
        {
            string jsonMime = "(?i)^(application/json|[^;/ \t]+/[^;/ \t]+[+]json)[ \t]*(;.*)?$";
            return mime != null && (Regex.Match(mime, jsonMime).Success || mime.Equals("*/*"));
        }

        /**
        * Select the Accept header's value from the given accepts array:
       *   if JSON exists in the given array, use it;
       *   otherwise use all of them (joining into a string)
       *
       * @param accepts The accepts array to select from
       * @return The Accept header to use. If the given array is empty,
       *   null will be returned (not to set the Accept header explicitly).
       */
        public string SelectHeaderAccept(string[] accepts)
        {
            if (accepts.Length == 0)
            {
                return null;
            }
            foreach (string accept in accepts)
            {
                if (isJsonMime(accept))
                {
                    return accept;
                }
            }
            return string.Join(",", accepts);
        }

        /**
         * Select the Content-Type header's value from the given array:
         *   if JSON exists in the given array, use it;
         *   otherwise use the first one of the array.
         *
         * @param contentTypes The Content-Type array to select from
         * @return The Content-Type header to use. If the given array is empty,
         *   JSON will be used.
         */
        public string SelectHeaderContentType(string[] contentTypes)
        {
            if (contentTypes.Length == 0)
            {
                return "application/json";
            }
            foreach (string contentType in contentTypes)
            {
                if (isJsonMime(contentType))
                {
                    return contentType;
                }
            }
            return contentTypes[0];
        }

        /**
        * Escape the given string to be used as URL query value.
        * @param str string
        * @return Escaped string
      */
        public string EscapeString(string str)
        {
            try
            {
                var result = HttpUtility.UrlEncode(str, Encoding.UTF8);
                result = Regex.Replace(result, "\\+", "%20");
                return result;
            }
            catch (Exception e)
            {
                return str;
            }
        }

        /**
       * Serialize the given Java object into string entity according the given
       * Content-Type (only JSON is supported for now).
       * @param obj object
       * @param formParams Form parameters
       * @param contentType Context type
       * @return Entity
       * @throws ApiException API exception
       */
        public string Serialize(object obj, Dictionary<string, object> formParams, string contentType, bool isBodyNullable)
        {
            string entity = "";
            if (contentType.StartsWith("multipart/form-data"))
            {
                /*MultiPart multiPart = new MultiPart();
                foreach (var param in formParams)
                {
                    if (param.Value is File) {
                        File file = (File)param.Value;
                        FormDataContentDisposition contentDisp = FormDataContentDisposition.name(param.Key)
                            .fileName(file.getName()).size(file.length()).build();
                        multiPart.bodyPart(new FormDataBodyPart(contentDisp, file, MediaType.APPLICATION_OCTET_STREAM_TYPE));
                    } else
                    {
                        FormDataContentDisposition contentDisp = FormDataContentDisposition.name(param.Key).build();
                        multiPart.bodyPart(new FormDataBodyPart(contentDisp, ParameterToString(param.Value)));
                    }
                }
                entity = Entity.entity(multiPart, MediaType.MULTIPART_FORM_DATA_TYPE);*/
            }
            else if (contentType.StartsWith("application/x-www-form-urlencoded"))
            {
                /*Form form = new Form();
                foreach (var param in formParams)
                {
                    form.param(param.Key, ParameterToString(param.Value));
                }
                entity = Entity.entity(form, MediaType.APPLICATION_FORM_URLENCODED_TYPE);*/
            }
            else
            {
                // We let jersey handle the serialization
                /*if (isBodyNullable)
                { // payload is nullable
                    if (obj is string) {
                        entity = Entity.entity(obj == null ? "null" : "\"" + ((string)obj).replaceAll("\"", Matcher.quoteReplacement("\\\"")) + "\"", contentType);
                    } else
                    {
                        entity = Entity.entity(obj == null ? "null" : obj, contentType);
                    }
                }
                else
                {
                    entity = Entity.entity(obj == null ? "" : obj, contentType);
                }*/
            }
            return entity;
        }

        /**
         * Serialize the given Java object into string according the given
         * Content-Type (only JSON, HTTP form is supported for now).
         * @param obj object
         * @param formParams Form parameters
         * @param contentType Context type
         * @param isBodyNullable True if the body is nullable
         * @return string
         * @throws ApiException API exception
         */
        public string SerializeToString(object obj, Dictionary<string, object> formParams, string contentType, bool isBodyNullable)
        {
            try
            {
                if (contentType.StartsWith("multipart/form-data"))
                {
                    throw new ApiException("multipart/form-data not yet supported for serializeToString (http signature authentication)");
                }
                else if (contentType.StartsWith("application/x-www-form-urlencoded"))
                {
                    string formString = "";
                    foreach (var param in formParams)
                    {
                        formString = param.Key + "=" + HttpUtility.UrlEncode(ParameterToString(param.Value), Encoding.UTF8) + "&";
                    }

                    if (formString.Length == 0)
                    { // empty string
                        return formString;
                    }
                    else
                    {
                        return formString.Substring(0, formString.Length - 1);
                    }
                }
                else
                {
                    if (isBodyNullable)
                    {
                        return obj == null ? "null" : JsonConvert.SerializeObject(obj);
                    }
                    else
                    {
                        return obj == null ? "" : JsonConvert.SerializeObject(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApiException("Failed to perform serializeToString: " + ex.ToString());
            }
        }

        /**
   * Invoke API by sending HTTP request with the given options.
   *
   * @param <T> Type
   * @param operation The qualified name of the operation
   * @param path The sub-path of the HTTP URL
   * @param method The request method, one of "GET", "POST", "PUT", "HEAD" and "DELETE"
   * @param queryParams The query parameters
   * @param body The request body object
   * @param headerParams The header parameters
   * @param cookieParams The cookie parameters
   * @param formParams The form parameters
   * @param accept The request's Accept header
   * @param contentType The request's Content-Type header
   * @param authNames The authentications to apply
   * @param returnType The return type into which to deserialize the response
   * @param isBodyNullable True if the body is nullable
   * @return The response body in type of string
   * @throws ApiException API exception
   */
        public ApiResponse<T> InvokeAPI<T>(
            string operation,
            string path,
            HttpMethod method,
            List<Pair> queryParams,
            object body,
            Dictionary<string, string> headerParams,
            Dictionary<string, string> cookieParams,
            Dictionary<string, object> formParams,
            string accept,
            string contentType,
            string[] authNames,
            T returnType,
            bool isBodyNullable)
        {

            // Not using `.target(targetURL).path(path)` below,
            // to support (constant) query string in `path`, e.g. "/posts?draft=1"
            string targetURL;
            if (serverIndex != -1 && operationServers.ContainsKey(operation))
            {
                int index = operationServerIndex.ContainsKey(operation) ? operationServerIndex[operation] : serverIndex;
                Dictionary<string, string> variables = operationServerVariables.ContainsKey(operation) ?
                  operationServerVariables[operation] : serverVariables;
                List<ServerConfiguration> serverConfigurations = operationServers[operation];
                if (index < 0 || index >= serverConfigurations.Count)
                {
                    throw new IndexOutOfRangeException(
                        string.Format(
                            "Invalid index %d when selecting the host settings. Must be less than %d",
                            index, serverConfigurations.Count));
                }
                targetURL = serverConfigurations[index].URL(variables) + path;
            }
            else
            {
                targetURL = this.basePath + path;
            }

            var request = new HttpRequestMessage(method, targetURL);

            if (queryParams != null)
            {
                foreach (Pair queryParam in queryParams)
                {
                    if (queryParam.GetValue() != null)
                    {
                        //TODO
                    }
                }
            }

            if (body is string)
            {
                request.Content = new StringContent(body.ToString(), Encoding.UTF8, "plain/text");
            }
            else
            {

                var jsonData = JsonConvert.SerializeObject(body, Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            }

            foreach (var entry in cookieParams)
            {
                string value = entry.Value;
                if (value != null)
                {
                    //TODO
                }
            }

            foreach (var entry in defaultCookieDictionary)
            {
                string value = entry.Value;
                if (value != null)
                {
                    //TODO
                }
            }

            // put all headers in one place
            Dictionary<string, string> allHeaderParams = new Dictionary<string, string>(defaultHeaderDictionary);

            foreach (var item in headerParams)
            {
                allHeaderParams[item.Key] = item.Value;
            }

            ///TODO auth
            // update different parameters (e.g. headers) for authentication
            /*UpdateParamsForAuth(
                authNames,
                queryParams,
                allHeaderParams,
                cookieParams,
                SerializeTostring(body, formParams, contentType, isBodyNullable),
                method,
                httpClient.BaseAddress);*/

            foreach (var entry in allHeaderParams)
            {
                string value = entry.Value;
                if (value != null)
                {
                    //TODO
                }
            }

            HttpResponseMessage response = null;

            try
            {
                response = httpClient.SendAsync(request).GetAwaiter().GetResult();

                int statusCode = (int)response.StatusCode;
                Dictionary<string, List<string>> responseHeaders = BuildResponseHeaders(response);

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new ApiResponse<T>(statusCode, responseHeaders);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    if (returnType == null)
                    {
                        return new ApiResponse<T>(statusCode, responseHeaders);
                    }
                    else
                    {
                        var obj = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                        return new ApiResponse<T>(statusCode, responseHeaders, obj);
                    }
                }
                else
                {
                    string message = "error";
                    string respBody = "";
                    if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
                    {
                        try
                        {
                            respBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        }
                        catch (Exception e)
                        {
                            // e.printStackTrace();
                        }
                    }
                    throw new ApiException((int)response.StatusCode, $"{message} : {respBody}", BuildResponseHeaders(response), respBody);
                }
            }
            finally
            {
                try
                {
                    response.Dispose();
                }
                catch (Exception e)
                {
                    // it's not critical, since the response object is local in method invokeAPI; that's fine,
                    // just continue
                }
            }
        }
        protected Dictionary<string, List<string>> BuildResponseHeaders(HttpResponseMessage response)
        {
            Dictionary<string, List<string>> responseHeaders = new Dictionary<string, List<string>>();
            foreach (var entry in response.Headers)
            {
                var values = entry.Value;
                List<string> headers = new List<string>();
                foreach (object o in values)
                {
                    headers.Add(Convert.ToString(o));
                }
                responseHeaders.Add(entry.Key, headers);
            }
            return responseHeaders;
        }

        /**
         * Update query and header parameters based on authentication settings.
         *
         * @param authNames The authentications to apply
         * @param queryParams List of query parameters
         * @param headerParams Map of header parameters
         * @param cookieParams Map of cookie parameters
         * @param method HTTP method (e.g. POST)
         * @param uri HTTP URI
         */
        protected void UpdateParamsForAuth(string[] authNames, List<Pair> queryParams, Dictionary<string, string> headerParams,
                                         Dictionary<string, string> cookieParams, string payload, string method, Uri uri)
        {
            foreach (string authName in authNames)
            {
                IAuthentication auth = authentications[authName];
                if (auth == null)
                {
                    continue;
                }
                auth.ApplyToParams(queryParams, headerParams, cookieParams, payload, method, uri);
            }
        }
    }
}