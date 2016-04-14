using Panviva.JiraDotNetIntegration.Library.Api.V2.Models.Common.Base.Response;
using Panviva.JiraDotNetIntegration.Library.Api.V2.Models.Search;

namespace Panviva.JiraDotNetIntegration.Library.Api.V2.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISearchService
    {
        /// <summary>
        /// Runs the JQL.
        /// </summary>
        /// <param name="jql">The JQL.</param>
        /// <param name="apiVersion">The API version.</param>
        /// <param name="successResponse">The success response.</param>
        /// <param name="errorResponse">The error response.</param>
        /// <returns></returns>
        bool RunJql(string jql, int apiVersion, out SearchResponse successResponse, out ErrorResponse errorResponse);
    }
}