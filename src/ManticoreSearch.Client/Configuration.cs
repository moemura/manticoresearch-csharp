using System;
using System.Collections.Generic;
using System.Text;

namespace ManticoreSearch.Client
{
    class Configuration
    {
        private static ApiClient defaultApiClient = new ApiClient();

        /**
         * Get the default API client, which would be used when creating API
         * instances without providing an API client.
         *
         * @return Default API client
         */
        public static ApiClient GetDefaultApiClient()
        {
            return defaultApiClient;
        }

        /**
         * Set the default API client, which would be used when creating API
         * instances without providing an API client.
         *
         * @param apiClient API client
         */
        public static void SetDefaultApiClient(ApiClient apiClient)
        {
            defaultApiClient = apiClient;
        }
    }
}