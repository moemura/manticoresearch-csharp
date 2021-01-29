using System;
using System.Collections.Generic;
using System.Text;

namespace ManticoreSearch.Client.Model
{
    public class DeleteDocumentRequest
    {
        public string index;

        public string cluster;

        public long? id = null;

        public object query;

        public DeleteDocumentRequest Index(string index)
        {
            this.index = index;
            return this;
        }

        /**
        * Index name
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


        public DeleteDocumentRequest Cluster(string cluster)
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


        public DeleteDocumentRequest Id(long? id)
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


        public DeleteDocumentRequest Query(object query)
        {
            this.query = query;
            return this;
        }

        /**
        * Query tree object
        * @return query
       **/
        public object GetQuery()
        {
            return query;
        }


        public void SetQuery(object query)
        {
            this.query = query;
        }


        /**
         * Return true if this deleteDocumentRequest object is equal to o.
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
            DeleteDocumentRequest deleteDocumentRequest = (DeleteDocumentRequest)o;
            return object.Equals(this.index, deleteDocumentRequest.index) &&
                object.Equals(this.cluster, deleteDocumentRequest.cluster) &&
                object.Equals(this.id, deleteDocumentRequest.id) &&
                object.Equals(this.query, deleteDocumentRequest.query);
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(index, cluster, id, query);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DeleteDocumentRequest {\n");
            sb.Append("    index: ").Append(ToIndentedString(index)).Append("\n");
            sb.Append("    cluster: ").Append(ToIndentedString(cluster)).Append("\n");
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