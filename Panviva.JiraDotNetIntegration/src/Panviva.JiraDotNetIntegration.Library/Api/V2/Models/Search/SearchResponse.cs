using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Panviva.JiraDotNetIntegration.Library.Api.V2.Models.Common.Base;
using Panviva.JiraDotNetIntegration.Library.Api.V2.Models.Common.Base.Response;

namespace Panviva.JiraDotNetIntegration.Library.Api.V2.Models.Search
{
    public class SearchResponse: BaseSuccessResponse
    {
        [JsonProperty("issues")]
        public IEnumerable<Issues> Issues { get; set; }
    }

    /// <summary>
    /// This defines the issues returned by the Search API
    /// </summary>
    /// <seealso cref="Identifier" />
    public class Issues : Identifier
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the issue fields.
        /// </summary>
        /// <value>
        /// The issue fields.
        /// </value>
        [JsonProperty("fields")]
        public IssueFields IssueFields { get; set; }
    }

    public class IssueFields
    {
        /// <summary>
        /// Gets or sets the type of the issue.
        /// </summary>
        /// <value>
        /// The type of the issue.
        /// </value>
        [JsonProperty("issuetype")]
        public IssueType IssueType { get; set; }

        // TODO: Check if this is returned as a string or another data type??
        /// <summary>
        /// Gets or sets the time spent.
        /// </summary>
        /// <value>
        /// The time spent.
        /// </value>
        [JsonProperty("timespent")]
        public string TimeSpent { get; set; }

        public Project project { get; set; }

        /// <summary>
        /// Gets or sets the fix versions.
        /// </summary>
        /// <value>
        /// The fix versions.
        /// </value>
        [JsonProperty("fixVersions")]
        public IEnumerable<FixVersion> FixVersions { get; set; }
    }

    public class IssueType : Identifier
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the icon URL.
        /// </summary>
        /// <value>
        /// The icon URL.
        /// </value>
        [JsonProperty("iconUrl")]
        public string IconUrl { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [sub task].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [sub task]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("subtask")]
        public bool SubTask { get; set; }

        /// <summary>
        /// Gets or sets the avatar identifier.
        /// </summary>
        /// <value>
        /// The avatar identifier.
        /// </value>
        [JsonProperty("avatarId")]
        public int? AvatarId { get; set; }
    }
    public class Project : Identifier
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the project category.
        /// </summary>
        /// <value>
        /// The project category.
        /// </value>
        [JsonProperty("projectCategory")]
        public ProjectCategory ProjectCategory { get; set; }
    }

    /// <summary>
    /// Contains project category description.
    /// </summary>
    /// <seealso cref="App.JiraApiQuery.Package.Api.V2.Models.Common.Identifier" />
    public class ProjectCategory : Identifier
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class FixVersion : Identifier
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [JsonProperty("description")]
        public string Description { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FixVersion"/> is archived.
        /// </summary>
        /// <value>
        ///   <c>true</c> if archived; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("archived")]
        public bool Archived { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FixVersion"/> is released.
        /// </summary>
        /// <value>
        ///   <c>true</c> if released; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("released")]
        public bool Released { get; set; }

        /// <summary>
        /// Gets or sets the release date.
        /// </summary>
        /// <value>
        /// The release date.
        /// </value>
        [JsonProperty("releaseDate")]
        public string ReleaseDate { get; set; }
    }
}
