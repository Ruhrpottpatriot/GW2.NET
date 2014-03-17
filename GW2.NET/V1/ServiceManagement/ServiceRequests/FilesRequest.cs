// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilesRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for commonly requested in-game assets. The returned information can be used with the render service to retrieve assets.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ServiceManagement.ServiceRequests
{
    /// <summary>Represents a request for commonly requested in-game assets. The returned information can be used with the render service to retrieve assets.</summary>
    public class FilesRequest : ServiceRequest
    {
        /// <summary>Initializes a new instance of the <see cref="FilesRequest" /> class.</summary>
        public FilesRequest()
            : base(Services.Files)
        {
        }
    }
}