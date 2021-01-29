using System;
using System.Collections.Generic;
using System.Text;

namespace ManticoreSearch.Client.Model
{
    public class SearchRequest
    {
        public string index;

        public Dictionary<string, object> query = new Dictionary<string, object>();

        public int? limit = null;

        public int? offset = null;

        public int? maxMatches = null;

        public List<object> sort = null;

        public Dictionary<string, object> aggs = null;

        public object expressions;

        public object highlight;

        public List<string> source = null;

        public bool profile;

        public SearchRequest Index(string index)
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


        public SearchRequest Query(Dictionary<string, object> query)
        {
            this.query = query;
            return this;
        }

        /**
        * Get query
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


        public SearchRequest Limit(int limit)
        {
            this.limit = limit;
            return this;
        }

        /**
        * Get limit
        * @return limit
       **/
        public int? GetLimit()
        {
            return limit;
        }


        public void SetLimit(int? limit)
        {
            this.limit = limit;
        }

        public SearchRequest Offset(int? offset)
        {
            this.offset = offset;
            return this;
        }

        /**
        * Get offset
        * @return offset
       **/
        public int? GetOffset()
        {
            return offset;
        }


        public void SetOffset(int? offset)
        {
            this.offset = offset;
        }


        public SearchRequest MaxMatches(int? maxMatches)
        {
            this.maxMatches = maxMatches;
            return this;
        }

        /**
        * Get maxMatches
        * @return maxMatches
       **/
        public int? GetMaxMatches()
        {
            return maxMatches;
        }


        public void SetMaxMatches(int? maxMatches)
        {
            this.maxMatches = maxMatches;
        }


        public SearchRequest Sort(List<object> sort)
        {
            this.sort = sort;
            return this;
        }

        /**
        * Get sort
        * @return sort
       **/
        public List<object> GetSort()
        {
            return sort;
        }


        public void SetSort(List<object> sort)
        {
            this.sort = sort;
        }


        public SearchRequest Aggs(Dictionary<string, object> aggs)
        {
            this.aggs = aggs;
            return this;
        }

        /**
        * Get aggs
        * @return aggs
       **/
        public Dictionary<string, object> GetAggs()
        {
            return aggs;
        }


        public void SetAggs(Dictionary<string, object> aggs)
        {
            this.aggs = aggs;
        }


        public SearchRequest Expressions(object expressions)
        {
            this.expressions = expressions;
            return this;
        }

        /**
        * Get expressions
        * @return expressions
       **/
        public object GetExpressions()
        {
            return expressions;
        }


        public void SetExpressions(object expressions)
        {
            this.expressions = expressions;
        }


        public SearchRequest Highlight(object highlight)
        {
            this.highlight = highlight;
            return this;
        }

        /**
        * Get highlight
        * @return highlight
       **/
        public object GetHighlight()
        {
            return highlight;
        }


        public void SetHighlight(object highlight)
        {
            this.highlight = highlight;
        }


        public SearchRequest Source(List<string> source)
        {
            this.source = source;
            return this;
        }

        /**
        * Get source
        * @return source
       **/
        public List<string> GetSource()
        {
            return source;
        }


        public void SetSource(List<string> source)
        {
            this.source = source;
        }


        public SearchRequest Profile(bool profile)
        {
            this.profile = profile;
            return this;
        }

        /**
        * Get profile
        * @return profile
       **/
        public bool GetProfile()
        {
            return profile;
        }


        public void SetProfile(bool profile)
        {
            this.profile = profile;
        }


        /**
         * Return true if this searchRequest object is equal to o.
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
            SearchRequest searchRequest = (SearchRequest)o;
            return object.Equals(this.index, searchRequest.index) &&
                object.Equals(this.query, searchRequest.query) &&
                object.Equals(this.limit, searchRequest.limit) &&
                object.Equals(this.offset, searchRequest.offset) &&
                object.Equals(this.maxMatches, searchRequest.maxMatches) &&
                object.Equals(this.sort, searchRequest.sort) &&
                object.Equals(this.aggs, searchRequest.aggs) &&
                object.Equals(this.expressions, searchRequest.expressions) &&
                object.Equals(this.highlight, searchRequest.highlight) &&
                object.Equals(this.source, searchRequest.source) &&
                object.Equals(this.profile, searchRequest.profile);
        }

        public override int GetHashCode()
        {
            //return HashCode.Combine(index, query, limit, offset, maxMatches, sort, aggs, expressions, highlight, source, profile);

            HashCode hash = new HashCode();
            hash.Add(index);
            hash.Add(query);
            hash.Add(limit);
            hash.Add(offset);
            hash.Add(maxMatches);
            hash.Add(sort);
            hash.Add(aggs);
            //hash.Add(expressions);
            hash.Add(highlight);
            hash.Add(source);
            hash.Add(profile);
            return hash.ToHashCode();
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SearchRequest {\n");
            sb.Append("    index: ").Append(ToIndentedString(index)).Append("\n");
            sb.Append("    query: ").Append(ToIndentedString(query)).Append("\n");
            sb.Append("    limit: ").Append(ToIndentedString(limit)).Append("\n");
            sb.Append("    offset: ").Append(ToIndentedString(offset)).Append("\n");
            sb.Append("    maxMatches: ").Append(ToIndentedString(maxMatches)).Append("\n");
            sb.Append("    sort: ").Append(ToIndentedString(sort)).Append("\n");
            sb.Append("    aggs: ").Append(ToIndentedString(aggs)).Append("\n");
            sb.Append("    expressions: ").Append(ToIndentedString(expressions)).Append("\n");
            sb.Append("    highlight: ").Append(ToIndentedString(highlight)).Append("\n");
            sb.Append("    source: ").Append(ToIndentedString(source)).Append("\n");
            sb.Append("    profile: ").Append(ToIndentedString(profile)).Append("\n");
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