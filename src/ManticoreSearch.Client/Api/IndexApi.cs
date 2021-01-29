﻿using ManticoreSearch.Client.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ManticoreSearch.Client.Api
{
    public class IndexApi
    {
        private ApiClient apiClient;

        public IndexApi() : this(Configuration.GetDefaultApiClient())
        {

        }

        public IndexApi(ApiClient apiClient)
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
         * Bulk index operations
         * Sends multiple operatons like inserts, updates, replaces or deletes.  For each operation it&#39;s object must have same format as in their dedicated method.  The method expects a raw string as the batch in NDJSON.  Each operation object needs to be serialized to   JSON and separated by endline (\\n).      An example of raw input:      &#x60;&#x60;&#x60;   {\&quot;insert\&quot;: {\&quot;index\&quot;: \&quot;movies\&quot;, \&quot;doc\&quot;: {\&quot;plot\&quot;: \&quot;A secret team goes to North Pole\&quot;, \&quot;rating\&quot;: 9.5, \&quot;language\&quot;: [2, 3], \&quot;title\&quot;: \&quot;This is an older movie\&quot;, \&quot;lon\&quot;: 51.99, \&quot;meta\&quot;: {\&quot;keywords\&quot;:[\&quot;travel\&quot;,\&quot;ice\&quot;],\&quot;genre\&quot;:[\&quot;adventure\&quot;]}, \&quot;year\&quot;: 1950, \&quot;lat\&quot;: 60.4, \&quot;advise\&quot;: \&quot;PG-13\&quot;}}}   \\n   {\&quot;delete\&quot;: {\&quot;index\&quot;: \&quot;movies\&quot;,\&quot;id\&quot;:700}}   &#x60;&#x60;&#x60;      Responds with an object telling whenever any errors occured and an array with status for each operation:      &#x60;&#x60;&#x60;   {&#39;items&#39;:[{&#39;update&#39;:{&#39;_index&#39;:&#39;products&#39;,&#39;_id&#39;:1,&#39;result&#39;:&#39;updated&#39;}},{&#39;update&#39;:{&#39;_index&#39;:&#39;products&#39;,&#39;_id&#39;:2,&#39;result&#39;:&#39;updated&#39;}}],&#39;errors&#39;:false}   &#x60;&#x60;&#x60;   
         * @param body  (required)
         * @return BulkResponse
         * @throws ApiException if fails to make API call
         * @http.response.details
           <table summary="Response Details" border="1">
             <tr><td> Status Code </td><td> Description </td><td> Response Headers </td></tr>
             <tr><td> 200 </td><td> item updated </td><td>  -  </td></tr>
             <tr><td> 0 </td><td> error </td><td>  -  </td></tr>
           </table>
         * 
         * @see <a href="https://docs.manticoresearch.com/latest/html/http_reference/json_update.html">Bulk index operations Documentation</a>
         */
        public BulkResponse Bulk(string body)
        {
            return BulkWithHttpInfo(body).GetData();
        }

        /**
         * Bulk index operations
         * Sends multiple operatons like inserts, updates, replaces or deletes.  For each operation it&#39;s object must have same format as in their dedicated method.  The method expects a raw string as the batch in NDJSON.  Each operation object needs to be serialized to   JSON and separated by endline (\\n).      An example of raw input:      &#x60;&#x60;&#x60;   {\&quot;insert\&quot;: {\&quot;index\&quot;: \&quot;movies\&quot;, \&quot;doc\&quot;: {\&quot;plot\&quot;: \&quot;A secret team goes to North Pole\&quot;, \&quot;rating\&quot;: 9.5, \&quot;language\&quot;: [2, 3], \&quot;title\&quot;: \&quot;This is an older movie\&quot;, \&quot;lon\&quot;: 51.99, \&quot;meta\&quot;: {\&quot;keywords\&quot;:[\&quot;travel\&quot;,\&quot;ice\&quot;],\&quot;genre\&quot;:[\&quot;adventure\&quot;]}, \&quot;year\&quot;: 1950, \&quot;lat\&quot;: 60.4, \&quot;advise\&quot;: \&quot;PG-13\&quot;}}}   \\n   {\&quot;delete\&quot;: {\&quot;index\&quot;: \&quot;movies\&quot;,\&quot;id\&quot;:700}}   &#x60;&#x60;&#x60;      Responds with an object telling whenever any errors occured and an array with status for each operation:      &#x60;&#x60;&#x60;   {&#39;items&#39;:[{&#39;update&#39;:{&#39;_index&#39;:&#39;products&#39;,&#39;_id&#39;:1,&#39;result&#39;:&#39;updated&#39;}},{&#39;update&#39;:{&#39;_index&#39;:&#39;products&#39;,&#39;_id&#39;:2,&#39;result&#39;:&#39;updated&#39;}}],&#39;errors&#39;:false}   &#x60;&#x60;&#x60;   
         * @param body  (required)
         * @return ApiResponse&lt;BulkResponse&gt;
         * @throws ApiException if fails to make API call
         * @http.response.details
           <table summary="Response Details" border="1">
             <tr><td> Status Code </td><td> Description </td><td> Response Headers </td></tr>
             <tr><td> 200 </td><td> item updated </td><td>  -  </td></tr>
             <tr><td> 0 </td><td> error </td><td>  -  </td></tr>
           </table>
         * 
         * @see <a href="https://docs.manticoresearch.com/latest/html/http_reference/json_update.html">Bulk index operations Documentation</a>
         */
        public ApiResponse<BulkResponse> BulkWithHttpInfo(string body)
        {
            object localVarPostBody = body;

            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new ApiException(400, "Missing the required parameter 'body' when calling bulk");
            }

            // create path and Dictionary variables
            string localVarPath = "/json/bulk";

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
              "application/x-ndjson"
            };
            string localVarContentType = apiClient.SelectHeaderContentType(localVarContentTypes);

            string[] localVarAuthNames = new string[] { };

            BulkResponse localVarReturnType = new BulkResponse() { };

            return apiClient.InvokeAPI("IndexApi.bulk", localVarPath, HttpMethod.Post, localVarQueryParams, localVarPostBody,
                                       localVarHeaderParams, localVarCookieParams, localVarFormParams, localVarAccept, localVarContentType,
                                       localVarAuthNames, localVarReturnType, false);
        }
        /**
         * Delete a document in an index
         * Delete one or several documents. The method has 2 ways of deleting: either by id, in case only one document is deleted or by using a  match query, in which case multiple documents can be delete . Example of input to delete by id:    &#x60;&#x60;&#x60;   {&#39;index&#39;:&#39;movies&#39;,&#39;id&#39;:100}   &#x60;&#x60;&#x60;  Example of input to delete using a query:    &#x60;&#x60;&#x60;   {&#39;index&#39;:&#39;movies&#39;,&#39;query&#39;:{&#39;bool&#39;:{&#39;must&#39;:[{&#39;query_string&#39;:&#39;new movie&#39;}]}}}   &#x60;&#x60;&#x60;  The match query has same syntax as in for searching. Responds with an object telling how many documents got deleted:     &#x60;&#x60;&#x60;   {&#39;_index&#39;:&#39;products&#39;,&#39;updated&#39;:1}   &#x60;&#x60;&#x60; 
         * @param deleteDocumentRequest  (required)
         * @return DeleteResponse
         * @throws ApiException if fails to make API call
         * @http.response.details
           <table summary="Response Details" border="1">
             <tr><td> Status Code </td><td> Description </td><td> Response Headers </td></tr>
             <tr><td> 200 </td><td> item updated </td><td>  -  </td></tr>
             <tr><td> 0 </td><td> error </td><td>  -  </td></tr>
           </table>
         * 
         * @see <a href="https://docs.manticoresearch.com/latest/html/http_reference/json_update.html">Delete a document in an index Documentation</a>
         */
        public DeleteResponse Delete(DeleteDocumentRequest deleteDocumentRequest)
        {
            return DeleteWithHttpInfo(deleteDocumentRequest).GetData();
        }

        /**
         * Delete a document in an index
         * Delete one or several documents. The method has 2 ways of deleting: either by id, in case only one document is deleted or by using a  match query, in which case multiple documents can be delete . Example of input to delete by id:    &#x60;&#x60;&#x60;   {&#39;index&#39;:&#39;movies&#39;,&#39;id&#39;:100}   &#x60;&#x60;&#x60;  Example of input to delete using a query:    &#x60;&#x60;&#x60;   {&#39;index&#39;:&#39;movies&#39;,&#39;query&#39;:{&#39;bool&#39;:{&#39;must&#39;:[{&#39;query_string&#39;:&#39;new movie&#39;}]}}}   &#x60;&#x60;&#x60;  The match query has same syntax as in for searching. Responds with an object telling how many documents got deleted:     &#x60;&#x60;&#x60;   {&#39;_index&#39;:&#39;products&#39;,&#39;updated&#39;:1}   &#x60;&#x60;&#x60; 
         * @param deleteDocumentRequest  (required)
         * @return ApiResponse&lt;DeleteResponse&gt;
         * @throws ApiException if fails to make API call
         * @http.response.details
           <table summary="Response Details" border="1">
             <tr><td> Status Code </td><td> Description </td><td> Response Headers </td></tr>
             <tr><td> 200 </td><td> item updated </td><td>  -  </td></tr>
             <tr><td> 0 </td><td> error </td><td>  -  </td></tr>
           </table>
         * 
         * @see <a href="https://docs.manticoresearch.com/latest/html/http_reference/json_update.html">Delete a document in an index Documentation</a>
         */
        public ApiResponse<DeleteResponse> DeleteWithHttpInfo(DeleteDocumentRequest deleteDocumentRequest)
        {
            object localVarPostBody = deleteDocumentRequest;

            // verify the required parameter 'deleteDocumentRequest' is set
            if (deleteDocumentRequest == null)
            {
                throw new ApiException(400, "Missing the required parameter 'deleteDocumentRequest' when calling delete");
            }

            // create path and Dictionary variables
            string localVarPath = "/json/delete";

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

            DeleteResponse localVarReturnType = new DeleteResponse() { };

            return apiClient.InvokeAPI("IndexApi.delete", localVarPath, HttpMethod.Post, localVarQueryParams, localVarPostBody,
                                       localVarHeaderParams, localVarCookieParams, localVarFormParams, localVarAccept, localVarContentType,
                                       localVarAuthNames, localVarReturnType, false);
        }
        /**
         * Create a new document in an index
         * Insert a document.  Expects an object like:     &#x60;&#x60;&#x60;   {&#39;index&#39;:&#39;movies&#39;,&#39;id&#39;:701,&#39;doc&#39;:{&#39;title&#39;:&#39;This is an old movie&#39;,&#39;plot&#39;:&#39;A secret team goes to North Pole&#39;,&#39;year&#39;:1950,&#39;rating&#39;:9.5,&#39;lat&#39;:60.4,&#39;lon&#39;:51.99,&#39;advise&#39;:&#39;PG-13&#39;,&#39;meta&#39;:&#39;{\&quot;keywords\&quot;:{\&quot;travel\&quot;,\&quot;ice\&quot;},\&quot;genre\&quot;:{\&quot;adventure\&quot;}}&#39;,&#39;language&#39;:[2,3]}}   &#x60;&#x60;&#x60;   The document id can also be missing, in which case an autogenerated one will be used:             &#x60;&#x60;&#x60;   {&#39;index&#39;:&#39;movies&#39;,&#39;doc&#39;:{&#39;title&#39;:&#39;This is a new movie&#39;,&#39;plot&#39;:&#39;A secret team goes to North Pole&#39;,&#39;year&#39;:2020,&#39;rating&#39;:9.5,&#39;lat&#39;:60.4,&#39;lon&#39;:51.99,&#39;advise&#39;:&#39;PG-13&#39;,&#39;meta&#39;:&#39;{\&quot;keywords\&quot;:{\&quot;travel\&quot;,\&quot;ice\&quot;},\&quot;genre\&quot;:{\&quot;adventure\&quot;}}&#39;,&#39;language&#39;:[2,3]}}   &#x60;&#x60;&#x60;   It responds with an object in format:      &#x60;&#x60;&#x60;   {&#39;_index&#39;:&#39;products&#39;,&#39;_id&#39;:701,&#39;created&#39;:true,&#39;result&#39;:&#39;created&#39;,&#39;status&#39;:201}   &#x60;&#x60;&#x60; 
         * @param insertDocumentRequest  (required)
         * @return SuccessResponse
         * @throws ApiException if fails to make API call
         * @http.response.details
           <table summary="Response Details" border="1">
             <tr><td> Status Code </td><td> Description </td><td> Response Headers </td></tr>
             <tr><td> 200 </td><td> OK </td><td>  -  </td></tr>
             <tr><td> 0 </td><td> error </td><td>  -  </td></tr>
           </table>
         * 
         * @see <a href="https://docs.manticoresearch.com/latest/html/http_reference/json_insert.html">Create a new document in an index Documentation</a>
         */
        public SuccessResponse Insert(InsertDocumentRequest insertDocumentRequest)
        {
            return InsertWithHttpInfo(insertDocumentRequest).GetData();
        }

        /**
         * Create a new document in an index
         * Insert a document.  Expects an object like:     &#x60;&#x60;&#x60;   {&#39;index&#39;:&#39;movies&#39;,&#39;id&#39;:701,&#39;doc&#39;:{&#39;title&#39;:&#39;This is an old movie&#39;,&#39;plot&#39;:&#39;A secret team goes to North Pole&#39;,&#39;year&#39;:1950,&#39;rating&#39;:9.5,&#39;lat&#39;:60.4,&#39;lon&#39;:51.99,&#39;advise&#39;:&#39;PG-13&#39;,&#39;meta&#39;:&#39;{\&quot;keywords\&quot;:{\&quot;travel\&quot;,\&quot;ice\&quot;},\&quot;genre\&quot;:{\&quot;adventure\&quot;}}&#39;,&#39;language&#39;:[2,3]}}   &#x60;&#x60;&#x60;   The document id can also be missing, in which case an autogenerated one will be used:             &#x60;&#x60;&#x60;   {&#39;index&#39;:&#39;movies&#39;,&#39;doc&#39;:{&#39;title&#39;:&#39;This is a new movie&#39;,&#39;plot&#39;:&#39;A secret team goes to North Pole&#39;,&#39;year&#39;:2020,&#39;rating&#39;:9.5,&#39;lat&#39;:60.4,&#39;lon&#39;:51.99,&#39;advise&#39;:&#39;PG-13&#39;,&#39;meta&#39;:&#39;{\&quot;keywords\&quot;:{\&quot;travel\&quot;,\&quot;ice\&quot;},\&quot;genre\&quot;:{\&quot;adventure\&quot;}}&#39;,&#39;language&#39;:[2,3]}}   &#x60;&#x60;&#x60;   It responds with an object in format:      &#x60;&#x60;&#x60;   {&#39;_index&#39;:&#39;products&#39;,&#39;_id&#39;:701,&#39;created&#39;:true,&#39;result&#39;:&#39;created&#39;,&#39;status&#39;:201}   &#x60;&#x60;&#x60; 
         * @param insertDocumentRequest  (required)
         * @return ApiResponse&lt;SuccessResponse&gt;
         * @throws ApiException if fails to make API call
         * @http.response.details
           <table summary="Response Details" border="1">
             <tr><td> Status Code </td><td> Description </td><td> Response Headers </td></tr>
             <tr><td> 200 </td><td> OK </td><td>  -  </td></tr>
             <tr><td> 0 </td><td> error </td><td>  -  </td></tr>
           </table>
         * 
         * @see <a href="https://docs.manticoresearch.com/latest/html/http_reference/json_insert.html">Create a new document in an index Documentation</a>
         */
        public ApiResponse<SuccessResponse> InsertWithHttpInfo(InsertDocumentRequest insertDocumentRequest)
        {
            object localVarPostBody = insertDocumentRequest;

            // verify the required parameter 'insertDocumentRequest' is set
            if (insertDocumentRequest == null)
            {
                throw new ApiException(400, "Missing the required parameter 'insertDocumentRequest' when calling insert");
            }

            // create path and Dictionary variables
            string localVarPath = "/json/insert";

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

            SuccessResponse localVarReturnType = new SuccessResponse() { };

            return apiClient.InvokeAPI("IndexApi.insert", localVarPath, HttpMethod.Post, localVarQueryParams, localVarPostBody,
                                       localVarHeaderParams, localVarCookieParams, localVarFormParams, localVarAccept, localVarContentType,
                                       localVarAuthNames, localVarReturnType, false);
        }
        /**
         * Replace new document in an index
         * Replace an existing document. Input has same format as &#x60;insert&#x60; operation. &lt;br/&gt; Responds with an object in format: &lt;br/&gt;    &#x60;&#x60;&#x60;   {&#39;_index&#39;:&#39;products&#39;,&#39;_id&#39;:1,&#39;created&#39;:false,&#39;result&#39;:&#39;updated&#39;,&#39;status&#39;:200}   &#x60;&#x60;&#x60; 
         * @param insertDocumentRequest  (required)
         * @return SuccessResponse
         * @throws ApiException if fails to make API call
         * @http.response.details
           <table summary="Response Details" border="1">
             <tr><td> Status Code </td><td> Description </td><td> Response Headers </td></tr>
             <tr><td> 200 </td><td> OK </td><td>  -  </td></tr>
             <tr><td> 0 </td><td> error </td><td>  -  </td></tr>
           </table>
         * 
         * @see <a href="https://docs.manticoresearch.com/latest/html/http_reference/json_insert.html">Replace new document in an index Documentation</a>
         */
        public SuccessResponse Replace(InsertDocumentRequest InsertDocumentRequest)
        {
            return ReplaceWithHttpInfo(InsertDocumentRequest).GetData();
        }

        /**
         * Replace new document in an index
         * Replace an existing document. Input has same format as &#x60;insert&#x60; operation. &lt;br/&gt; Responds with an object in format: &lt;br/&gt;    &#x60;&#x60;&#x60;   {&#39;_index&#39;:&#39;products&#39;,&#39;_id&#39;:1,&#39;created&#39;:false,&#39;result&#39;:&#39;updated&#39;,&#39;status&#39;:200}   &#x60;&#x60;&#x60; 
         * @param insertDocumentRequest  (required)
         * @return ApiResponse&lt;SuccessResponse&gt;
         * @throws ApiException if fails to make API call
         * @http.response.details
           <table summary="Response Details" border="1">
             <tr><td> Status Code </td><td> Description </td><td> Response Headers </td></tr>
             <tr><td> 200 </td><td> OK </td><td>  -  </td></tr>
             <tr><td> 0 </td><td> error </td><td>  -  </td></tr>
           </table>
         * 
         * @see <a href="https://docs.manticoresearch.com/latest/html/http_reference/json_insert.html">Replace new document in an index Documentation</a>
         */
        public ApiResponse<SuccessResponse> ReplaceWithHttpInfo(InsertDocumentRequest insertDocumentRequest)
        {
            object localVarPostBody = insertDocumentRequest;

            // verify the required parameter 'insertDocumentRequest' is set
            if (insertDocumentRequest == null)
            {
                throw new ApiException(400, "Missing the required parameter 'insertDocumentRequest' when calling replace");
            }

            // create path and Dictionary variables
            string localVarPath = "/json/replace";

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

            SuccessResponse localVarReturnType = new SuccessResponse() { };

            return apiClient.InvokeAPI("IndexApi.replace", localVarPath, HttpMethod.Post, localVarQueryParams, localVarPostBody,
                                       localVarHeaderParams, localVarCookieParams, localVarFormParams, localVarAccept, localVarContentType,
                                       localVarAuthNames, localVarReturnType, false);
        }
        /**
         * Update a document in an index
         * Update one or several documents. The update can be made by passing the id or by using a match query in case multiple documents can be updated.  For example update a document using document id:    &#x60;&#x60;&#x60;   {&#39;index&#39;:&#39;movies&#39;,&#39;doc&#39;:{&#39;rating&#39;:9.49},&#39;id&#39;:100}   &#x60;&#x60;&#x60;  And update by using a match query:    &#x60;&#x60;&#x60;   {&#39;index&#39;:&#39;movies&#39;,&#39;doc&#39;:{&#39;rating&#39;:9.49},&#39;query&#39;:{&#39;bool&#39;:{&#39;must&#39;:[{&#39;query_string&#39;:&#39;new movie&#39;}]}}}   &#x60;&#x60;&#x60;   The match query has same syntax as for searching. Responds with an object that tells how many documents where updated in format:     &#x60;&#x60;&#x60;   {&#39;_index&#39;:&#39;products&#39;,&#39;updated&#39;:1}   &#x60;&#x60;&#x60; 
         * @param updateDocumentRequest  (required)
         * @return UpdateResponse
         * @throws ApiException if fails to make API call
         * @http.response.details
           <table summary="Response Details" border="1">
             <tr><td> Status Code </td><td> Description </td><td> Response Headers </td></tr>
             <tr><td> 200 </td><td> item updated </td><td>  -  </td></tr>
             <tr><td> 0 </td><td> error </td><td>  -  </td></tr>
           </table>
         * 
         * @see <a href="https://docs.manticoresearch.com/latest/html/http_reference/json_update.html">Update a document in an index Documentation</a>
         */
        public UpdateResponse Update(UpdateDocumentRequest UpdateDocumentRequest)
        {
            return UpdateWithHttpInfo(UpdateDocumentRequest).GetData();
        }

        /**
         * Update a document in an index
         * Update one or several documents. The update can be made by passing the id or by using a match query in case multiple documents can be updated.  For example update a document using document id:    &#x60;&#x60;&#x60;   {&#39;index&#39;:&#39;movies&#39;,&#39;doc&#39;:{&#39;rating&#39;:9.49},&#39;id&#39;:100}   &#x60;&#x60;&#x60;  And update by using a match query:    &#x60;&#x60;&#x60;   {&#39;index&#39;:&#39;movies&#39;,&#39;doc&#39;:{&#39;rating&#39;:9.49},&#39;query&#39;:{&#39;bool&#39;:{&#39;must&#39;:[{&#39;query_string&#39;:&#39;new movie&#39;}]}}}   &#x60;&#x60;&#x60;   The match query has same syntax as for searching. Responds with an object that tells how many documents where updated in format:     &#x60;&#x60;&#x60;   {&#39;_index&#39;:&#39;products&#39;,&#39;updated&#39;:1}   &#x60;&#x60;&#x60; 
         * @param updateDocumentRequest  (required)
         * @return ApiResponse&lt;UpdateResponse&gt;
         * @throws ApiException if fails to make API call
         * @http.response.details
           <table summary="Response Details" border="1">
             <tr><td> Status Code </td><td> Description </td><td> Response Headers </td></tr>
             <tr><td> 200 </td><td> item updated </td><td>  -  </td></tr>
             <tr><td> 0 </td><td> error </td><td>  -  </td></tr>
           </table>
         * 
         * @see <a href="https://docs.manticoresearch.com/latest/html/http_reference/json_update.html">Update a document in an index Documentation</a>
         */
        public ApiResponse<UpdateResponse> UpdateWithHttpInfo(UpdateDocumentRequest updateDocumentRequest)
        {
            object localVarPostBody = updateDocumentRequest;

            // verify the required parameter 'updateDocumentRequest' is set
            if (updateDocumentRequest == null)
            {
                throw new ApiException(400, "Missing the required parameter 'updateDocumentRequest' when calling update");
            }

            // create path and Dictionary variables
            string localVarPath = "/json/update";

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

            UpdateResponse localVarReturnType = new UpdateResponse() { };

            return apiClient.InvokeAPI("IndexApi.update", localVarPath, HttpMethod.Post, localVarQueryParams, localVarPostBody,
                                       localVarHeaderParams, localVarCookieParams, localVarFormParams, localVarAccept, localVarContentType,
                                       localVarAuthNames, localVarReturnType, false);
        }
    }
}