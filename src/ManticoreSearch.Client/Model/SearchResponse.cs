using System;
using System.Collections.Generic;
using System.Text;

namespace ManticoreSearch.Client.Model
{
    public class SearchResponse
    {
        public int took;

        public bool timedOut;

        public Dictionary<string, object> aggregations = null;

        public SearchResponseHits hits;

        public object profile;

        public SearchResponse Took(int took)
        {
            this.took = took;
            return this;
        }

        /**
        * Get took
        * @return took
       **/
        public int GetTook()
        {
            return took;
        }

        public void SetTook(int took)
        {
            this.took = took;
        }

        public SearchResponse TimedOut(bool timedOut)
        {
            this.timedOut = timedOut;
            return this;
        }

        /**
        * Get timedOut
        * @return timedOut
       **/
        public bool GetTimedOut()
        {
            return timedOut;
        }

        public void SetTimedOut(bool timedOut)
        {
            this.timedOut = timedOut;
        }


        public SearchResponse Aggregations(Dictionary<string, object> aggregations)
        {
            this.aggregations = aggregations;
            return this;
        }

        /**
        * Get aggregations
        * @return aggregations
       **/
        public Dictionary<string, object> GetAggregations()
        {
            return aggregations;
        }

        public void SetAggregations(Dictionary<string, object> aggregations)
        {
            this.aggregations = aggregations;
        }

        public SearchResponse Hits(SearchResponseHits hits)
        {
            this.hits = hits;
            return this;
        }

        /**
        * Get hits
        * @return hits
       **/
        public SearchResponseHits GetHits()
        {
            return hits;
        }

        public void SetHits(SearchResponseHits hits)
        {
            this.hits = hits;
        }

        public SearchResponse Profile(object profile)
        {
            this.profile = profile;
            return this;
        }

        /**
        * Get profile
        * @return profile
       **/
        public object GetProfile()
        {
            return profile;
        }

        public void SetProfile(object profile)
        {
            this.profile = profile;
        }

        /**
         * Return true if this searchResponse object is equal to o.
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
            SearchResponse searchResponse = (SearchResponse)o;
            return object.Equals(this.took, searchResponse.took) &&
                object.Equals(this.timedOut, searchResponse.timedOut) &&
                object.Equals(this.aggregations, searchResponse.aggregations) &&
                object.Equals(this.hits, searchResponse.hits) &&
                object.Equals(this.profile, searchResponse.profile);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(took, timedOut, aggregations, hits, profile);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SearchResponse {\n");
            sb.Append("    took: ").Append(ToIndentedString(took)).Append("\n");
            sb.Append("    timedOut: ").Append(ToIndentedString(timedOut)).Append("\n");
            sb.Append("    aggregations: ").Append(ToIndentedString(aggregations)).Append("\n");
            sb.Append("    hits: ").Append(ToIndentedString(hits)).Append("\n");
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