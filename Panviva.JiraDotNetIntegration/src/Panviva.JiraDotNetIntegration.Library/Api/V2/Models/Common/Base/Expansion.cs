using Newtonsoft.Json;

namespace Panviva.JiraDotNetIntegration.Library.Api.V2.Models.Common.Base
{
    /// <summary>
    /// In order to simplify API responses, the JIRA REST API uses resource expansion. 
    /// This means the API will only return parts of the resource when explicitly requested.
    /// You can use the expand query parameter to specify a comma-separated list of entities 
    /// that you want expanded, identifying each of them by name.
    /// For example, 
    ///     appending ? expand = names,
    /// renderedFields to an issue's URI requests the inclusion of the translated field names 
    /// and the HTML-rendered field values in the response. 
    /// </summary>
    public abstract class Expansion
    {
        /// <summary>
        /// Gets or sets the expand. It helps to discover the identifiers for each entity, look at the expand property in the parent object
        /// </summary>
        /// <value>
        /// The expand.
        /// </value>
        [JsonProperty("expand")]
        public string Expand { get; set; }

        /// <summary>
        /// Gets or sets the self. This is used to discover the url for querying itself
        /// </summary>
        /// <value>
        /// The self.
        /// </value>
        [JsonProperty("self")]
        public string Self { get; set; }
    }
}
