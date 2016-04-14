using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panviva.JiraDotNetIntegration.Library.Api.Common
{
    public interface IAuthenticationProvider
    {
        /// <summary>
        /// Gets the authentication headers.
        /// </summary>
        /// <returns></returns>
        IDictionary<string, string> GetAuthenticationHeaders();
    }
}
