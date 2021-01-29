using System;
using System.Collections.Generic;
using System.Text;

namespace ManticoreSearch.Client
{
    public class Pair
    {
        private string name = "";
        private string value = "";

        public Pair(string name, string value)
        {
            SetName(name);
            SetValue(value);
        }

        private void SetName(string name)
        {
            if (!IsValidString(name))
            {
                return;
            }

            this.name = name;
        }

        private void SetValue(string value)
        {
            if (!IsValidString(value))
            {
                return;
            }

            this.value = value;
        }

        public string GetName()
        {
            return this.name;
        }

        public string GetValue()
        {
            return this.value;
        }

        private bool IsValidString(string arg)
        {
            if (arg == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(arg.Trim()))
            {
                return false;
            }

            return true;
        }
    }
}
