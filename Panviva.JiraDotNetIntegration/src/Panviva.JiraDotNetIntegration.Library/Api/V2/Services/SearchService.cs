using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Panviva.JiraDotNetIntegration.Library.Api.V2.Models.Search;

namespace Panviva.JiraDotNetIntegration.Library.Api.V2.Services
{
    public class SearchService: ISearchService
    {
        private readonly IAuthenticationProvider _authenticationProvider;
        private readonly IJiraServerLocationProvider _jiraServerLocationProvider;

        public SearchService(IAuthenticationProvider authenticationProvider)
        {
            _authenticationProvider = authenticationProvider;
        }

        public SearchResponse RunJql(string jql)
        {
            throw new NotImplementedException();
        }
    }

    public interface ISearchService
    {
        SearchResponse RunJql(string jql);
    }

    public interface IJiraServerLocationProvider
    {
        string GetHostName();
        string GetApiUrlBasedOnApiVerson(int apiVersion);
    }

    public class ExplicitJiraServerLocationProvider
    {
        private readonly bool _isSecured;
        private readonly string _hostname;

        public ExplicitJiraServerLocationProvider(bool isSecured, string hostname)
        {
            _isSecured = isSecured;
            _hostname = hostname;
        }
    }

    public class BasicAuthenticationProvider : IAuthenticationProvider
    {
        /// <summary>
        /// The _user name
        /// </summary>
        private readonly string _userName;

        /// <summary>
        /// The _password
        /// </summary>
        private readonly string _password;

        /// <summary>
        /// The _headers
        /// </summary>
        private IDictionary<string, string> _headers;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicAuthenticationProvider"/> class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        public BasicAuthenticationProvider(string userName, string password)
        {
            _userName = userName;
            _password = password;
            _headers = new Dictionary<string, string>
            {
                {"Authorization", $"Basic {GetEncodedUsernameAndPassword()}"}
            };
        }

        /// <summary>
        /// Gets the authentication headers.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IDictionary<string, string> GetAuthenticationHeaders()
        {
            return _headers;
        }

        /// <summary>
        /// Gets the encoded username and password.
        /// </summary>
        /// <returns></returns>
        private string GetEncodedUsernameAndPassword()
        {
            return $"{_userName}:{_password}".Base64Encode();
        }
    }

    public interface IAuthenticationProvider
    {
        /// <summary>
        /// Gets the authentication headers.
        /// </summary>
        /// <returns></returns>
        IDictionary<string, string> GetAuthenticationHeaders();
    }

    public static class StringExtensions
    {
        /// <summary>
        /// Base64s the encode.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string Base64Encode(this string input)
        {
            if (String.IsNullOrWhiteSpace(input)) return string.Empty;

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(input);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
