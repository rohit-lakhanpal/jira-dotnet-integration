using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Panviva.JiraDotNetIntegration.Library.Api.V2.Models.Common.Base.Response
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Gets or sets the error messages.
        /// </summary>
        /// <value>
        /// The error messages.
        /// </value>
        [JsonProperty("errorMessages")]
        public IEnumerable<string> ErrorMessages { get; set; }


        /// <summary>
        /// Gets or sets the status code for the operation.
        /// </summary>
        /// <value>
        /// The status code for the operation.
        /// </value>
        [JsonProperty("status")]
        public int Status { get; set; }
    }
}
