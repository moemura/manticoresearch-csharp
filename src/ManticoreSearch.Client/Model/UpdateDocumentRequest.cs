using System;
using System.Collections.Generic;
using System.Text;

namespace ManticoreSearch.Client.Model
{
    public class UpdateDocumentRequest
    {
        public string index;

        public Dictionary<string, object> doc = new Dictionary<string, object>();

        public long id;

        public Dictionary<string, object> query = null;

        public UpdateDocumentRequest Index(string index)
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


        public UpdateDocumentRequest Doc(Dictionary<string, object> doc)
        {
            this.doc = doc;
            return this;
        }

        /**
        * Index name
        * @return doc
       **/
        public Dictionary<string, object> GetDoc()
        {
            return doc;
        }


        public void SetDoc(Dictionary<string, object> doc)
        {
            this.doc = doc;
        }

        public UpdateDocumentRequest Id(long id)
        {
            this.id = id;
            return this;
        }

        /**
        * Document ID
        * @return id
       **/
        public long? GetId()
        {
            return id;
        }


        public void SetId(long id)
        {
            this.id = id;
        }


        public UpdateDocumentRequest Query(Dictionary<string, object> query)
        {
            this.query = query;
            return this;
        }

        /**
        * Query tree object
        * @return query
       **/
        public Dictionary<string, object> GetQuery()
        {
            return query;
        }


        public void SetQuery(Dictionary<string, object> query)
        {
            this.query = query;
        }


        /**
         * Return true if this updateDocumentRequest object is equal to o.
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
            UpdateDocumentRequest updateDocumentRequest = (UpdateDocumentRequest)o;
            return object.Equals(this.index, updateDocumentRequest.index) &&
                object.Equals(this.doc, updateDocumentRequest.doc) &&
                object.Equals(this.id, updateDocumentRequest.id) &&
                object.Equals(this.query, updateDocumentRequest.query);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(index, doc, id, query);
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UpdateDocumentRequest {\n");
            sb.Append("    index: ").Append(ToIndentedString(index)).Append("\n");
            sb.Append("    doc: ").Append(ToIndentedString(doc)).Append("\n");
            sb.Append("    id: ").Append(ToIndentedString(id)).Append("\n");
            sb.Append("    query: ").Append(ToIndentedString(query)).Append("\n");
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