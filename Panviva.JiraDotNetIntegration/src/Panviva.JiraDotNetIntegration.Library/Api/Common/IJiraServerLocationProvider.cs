using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panviva.JiraDotNetIntegration.Library.Api.Common
{
    /// <summary>
    /// 
    /// </summary>
    public interface IJiraServerLocationProvider
    {
        /// <summary>
        /// Gets the name of the host.
        /// </summary>
        /// <returns></returns>
        string GetHostName();
        /// <summary>
        /// Gets the API URL based on API verson.
        /// </summary>
        /// <param name="apiVersion">The API version.</param>
        /// <returns></returns>
        string GetApiUrlBasedOnApiVerson(int apiVersion);
    }
}
