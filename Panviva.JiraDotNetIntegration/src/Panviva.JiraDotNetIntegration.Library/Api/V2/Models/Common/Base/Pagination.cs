using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Panviva.JiraDotNetIntegration.Library.Api.V2.Models.Common.Base
{
    /// <summary>
    /// JIRA uses pagination to limit the response size for resources 
    /// that return a potentially large collection of items. 
    /// A request to a paged API will result in a values array wrapped 
    /// in a JSON object with some paging metadata.
    /// </summary>
    /// <seealso cref="Panviva.JiraDotNetIntegration.Library.Api.V2.Models.Common.Base.Expansion" />
    public abstract class Pagination: Expansion
    {
        /// <summary>
        /// Gets or sets the StartAt.
        /// Clients can use the "startAt" and "maxResults" parameters to retrieve the desired numbers of results.
        /// </summary>
        /// <value>
        /// The StartAt value.
        /// </value>
        [JsonProperty("startAt")]
        public int StartAt { get; set; }

        /// <summary>
        /// Gets or sets the MaxResults.
        /// Clients can use the "startAt" and "maxResults" parameters to retrieve the desired numbers of results.
        /// </summary>
        /// <value>
        /// The MaxResults value.
        /// </value>
        [JsonProperty("maxResults")]
        public int MaxResults { get; set; }

        /// <summary>
        /// Gets or sets the Total.
        /// The response contains a "total" field which denotes the total number of entities contained in all pages.  
        /// This number may change as the client requests the subsequent pages. 
        /// A client should always assume that the requested page can be empty. 
        /// REST API consumers should also consider the field to be optional. 
        /// In cases, when calculating this value is too expensive we may not include this in response.
        /// </summary>
        /// <value>
        /// The Total value.
        /// </value>
        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
