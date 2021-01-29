using System;
using System.Collections.Generic;
using System.Text;

namespace ManticoreSearch.Client
{
    /**
     * Representing a Server Variable for server URL template substitution.
     */
    public class ServerVariable
    {
        public string description;
        public string defaultValue;
        public HashSet<string> enumValues = null;

        /**
         * @param description A description for the server variable.
         * @param defaultValue The default value to use for substitution.
         * @param enumValues An enumeration of string values to be used if the substitution options are from a limited set.
         */
        public ServerVariable(string description, string defaultValue, HashSet<string> enumValues)
        {
            this.description = description;
            this.defaultValue = defaultValue;
            this.enumValues = enumValues;
        }
    }
}
