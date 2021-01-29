using System;
using System.Collections.Generic;
using System.Text;

namespace ManticoreSearch.Client.Model
{
    public class BulkResponse
    {
        public object items;

        public bool error;

        public BulkResponse Items(object items)
        {
            this.items = items;
            return this;
        }

        /**
        * Get items
        * @return items
       **/
        public object GetItems()
        {
            return items;
        }


        public void SetItems(object items)
        {
            this.items = items;
        }


        public BulkResponse Error(bool error)
        {
            this.error = error;
            return this;
        }

        /**
        * Get error
        * @return error
       **/
        public bool GetError()
        {
            return error;
        }


        public void SetError(bool error)
        {
            this.error = error;
        }

        /**
         * A container for additional, undeclared properties.
         * This is a holder for any undeclared properties as specified with
         * the 'additionalProperties' keyword in the OAS document.
         */
        private Dictionary<string, object> AdditionalProperties;

        /**
         * Set the additional (undeclared) property with the specified name and value.
         * If the property does not already exist, create it otherwise replace it.
         */
        public BulkResponse PutAdditionalProperty(string key, object value)
        {
            if (this.AdditionalProperties == null)
            {
                this.AdditionalProperties = new Dictionary<string, object>();
            }
            this.AdditionalProperties.Add(key, value);
            return this;
        }

        /**
         * Return the additional (undeclared) property.
         */
        public Dictionary<string, object> GetAdditionalProperties()
        {
            return AdditionalProperties;
        }

        /**
         * Return the additional (undeclared) property with the specified name.
         */
        public object GetAdditionalProperty(string key)
        {
            if (this.AdditionalProperties == null)
            {
                return null;
            }
            return this.AdditionalProperties[key];
        }

        /**
         * Return true if this bulkResponse object is equal to o.
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
            BulkResponse bulkResponse = (BulkResponse)o;
            return object.Equals(this.items, bulkResponse.items) &&
                object.Equals(this.error, bulkResponse.error) &&
                object.Equals(this.AdditionalProperties, bulkResponse.AdditionalProperties);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(items, error, AdditionalProperties);
        }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BulkResponse {\n");
            sb.Append("    items: ").Append(ToIndentedString(items)).Append("\n");
            sb.Append("    error: ").Append(ToIndentedString(error)).Append("\n");
            sb.Append("    additionalProperties: ").Append(ToIndentedString(AdditionalProperties)).Append("\n");
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