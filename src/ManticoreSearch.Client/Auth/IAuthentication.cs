using System;
using System.Collections.Generic;
using System.Text;

namespace ManticoreSearch.Client.Auth
{
    public interface IAuthentication
    {
        /**
         * Apply authentication settings to header and query params.
         *
         * @param queryParams List of query parameters
         * @param headerParams Dictionary of header parameters
         * @param cookieParams Dictionary of cookie parameters
         */
        void ApplyToParams(List<Pair> queryParams, Dictionary<string, string> headerParams, Dictionary<string, string> cookieParams, string payload, string method, Uri uri);

    }
}
