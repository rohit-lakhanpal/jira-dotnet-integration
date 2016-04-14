using System;

namespace Panviva.JiraDotNetIntegration.Library.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public static class Validators
    {
        /// <summary>
        /// Determines whether [is valid ip] [the specified input].
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static bool IsValidIpOrHostName(this string input)
        {
            // TODO: Complete implementation.
            var isValidIpOrHostName = Uri.CheckHostName(input);
            switch (isValidIpOrHostName)
            {
                case UriHostNameType.IPv4:
                case UriHostNameType.IPv6:
                    return true;
                case UriHostNameType.Dns:
                    return true;
                case UriHostNameType.Unknown:
                    break;
                case UriHostNameType.Basic:
                    break;
            }
            return false;
        }
    }
}
