using System;
using System.Collections.Generic;
using System.Text;

namespace ManticoreSearch.Client
{
    public class ApiException : Exception
    {
        private int code = 0;
        private Dictionary<string, List<string>> responseHeaders = null;
        private string responseBody = null;

        public ApiException() { }

        public ApiException(string message): base(message)
        {
        }

        /*public ApiException(string message, Throwable throwable, int code, Dictionary<string, List<string>> responseHeaders, string responseBody)
        {
            base(message, throwable);
            this.code = code;
            this.responseHeaders = responseHeaders;
            this.responseBody = responseBody;
        }*/

        /*public ApiException(string message, int code, Dictionary<string, List<string>> responseHeaders, string responseBody)
        {
            this(message, (Throwable)null, code, responseHeaders, responseBody);
        }*/

        /*public ApiException(string message, Throwable throwable, int code, Dictionary<string, List<string>> responseHeaders)
        {
            this(message, throwable, code, responseHeaders, null);
        }*/

        /*public ApiException(int code, Dictionary<string, List<string>> responseHeaders, string responseBody)
        {
            this((string)null, (Throwable)null, code, responseHeaders, responseBody);
        }*/

        public ApiException(int code, string message) : base(message)
        {
            this.code = code;
        }

        public ApiException(int code, string message, Dictionary<string, List<string>> responseHeaders, string responseBody) : this(code, message)
        {
            this.responseHeaders = responseHeaders;
            this.responseBody = responseBody;
        }

        /**
         * Get the HTTP status code.
         *
         * @return HTTP status code
         */
        public int GetCode()
        {
            return code;
        }

        /**
         * Get the HTTP response headers.
         *
         * @return A Dictionary of list of string
         */
        public Dictionary<string, List<string>> GetResponseHeaders()
        {
            return responseHeaders;
        }

        /**
         * Get the HTTP response body.
         *
         * @return Response body in the form of string
         */
        public string GetResponseBody()
        {
            return responseBody;
        }
    }
}