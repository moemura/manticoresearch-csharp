using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManticoreSearch.Client.Model
{
    public class SuccessResponse
    {
        [JsonProperty("_index")]
        public string index;

        [JsonProperty("_id")]
        public long id;

        public bool created;

        public string result;

        public bool found;

        public SuccessResponse Index(string index)
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


        public SuccessResponse Id(long id)
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


        public SuccessResponse Created(bool created)
        {
            this.created = created;
            return this;
        }

        /**
        * Get created
        * @return created
       **/

        public bool GetCreated()
        {
            return created;
        }


        public void SetCreated(bool created)
        {
            this.created = created;
        }


        public SuccessResponse Result(string result)
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


        public SuccessResponse Found(bool found)
        {
            this.found = found;
            return this;
        }

        /**
        * Get found
        * @return found
       **/

        public bool GetFound()
        {
            return found;
        }


        public void SetFound(bool found)
        {
            this.found = found;
        }


        /**
         * Return true if this successResponse object is equal to o.
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
            SuccessResponse successResponse = (SuccessResponse)o;
            return object.Equals(this.index, successResponse.index) &&
                object.Equals(this.id, successResponse.id) &&
                object.Equals(this.created, successResponse.created) &&
                object.Equals(this.result, successResponse.result) &&
                object.Equals(this.found, successResponse.found);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(index, id, created, result, found);
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SuccessResponse {\n");
            sb.Append("    index: ").Append(ToIndentedString(index)).Append("\n");
            sb.Append("    id: ").Append(ToIndentedString(id)).Append("\n");
            sb.Append("    created: ").Append(ToIndentedString(created)).Append("\n");
            sb.Append("    result: ").Append(ToIndentedString(result)).Append("\n");
            sb.Append("    found: ").Append(ToIndentedString(found)).Append("\n");
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