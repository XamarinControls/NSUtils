﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NSUtils
{
    public static class ExtensionMethodsString
    {
        public static string EncodeRFC3986(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            var encoded = Uri.EscapeDataString(value);

            return Regex
            .Replace(encoded, "(%[0-9a-f][0-9a-f])", c => c.Value.ToUpper())
            .Replace("(", "%28")
            .Replace(")", "%29")
            .Replace("$", "%24")
            .Replace("!", "%21")
            .Replace("*", "%2A")
            .Replace("'", "%27")
            .Replace("%7E", "~");
        }

        public static string ToBooleanString(this bool boolValue)
        {
            if (boolValue == true)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }

        public static string ToStringComplete(this IEnumerable<string> enumerable, string delimiter = "")
        {
            string longString = string.Empty;
            if(string.IsNullOrEmpty(delimiter))
            {
                delimiter = System.Environment.NewLine;
            }

            return enumerable.Aggregate((i, j) => i + delimiter + j);            
        }
    }
}
