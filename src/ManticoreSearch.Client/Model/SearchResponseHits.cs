using System;
using System.Collections.Generic;
using System.Text;

namespace ManticoreSearch.Client.Model
{
    public class SearchResponseHits
    {
        public int maxScore;

        public int total;

        public List<object> hits;

        public SearchResponseHits MaxScore(int maxScore)
        {
            this.maxScore = maxScore;
            return this;
        }

        /**
        * Get maxScore
        * @return maxScore
       **/
        public int GetMaxScore()
        {
            return maxScore;
        }


        public void SetMaxScore(int maxScore)
        {
            this.maxScore = maxScore;
        }


        public SearchResponseHits Total(int total)
        {
            this.total = total;
            return this;
        }

        /**
        * Get total
        * @return total
       **/
        public int GetTotal()
        {
            return total;
        }


        public void SetTotal(int total)
        {
            this.total = total;
        }


        public SearchResponseHits Hits(List<object> hits)
        {
            this.hits = hits;
            return this;
        }

        /**
        * Get hits
        * @return hits
       **/
        public List<object> GetHits()
        {
            return hits;
        }


        public void SetHits(List<object> hits)
        {
            this.hits = hits;
        }


        /**
         * Return true if this searchResponse_hits object is equal to o.
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
            SearchResponseHits searchResponseHits = (SearchResponseHits)o;
            return object.Equals(this.maxScore, searchResponseHits.maxScore) &&
                object.Equals(this.total, searchResponseHits.total) &&
                object.Equals(this.hits, searchResponseHits.hits);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(maxScore, total, hits);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SearchResponseHits {\n");
            sb.Append("    maxScore: ").Append(ToIndentedString(maxScore)).Append("\n");
            sb.Append("    total: ").Append(ToIndentedString(total)).Append("\n");
            sb.Append("    hits: ").Append(ToIndentedString(hits)).Append("\n");
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