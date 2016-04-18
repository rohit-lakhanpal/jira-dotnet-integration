using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Panviva.JiraDotNetIntegration.Library.Api.Common;
using Panviva.JiraDotNetIntegration.Library.Api.V2.Models.Common.Base.Response;
using Panviva.JiraDotNetIntegration.Library.Api.V2.Models.Search;
using Panviva.JiraDotNetIntegration.Library.Api.V2.Services;
using Xunit;

namespace Panviva.JiraDotNetIntegration.Library.Tests.Api.V2.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchServiceTest
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
        /// The user name
        /// </summary>
        private readonly string _userName;
        /// <summary>
        /// The password
        /// </summary>
        private readonly string _password;

        /// <summary>
        /// The _host name
        /// </summary>
        private readonly string _hostName;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchServiceTest"/> class.
        /// </summary>
        public SearchServiceTest()
        {
            _userName = "your_user_name";
            _password = "your_password";
            _hostName = "yoursite.atlassian.net";

            _authenticationProvider = new BasicAuthenticationProvider(_userName, _password);
            _jiraServerLocationProvider = new ExplicitJiraServerLocationProvider(true, _hostName);
        }

        [Fact]
        public void Test_RunJql_ValidJql_ExpectSingleSearchResponse()
        {
            // arrange
            var sut = new SearchService(_authenticationProvider, _jiraServerLocationProvider);
            SearchResponse successResponse;
            ErrorResponse errorResponse;
            var jqlQuery = "key=SPUI-14234";

            // act
            var result = sut.RunJql(jqlQuery, 2, out successResponse, out errorResponse);

            // assert
            Assert.Equal(true, result);
            Assert.Null(errorResponse);
            Assert.NotNull(successResponse);
            Assert.Equal(1, successResponse.Issues.Count());
        }

        [Fact]
        public void Test_RunJql_ValidJql_ExpectMultipleSearchResponses()
        {
            // arrange
            var sut = new SearchService(_authenticationProvider, _jiraServerLocationProvider);
            SearchResponse successResponse;
            ErrorResponse errorResponse;
            var jqlQuery = "project=SPUI";

            // act
            var result = sut.RunJql(jqlQuery, 2, out successResponse, out errorResponse);

            // assert
            Assert.Equal(true, result);
            Assert.Null(errorResponse);
            Assert.NotNull(successResponse);
            Assert.NotEmpty(successResponse.Issues);
        }
    }
}
