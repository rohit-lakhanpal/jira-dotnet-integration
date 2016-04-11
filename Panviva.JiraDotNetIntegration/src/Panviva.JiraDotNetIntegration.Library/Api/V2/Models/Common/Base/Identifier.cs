using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Panviva.JiraDotNetIntegration.Library.Api.V2.Models.Common.Base
{
    /// <summary>
    /// Base class for JSON payload that contain id & self
    /// </summary>
    public abstract class Identifier
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        [JsonProperty("self")]
        public string Url { get; set; }
    }
}
