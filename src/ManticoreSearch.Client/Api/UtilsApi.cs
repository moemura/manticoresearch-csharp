using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ManticoreSearch.Client.Api
{
    public class UtilsApi
    {
        private ApiClient apiClient;

        public UtilsApi() : this(Configuration.GetDefaultApiClient())
        {
            
        }

        public UtilsApi(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        /**
         * Get the API cilent
         *
         * @return API client
         */
        public ApiClient GetApiClient()
        {
            return apiClient;
        }

        /**
         * Set the API cilent
         *
         * @param apiClient an instance of API client
         */
        public void SetApiClient(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        /**
       * Perform SQL requests
       * Run a query in SQL format. Expects a query parameters string that can be in two modes: * Select only query as &#x60;query&#x3D;SELECT * FROM myindex&#x60;. The query string MUST be URL encoded * any type of query in format &#x60;mode&#x3D;raw&amp;query&#x3D;SHOW TABLES&#x60;. The string must be as is (no URL encoding) and &#x60;mode&#x60; must be first. The response object depends on the query executed. In select mode the response has same format as &#x60;/search&#x60; operation. 
       * @param body Expects is a query parameters string that can be in two modes:    * Select only query as &#x60;query&#x3D;SELECT * FROM myindex&#x60;. The query string MUST be URL encoded    * any type of query in format &#x60;mode&#x3D;raw&amp;query&#x3D;SHOW TABLES&#x60;. The string must be as is (no URL encoding) and &#x60;mode&#x60; must be first.  (required)
       * @return Dictionary&lt;String, Object&gt;
       * @throws ApiException if fails to make API call
       * @http.response.details
         <table summary="Response Details" border="1">
           <tr><td> Status Code </td><td> Description </td><td> Response Headers </td></tr>
           <tr><td> 200 </td><td> In case of SELECT-only in mode none the response schema is the same as of &#x60;search&#x60;. In case of &#x60;mode&#x3D;raw&#x60; the response depends on the query executed.  </td><td>  -  </td></tr>
           <tr><td> 0 </td><td> error </td><td>  -  </td></tr>
         </table>
       * 
       * @see <a href="https://docs.manticoresearch.com/latest/html/httpapi_reference.html#sql-api">Perform SQL requests Documentation</a>
       */
        public Dictionary<string, object> Sql(string body)
        {
            return SqlWithHttpInfo(body).GetData();
        }

        /**
        * Perform SQL requests
        * Run a query in SQL format. Expects a query parameters string that can be in two modes: * Select only query as &#x60;query&#x3D;SELECT * FROM myindex&#x60;. The query string MUST be URL encoded * any type of query in format &#x60;mode&#x3D;raw&amp;query&#x3D;SHOW TABLES&#x60;. The string must be as is (no URL encoding) and &#x60;mode&#x60; must be first. The response object depends on the query executed. In select mode the response has same format as &#x60;/search&#x60; operation. 
        * @param body Expects is a query parameters string that can be in two modes:    * Select only query as &#x60;query&#x3D;SELECT * FROM myindex&#x60;. The query string MUST be URL encoded    * any type of query in format &#x60;mode&#x3D;raw&amp;query&#x3D;SHOW TABLES&#x60;. The string must be as is (no URL encoding) and &#x60;mode&#x60; must be first.  (required)
        * @return ApiResponse&lt;Map&lt;String, Object&gt;&gt;
        * @throws ApiException if fails to make API call
        * @http.response.details
            <table summary="Response Details" border="1">
            <tr><td> Status Code </td><td> Description </td><td> Response Headers </td></tr>
            <tr><td> 200 </td><td> In case of SELECT-only in mode none the response schema is the same as of &#x60;search&#x60;. In case of &#x60;mode&#x3D;raw&#x60; the response depends on the query executed.  </td><td>  -  </td></tr>
            <tr><td> 0 </td><td> error </td><td>  -  </td></tr>
            </table>
        * 
        * @see <a href="https://docs.manticoresearch.com/latest/html/httpapi_reference.html#sql-api">Perform SQL requests Documentation</a>
        */
        public ApiResponse<Dictionary<string, object>> SqlWithHttpInfo(string body)
        {
            object localVarPostBody = body;

            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ApiException(400, "Missing the required parameter 'body' when calling sql");
            }

            // create path and map variables
            string localVarPath = "/sql";

            // query params
            List<Pair> localVarQueryParams = new List<Pair>();
            Dictionary<string, string> localVarHeaderParams = new Dictionary<string, string>();
            Dictionary<string, string> localVarCookieParams = new Dictionary<string, string>();
            Dictionary<string, object> localVarFormParams = new Dictionary<string, object>();

            string[] localVarAccepts = { "application/json" };
            string localVarAccept = apiClient.SelectHeaderAccept(localVarAccepts);

            string[] localVarContentTypes = { "text/plain" };
            string localVarContentType = apiClient.SelectHeaderContentType(localVarContentTypes);

            string[] localVarAuthNames = new string[] { };

            Dictionary<string, object> localVarReturnType = new Dictionary<string, object>() { };

            return apiClient.InvokeAPI("UtilsApi.sql", localVarPath, HttpMethod.Post, localVarQueryParams, localVarPostBody,
                                       localVarHeaderParams, localVarCookieParams, localVarFormParams, localVarAccept, localVarContentType,
                                       localVarAuthNames, localVarReturnType, false);
        }
    }
}