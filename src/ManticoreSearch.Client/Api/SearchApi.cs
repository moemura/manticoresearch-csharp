using ManticoreSearch.Client.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace ManticoreSearch.Client.Api
{
    public class SearchApi
    {
        private ApiClient apiClient;

        public SearchApi() : this(Configuration.GetDefaultApiClient())
        {

        }

        public SearchApi(ApiClient apiClient)
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
         * Perform reverse search on a percolate index
         * Performs a percolate search.  This method must be used only on percolate indexes.  Expects two parameters: the index name and an object with array of documents to be tested. An example of the documents object:    &#x60;&#x60;&#x60;   {\&quot;query\&quot;:{\&quot;percolate\&quot;:{\&quot;document\&quot;:{\&quot;content\&quot;:\&quot;sample content\&quot;}}}}   &#x60;&#x60;&#x60;  Responds with an object with matched stored queries:     &#x60;&#x60;&#x60;   {&#39;timed_out&#39;:false,&#39;hits&#39;:{&#39;total&#39;:2,&#39;max_score&#39;:1,&#39;hits&#39;:[{&#39;_index&#39;:&#39;idx_pq_1&#39;,&#39;_type&#39;:&#39;doc&#39;,&#39;_id&#39;:&#39;2&#39;,&#39;_score&#39;:&#39;1&#39;,&#39;_source&#39;:{&#39;query&#39;:{&#39;match&#39;:{&#39;title&#39;:&#39;some&#39;},}}},{&#39;_index&#39;:&#39;idx_pq_1&#39;,&#39;_type&#39;:&#39;doc&#39;,&#39;_id&#39;:&#39;5&#39;,&#39;_score&#39;:&#39;1&#39;,&#39;_source&#39;:{&#39;query&#39;:{&#39;ql&#39;:&#39;some | none&#39;}}}]}}   &#x60;&#x60;&#x60; 
         * @param index Name of the percolate index (required)
         * @param percolateRequest  (required)
         * @return SearchResponse
         * @throws ApiException if fails to make API call
         * @http.response.details
           <table summary="Response Details" border="1">
             <tr><td> Status Code </td><td> Description </td><td> Response Headers </td></tr>
             <tr><td> 200 </td><td> items found </td><td>  -  </td></tr>
             <tr><td> 0 </td><td> error </td><td>  -  </td></tr>
           </table>
         * 
         * @see <a href="https://docs.manticoresearch.com/latest/html/http_reference/json_update.html">Perform reverse search on a percolate index Documentation</a>
         */
        public SearchResponse Percolate(string index, PercolateRequest percolateRequest)
        {
            return PercolateWithHttpInfo(index, percolateRequest).GetData();
        }

        /**
         * Perform reverse search on a percolate index
         * Performs a percolate search.  This method must be used only on percolate indexes.  Expects two parameters: the index name and an object with array of documents to be tested. An example of the documents object:    &#x60;&#x60;&#x60;   {\&quot;query\&quot;:{\&quot;percolate\&quot;:{\&quot;document\&quot;:{\&quot;content\&quot;:\&quot;sample content\&quot;}}}}   &#x60;&#x60;&#x60;  Responds with an object with matched stored queries:     &#x60;&#x60;&#x60;   {&#39;timed_out&#39;:false,&#39;hits&#39;:{&#39;total&#39;:2,&#39;max_score&#39;:1,&#39;hits&#39;:[{&#39;_index&#39;:&#39;idx_pq_1&#39;,&#39;_type&#39;:&#39;doc&#39;,&#39;_id&#39;:&#39;2&#39;,&#39;_score&#39;:&#39;1&#39;,&#39;_source&#39;:{&#39;query&#39;:{&#39;match&#39;:{&#39;title&#39;:&#39;some&#39;},}}},{&#39;_index&#39;:&#39;idx_pq_1&#39;,&#39;_type&#39;:&#39;doc&#39;,&#39;_id&#39;:&#39;5&#39;,&#39;_score&#39;:&#39;1&#39;,&#39;_source&#39;:{&#39;query&#39;:{&#39;ql&#39;:&#39;some | none&#39;}}}]}}   &#x60;&#x60;&#x60; 
         * @param index Name of the percolate index (required)
         * @param percolateRequest  (required)
         * @return ApiResponse&lt;SearchResponse&gt;
         * @throws ApiException if fails to make API call
         * @http.response.details
           <table summary="Response Details" border="1">
             <tr><td> Status Code </td><td> Description </td><td> Response Headers </td></tr>
             <tr><td> 200 </td><td> items found </td><td>  -  </td></tr>
             <tr><td> 0 </td><td> error </td><td>  -  </td></tr>
           </table>
         * 
         * @see <a href="https://docs.manticoresearch.com/latest/html/http_reference/json_update.html">Perform reverse search on a percolate index Documentation</a>
         */
        public ApiResponse<SearchResponse> PercolateWithHttpInfo(string index, PercolateRequest percolateRequest)
        {
            object localVarPostBody = percolateRequest;

            // verify the required parameter 'index' is set
            if (index == null)
            {
                throw new ApiException(400, "Missing the required parameter 'index' when calling percolate");
            }

            // verify the required parameter 'percolateRequest' is set
            if (percolateRequest == null)
            {
                throw new ApiException(400, "Missing the required parameter 'percolateRequest' when calling percolate");
            }

            // create path and Dictionary variables
            string localVarPath = Regex.Replace("/json/pq/{index}/search", "\\{" + "index" + "\\}", apiClient.EscapeString(index.ToString()));

            // query params
            List<Pair> localVarQueryParams = new List<Pair>();
            Dictionary<string, string> localVarHeaderParams = new Dictionary<string, string>();
            Dictionary<string, string> localVarCookieParams = new Dictionary<string, string>();
            Dictionary<string, object> localVarFormParams = new Dictionary<string, object>();

            string[] localVarAccepts = {
              "application/json"
            };
            string localVarAccept = apiClient.SelectHeaderAccept(localVarAccepts);

            string[] localVarContentTypes = {
              "application/json"
            };
            string localVarContentType = apiClient.SelectHeaderContentType(localVarContentTypes);

            string[] localVarAuthNames = new string[] { };

            SearchResponse localVarReturnType = new SearchResponse() { };

            return apiClient.InvokeAPI("SearchApi.percolate", localVarPath, HttpMethod.Post, localVarQueryParams, localVarPostBody,
                                       localVarHeaderParams, localVarCookieParams, localVarFormParams, localVarAccept, localVarContentType,
                                       localVarAuthNames, localVarReturnType, false);
        }
        /**
         * Performs a search
         *  Expects an object with mandatory properties: * the index name * the match query object Example :    &#x60;&#x60;&#x60;   {&#39;index&#39;:&#39;movies&#39;,&#39;query&#39;:{&#39;bool&#39;:{&#39;must&#39;:[{&#39;query_string&#39;:&#39; movie&#39;}]}},&#39;script_fields&#39;:{&#39;myexpr&#39;:{&#39;script&#39;:{&#39;inline&#39;:&#39;IF(rating&gt;8,1,0)&#39;}}},&#39;sort&#39;:[{&#39;myexpr&#39;:&#39;desc&#39;},{&#39;_score&#39;:&#39;desc&#39;}],&#39;profile&#39;:true}   &#x60;&#x60;&#x60;  It responds with an object with: - time of execution - if the query timed out - an array with hits (matched documents) - additional, if profiling is enabled, an array with profiling information is attached     &#x60;&#x60;&#x60;   {&#39;took&#39;:10,&#39;timed_out&#39;:false,&#39;hits&#39;:{&#39;total&#39;:2,&#39;hits&#39;:[{&#39;_id&#39;:&#39;1&#39;,&#39;_score&#39;:1,&#39;_source&#39;:{&#39;gid&#39;:11}},{&#39;_id&#39;:&#39;2&#39;,&#39;_score&#39;:1,&#39;_source&#39;:{&#39;gid&#39;:12}}]}}   &#x60;&#x60;&#x60;  For more information about the match query syntax, additional paramaters that can be set to the input and response, please check: https://docs.manticoresearch.com/latest/html/http_reference/json_search.html. 
         * @param searchRequest  (required)
         * @return SearchResponse
         * @throws ApiException if fails to make API call
         * @http.response.details
           <table summary="Response Details" border="1">
             <tr><td> Status Code </td><td> Description </td><td> Response Headers </td></tr>
             <tr><td> 200 </td><td> Ok </td><td>  -  </td></tr>
             <tr><td> 0 </td><td> error </td><td>  -  </td></tr>
           </table>
         * 
         * @see <a href="https://docs.manticoresearch.com/latest/html/http_reference/json_search.html">Performs a search Documentation</a>
         */
        public SearchResponse Search(SearchRequest searchRequest)
        {
            return SearchWithHttpInfo(searchRequest).GetData();
        }

        /**
         * Performs a search
         *  Expects an object with mandatory properties: * the index name * the match query object Example :    &#x60;&#x60;&#x60;   {&#39;index&#39;:&#39;movies&#39;,&#39;query&#39;:{&#39;bool&#39;:{&#39;must&#39;:[{&#39;query_string&#39;:&#39; movie&#39;}]}},&#39;script_fields&#39;:{&#39;myexpr&#39;:{&#39;script&#39;:{&#39;inline&#39;:&#39;IF(rating&gt;8,1,0)&#39;}}},&#39;sort&#39;:[{&#39;myexpr&#39;:&#39;desc&#39;},{&#39;_score&#39;:&#39;desc&#39;}],&#39;profile&#39;:true}   &#x60;&#x60;&#x60;  It responds with an object with: - time of execution - if the query timed out - an array with hits (matched documents) - additional, if profiling is enabled, an array with profiling information is attached     &#x60;&#x60;&#x60;   {&#39;took&#39;:10,&#39;timed_out&#39;:false,&#39;hits&#39;:{&#39;total&#39;:2,&#39;hits&#39;:[{&#39;_id&#39;:&#39;1&#39;,&#39;_score&#39;:1,&#39;_source&#39;:{&#39;gid&#39;:11}},{&#39;_id&#39;:&#39;2&#39;,&#39;_score&#39;:1,&#39;_source&#39;:{&#39;gid&#39;:12}}]}}   &#x60;&#x60;&#x60;  For more information about the match query syntax, additional paramaters that can be set to the input and response, please check: https://docs.manticoresearch.com/latest/html/http_reference/json_search.html. 
         * @param searchRequest  (required)
         * @return ApiResponse&lt;SearchResponse&gt;
         * @throws ApiException if fails to make API call
         * @http.response.details
           <table summary="Response Details" border="1">
             <tr><td> Status Code </td><td> Description </td><td> Response Headers </td></tr>
             <tr><td> 200 </td><td> Ok </td><td>  -  </td></tr>
             <tr><td> 0 </td><td> error </td><td>  -  </td></tr>
           </table>
         * 
         * @see <a href="https://docs.manticoresearch.com/latest/html/http_reference/json_search.html">Performs a search Documentation</a>
         */
        public ApiResponse<SearchResponse> SearchWithHttpInfo(SearchRequest searchRequest)
        {
            object localVarPostBody = searchRequest;

            // verify the required parameter 'searchRequest' is set
            if (searchRequest == null)
            {
                throw new ApiException(400, "Missing the required parameter 'searchRequest' when calling search");
            }

            // create path and Dictionary variables
            string localVarPath = "/json/search";

            // query params
            List<Pair> localVarQueryParams = new List<Pair>();
            Dictionary<string, string> localVarHeaderParams = new Dictionary<string, string>();
            Dictionary<string, string> localVarCookieParams = new Dictionary<string, string>();
            Dictionary<string, object> localVarFormParams = new Dictionary<string, object>();

            string[] localVarAccepts = {
                "application/json"
            };
            string localVarAccept = apiClient.SelectHeaderAccept(localVarAccepts);

            string[] localVarContentTypes = {
              "application/json"
            };
            string localVarContentType = apiClient.SelectHeaderContentType(localVarContentTypes);

            string[] localVarAuthNames = new string[] { };

            SearchResponse localVarReturnType = new SearchResponse() { };

            return apiClient.InvokeAPI("SearchApi.search", localVarPath, HttpMethod.Post, localVarQueryParams, localVarPostBody,
                                       localVarHeaderParams, localVarCookieParams, localVarFormParams, localVarAccept, localVarContentType,
                                       localVarAuthNames, localVarReturnType, false);
        }
    }
}