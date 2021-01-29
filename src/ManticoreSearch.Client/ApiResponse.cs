using System;
using System.Collections.Generic;
using System.Text;

namespace ManticoreSearch.Client
{
    /**
    * API response returned by API call.
    *
    * @param <T> The type of data that is deserialized from response body
    */
    public class ApiResponse<T>
    {
        private readonly int statusCode;
        private readonly Dictionary<string, List<string>> headers;
        private readonly T data;

        /**
         * @param statusCode The status code of HTTP response
         * @param headers The headers of HTTP response
         */
        public ApiResponse(int statusCode, Dictionary<string, List<string>> headers)
        {
            this.statusCode = statusCode;
            this.headers = headers;
        }

        /**
         * @param statusCode The status code of HTTP response
         * @param headers The headers of HTTP response
         * @param data The object deserialized from response bod
         */
        public ApiResponse(int statusCode, Dictionary<string, List<string>> headers, T data)
        {
            this.statusCode = statusCode;
            this.headers = headers;
            this.data = data;
        }

        /**
         * Get the status code
         *
         * @return status code
         */
        public int GetStatusCode()
        {
            return statusCode;
        }

        /**
         * Get the headers
         *
         * @return Dictionary of headers
         */
        public Dictionary<string, List<string>> GetHeaders()
        {
            return headers;
        }

        /**
         * Get the data
         *
         * @return data
         */
        public T GetData()
        {
            return data;
        }
    }
}