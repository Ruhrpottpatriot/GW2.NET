// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for static information about the continents.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ServiceManagement.ServiceRequests
{
    /// <summary>Represents a request for static information about the continents.</summary>
    public class ContinentsRequest : ServiceRequest
    {
        /// <summary>Initializes a new instance of the <see cref="ContinentsRequest"/> class.</summary>
        public ContinentsRequest()
            : base(Services.Continents)
        {
        }
    }
}