using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManticoreSearch.Client.Model
{
    public class DeleteResponse
    {
        [JsonProperty("_index")]
        public string index;

        public int deleted;

        public long id;

        public string result;

        public DeleteResponse Index(string index)
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


        public DeleteResponse Deleted(int deleted)
        {
            this.deleted = deleted;
            return this;
        }

        /**
        * Get deleted
        * @return deleted
       **/
        public int GetDeleted()
        {
            return deleted;
        }


        public void SetDeleted(int deleted)
        {
            this.deleted = deleted;
        }


        public DeleteResponse Id(long id)
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


        public DeleteResponse Result(string result)
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
         * Return true if this deleteResponse object is equal to o.
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
            DeleteResponse deleteResponse = (DeleteResponse)o;
            return object.Equals(this.index, deleteResponse.index) &&
                object.Equals(this.deleted, deleteResponse.deleted) &&
                object.Equals(this.id, deleteResponse.id) &&
                object.Equals(this.result, deleteResponse.result);
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(index, deleted, id, result);
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DeleteResponse {\n");
            sb.Append("    index: ").Append(ToIndentedString(index)).Append("\n");
            sb.Append("    deleted: ").Append(ToIndentedString(deleted)).Append("\n");
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