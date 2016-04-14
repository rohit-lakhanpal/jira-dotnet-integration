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
    public class SearchService: ISearchService
    {
        private readonly IAuthenticationProvider _authenticationProvider;
        private readonly IJiraServerLocationProvider _jiraServerLocationProvider;

        public SearchService(IAuthenticationProvider authenticationProvider, IJiraServerLocationProvider jiraServerLocationProvider)
        {
            _authenticationProvider = authenticationProvider;
            _jiraServerLocationProvider = jiraServerLocationProvider;
        }


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
                var asyncResponse = httpClient.GetAsync(searchApiUrl);
                asyncResponse.RunSynchronously(); // TODO: Think running this sync makes more sense. Think about it you fool!


                var result = asyncResponse.Result;
                if (result.StatusCode == HttpStatusCode.OK)
                { // Success
                    Stream receiveStream = null;
                    var copyToAsync = result.Content.CopyToAsync(receiveStream);
                    copyToAsync.RunSynchronously();
                    var jsonResult = new StreamReader(receiveStream, Encoding.UTF8).ReadToEnd();

                    // read the r
                    successResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchResponse>(jsonResult);
                }
                else
                { // Error 
                    
                }
            }


            throw new NotImplementedException();
        }

        private string GetSearchApiUrlBasedOnApiVersion(string jql, int apiVersion)
        {
            return $"{_jiraServerLocationProvider.GetApiUrlBasedOnApiVerson(apiVersion)}/search?jql={Uri.EscapeUriString(jql)}";
        }
    }

    public interface ISearchService
    {
        bool RunJql(string jql, int apiVersion, out SearchResponse successResponse, out ErrorResponse errorResponse);
    }

    public interface IJiraServerLocationProvider
    {
        string GetHostName();
        string GetApiUrlBasedOnApiVerson(int apiVersion);
    }

    public class ExplicitJiraServerLocationProvider: IJiraServerLocationProvider
    {
        private readonly bool _isSecured;
        private readonly string _hostname;

        public ExplicitJiraServerLocationProvider(bool isSecured, string hostname)
        {
            _isSecured = isSecured;
            _hostname = hostname; // TODO: run validations on ensuring that the hostname is valid & only accepts 
        }

        public string GetHostName()
        {
            // https://panviva.atlassian.net/rest/api/2/
            var protocol = _isSecured ? "https" : "http";
            return $"{protocol}://{_hostname}";
        }

        public string GetApiUrlBasedOnApiVerson(int apiVersion)
        {
            throw new NotImplementedException();
        }
    }
}
