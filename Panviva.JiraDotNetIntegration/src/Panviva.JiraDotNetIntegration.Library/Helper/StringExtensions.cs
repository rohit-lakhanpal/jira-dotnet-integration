using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panviva.JiraDotNetIntegration.Library.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Base64s the encode.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string Base64Encode(this string input)
        {
            if (String.IsNullOrWhiteSpace(input)) return string.Empty;

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(input);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
