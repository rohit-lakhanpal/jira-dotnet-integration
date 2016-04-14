using System.Collections.Generic;
using Panviva.JiraDotNetIntegration.Library.Helper;

namespace Panviva.JiraDotNetIntegration.Library.Api.Common
{
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
}