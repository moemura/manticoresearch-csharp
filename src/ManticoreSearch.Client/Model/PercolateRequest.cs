using System;
using System.Collections.Generic;
using System.Text;

public class PercolateRequest
{
    public Dictionary<string, object> query;

    public PercolateRequest Query(Dictionary<string, object> query)
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


    /**
     * Return true if this percolateRequest object is equal to o.
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
        PercolateRequest percolateRequest = (PercolateRequest)o;
        return object.Equals(this.query, percolateRequest.query);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(query);
    }


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("class PercolateRequest {\n");
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