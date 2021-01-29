using System;
using System.Collections.Generic;
using System.Text;

namespace ManticoreSearch.Client.Model
{
    public class InsertDocumentRequest
    {
        public string index;

        public string cluster;

        public long id;

        public Dictionary<string, object> doc = new Dictionary<string, object>();

        public InsertDocumentRequest Index(string index)
        {
            this.index = index;
            return this;
        }

        /**
        * Name of the index
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


        public InsertDocumentRequest Cluster(string cluster)
        {
            this.cluster = cluster;
            return this;
        }

        /**
        * cluster name
        * @return cluster
       **/

        public string GetCluster()
        {
            return cluster;
        }


        public void SetCluster(string cluster)
        {
            this.cluster = cluster;
        }


        public InsertDocumentRequest Id(long id)
        {
            this.id = id;
            return this;
        }

        /**
        * Document ID. 
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


        public InsertDocumentRequest Doc(Dictionary<string, object> doc)
        {
            this.doc = doc;
            return this;
        }

        /**
        * Object with document data 
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


        /**
         * Return true if this insertDocumentRequest object is equal to o.
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
            InsertDocumentRequest insertDocumentRequest = (InsertDocumentRequest)o;
            return Object.Equals(this.index, insertDocumentRequest.index) &&
                Object.Equals(this.cluster, insertDocumentRequest.cluster) &&
                Object.Equals(this.id, insertDocumentRequest.id) &&
                Object.Equals(this.doc, insertDocumentRequest.doc);
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(index, cluster, id, doc);
        }


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InsertDocumentRequest {\n");
            sb.Append("    index: ").Append(ToIndentedstring(index)).Append("\n");
            sb.Append("    cluster: ").Append(ToIndentedstring(cluster)).Append("\n");
            sb.Append("    id: ").Append(ToIndentedstring(id)).Append("\n");
            sb.Append("    doc: ").Append(ToIndentedstring(doc)).Append("\n");
            sb.Append("}");
            return sb.ToString();
        }

        /**
         * Convert the given object to string with each line indented by 4 spaces
         * (except the first line).
         */
        private string ToIndentedstring(object o)
        {
            if (o == null)
            {
                return "null";
            }
            return o.ToString().Replace("\n", "\n    ");
        }
    }
}