using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Panviva.JiraDotNetIntegration.Library.Api.Common;
using Panviva.JiraDotNetIntegration.Library.Api.V2.Models.Common.Base.Response;
using Panviva.JiraDotNetIntegration.Library.Api.V2.Models.Search;

namespace Panviva.JiraDotNetIntegration.Library.Api.V2.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Panviva.JiraDotNetIntegration.Library.Api.V2.Services.ISearchService" />
    public class SearchService: ISearchService
    {
        /// <summary>
        /// The _authentication provider
        /// </summary>
        private readonly IAuthenticationProvider _authenticationProvider;
        /// <summary>
        /// The _jira server location provider
        /// </summary>
        private readonly IJiraServerLocationProvider _jiraServerLocationProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchService"/> class.
        /// </summary>
        /// <param name="authenticationProvider">The authentication provider.</param>
        /// <param name="jiraServerLocationProvider">The jira server location provider.</param>
        public SearchService(IAuthenticationProvider authenticationProvider, IJiraServerLocationProvider jiraServerLocationProvider)
        {
            _authenticationProvider = authenticationProvider;
            _jiraServerLocationProvider = jiraServerLocationProvider;
        }


        /// <summary>
        /// Runs the JQL.
        /// </summary>
        /// <param name="jql">The JQL.</param>
        /// <param name="apiVersion">The API version.</param>
        /// <param name="successResponse">The success response.</param>
        /// <param name="errorResponse">The error response.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool RunJql(string jql, int apiVersion, out SearchResponse successResponse, out ErrorResponse errorResponse)
        {
            // run input validations
            // TODO: Ensure JQL in not null. Or should we let Jira spit out standard error??
            // TODO: Ensure apiVersion is supported

            // gather necessary information
            var searchApiUrl = GetSearchApiUrlBasedOnApiVersion(jql, apiVersion);

            // create a web request
            using (var httpClient = new HttpClient())
            {
                // set http headers
                var authHeaders = _authenticationProvider.GetAuthenticationHeaders();
                authHeaders.ToList().ForEach(h =>
                {
                    // TODO: check if we need to use ADD or Set
                    httpClient.DefaultRequestHeaders.Add(h.Key, h.Value);
                });
                
                // make a request
                var response = httpClient.GetAsync(searchApiUrl);
                
                // retrieve result
                var result = response.Result;
                var content = response.Result.Content;
                var jsonResult = content.ReadAsStringAsync().Result;

                if (result.StatusCode == HttpStatusCode.OK)
                {   // on success
                    successResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchResponse>(jsonResult);
                    errorResponse = null;
                }
                else
                {   // on error 
                    successResponse = null;
                    errorResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponse>(jsonResult);
                }
            }
            return true;
        }

        /// <summary>
        /// Gets the search API URL based on API version.
        /// </summary>
        /// <param name="jql">The JQL.</param>
        /// <param name="apiVersion">The API version.</param>
        /// <returns></returns>
        private string GetSearchApiUrlBasedOnApiVersion(string jql, int apiVersion)
        {
            return $"{_jiraServerLocationProvider.GetApiUrlBasedOnApiVerson(apiVersion)}/search?jql={Uri.EscapeUriString(jql)}";
        }
    }
}
