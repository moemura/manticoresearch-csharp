using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ManticoreSearch.Client
{
    /**
 * Representing a Server configuration.
 */
    public class ServerConfiguration
    {
        public string _URL;
        public string description;
        public Dictionary<string, ServerVariable> variables;

        /**
         * @param URL A URL to the target host.
         * @param description A describtion of the host designated by the URL.
         * @param variables A Dictionary between a variable name and its value. The value is used for substitution in the server's URL template.
         */
        public ServerConfiguration(string URL, string description, Dictionary<string, ServerVariable> variables)
        {
            this._URL = URL;
            this.description = description;
            this.variables = variables;
        }

        /**
         * Format URL template using given variables.
         *
         * @param variables A Dictionary between a variable name and its value.
         * @return Formatted URL.
         */
        public string URL(Dictionary<string, string> variables)
        {
            string url = this._URL;

            // go through variables and replace placeholders
            foreach (var variable in this.variables)
            {
                string name = variable.Key;
                ServerVariable serverVariable = variable.Value;
                string value = serverVariable.defaultValue;

                if (variables != null && variables.ContainsKey(name))
                {
                    value = variables[name];
                    if (serverVariable.enumValues.Count > 0 && !serverVariable.enumValues.Contains(value))
                    {
                        throw new Exception("The variable " + name + " in the server URL has invalid value " + value + ".");
                    }
                }
                url = Regex.Replace(url, "\\{" + name + "\\}", value);
            }
            return url;
        }

        /**
         * Format URL template using default server variables.
         *
         * @return Formatted URL.
         */
        public string URL()
        {
            return URL(null);
        }
    }

}
