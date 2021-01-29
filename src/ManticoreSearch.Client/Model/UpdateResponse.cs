using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManticoreSearch.Client.Model
{
    public class UpdateResponse
    {
        [JsonProperty("_index")]
        public string index;

        public int updated;

        [JsonProperty("_id")]
        public long id;

        public string result;

        public UpdateResponse Index(string index)
        {
            this.index = index;
            return this;
        }

        /**
        * Get index
        * @return index
       **/
        public string GetIndex()
        {
            return index;
        }


        public void SetIndex(string index)
        {
            this.index = index;
        }


        public UpdateResponse Updated(int updated)
        {
            this.updated = updated;
            return this;
        }

        /**
        * Get updated
        * @return updated
       **/
        public int GetUpdated()
        {
            return updated;
        }


        public void SetUpdated(int updated)
        {
            this.updated = updated;
        }


        public UpdateResponse Id(long id)
        {
            this.id = id;
            return this;
        }

        /**
        * Get id
        * @return id
       **/
        public long GetId()
        {
            return id;
        }


        public void SetId(long id)
        {
            this.id = id;
        }


        public UpdateResponse Result(string result)
        {
            this.result = result;
            return this;
        }

        /**
        * Get result
        * @return result
       **/
        public string GetResult()
        {
            return result;
        }


        public void SetResult(string result)
        {
            this.result = result;
        }


        /**
         * Return true if this updateResponse object is equal to o.
         */
        public override bool Equals(object o)
        {
            if (this == o)
            {
                return true;
            }
            if (o == null || GetType() != o.GetType())
            {
                return false;
            }
            UpdateResponse updateResponse = (UpdateResponse)o;
            return object.Equals(this.index, updateResponse.index) &&
                object.Equals(this.updated, updateResponse.updated) &&
                object.Equals(this.id, updateResponse.id) &&
                object.Equals(this.result, updateResponse.result);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(index, updated, id, result);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UpdateResponse {\n");
            sb.Append("    index: ").Append(ToIndentedString(index)).Append("\n");
            sb.Append("    updated: ").Append(ToIndentedString(updated)).Append("\n");
            sb.Append("    id: ").Append(ToIndentedString(id)).Append("\n");
            sb.Append("    result: ").Append(ToIndentedString(result)).Append("\n");
            sb.Append("}");
            return sb.ToString();
        }

        /**
         * Convert the given object to string with each line indented by 4 spaces
         * (except the first line).
         */
        private string ToIndentedString(object o)
        {
            if (o == null)
            {
                return "null";
            }
            return o.ToString().Replace("\n", "\n    ");
        }

    }
}