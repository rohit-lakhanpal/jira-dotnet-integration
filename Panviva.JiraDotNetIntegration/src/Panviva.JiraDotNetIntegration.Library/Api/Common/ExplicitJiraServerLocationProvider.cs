namespace Panviva.JiraDotNetIntegration.Library.Api.Common
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Panviva.JiraDotNetIntegration.Library.Api.Common.IJiraServerLocationProvider" />
    public class ExplicitJiraServerLocationProvider : IJiraServerLocationProvider
    {
        /// <summary>
        /// The _is secured
        /// </summary>
        private readonly bool _isSecured;
        /// <summary>
        /// The _hostname
        /// </summary>
        private readonly string _hostname;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExplicitJiraServerLocationProvider"/> class.
        /// </summary>
        /// <param name="isSecured">if set to <c>true</c> [is secured].</param>
        /// <param name="hostname">The hostname.</param>
        public ExplicitJiraServerLocationProvider(bool isSecured, string hostname)
        {
            _isSecured = isSecured;
            _hostname = hostname; // TODO: run validations on ensuring that the hostname is valid & only accepts 
        }

        /// <summary>
        /// Gets the name of the host.
        /// </summary>
        /// <returns></returns>
        public string GetHostName()
        {
            var protocol = _isSecured ? "https" : "http";
            return $"{protocol}://{_hostname}";
        }

        /// <summary>
        /// Gets the API URL based on API verson.
        /// </summary>
        /// <param name="apiVersion">The API version.</param>
        /// <returns></returns>
        public string GetApiUrlBasedOnApiVerson(int apiVersion)
        {
            return $"{GetHostName()}/rest/api/{apiVersion}";
        }
    }
}