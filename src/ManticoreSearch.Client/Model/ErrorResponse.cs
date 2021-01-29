using System;
using System.Collections.Generic;
using System.Text;

namespace ManticoreSearch.Client.Model
{
    public class ErrorResponse
    {
        public Dictionary<string, object> error = new Dictionary<string, object>();

        public int status;

        public ErrorResponse Error(Dictionary<string, object> error)
        {
            this.error = error;
            return this;
        }

        /**
        * Get error
        * @return error
       **/
        public Dictionary<string, object> GetError()
        {
            return error;
        }


        public void SetError(Dictionary<string, object> error)
        {
            this.error = error;
        }


        public ErrorResponse Status(int status)
        {
            this.status = status;
            return this;
        }

        /**
        * Get status
        * @return status
       **/
        public int GetStatus()
        {
            return status;
        }


        public void SetStatus(int status)
        {
            this.status = status;
        }


        /**
         * Return true if this errorResponse object is equal to o.
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
            ErrorResponse errorResponse = (ErrorResponse)o;
            return object.Equals(this.error, errorResponse.error) &&
                object.Equals(this.status, errorResponse.status);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(error, status);
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ErrorResponse {\n");
            sb.Append("    error: ").Append(ToIndentedString(error)).Append("\n");
            sb.Append("    status: ").Append(ToIndentedString(status)).Append("\n");
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