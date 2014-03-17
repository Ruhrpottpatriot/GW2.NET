// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for a list of all discovered items.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ServiceManagement.ServiceRequests
{
    /// <summary>Represents a request for a list of all discovered items.</summary>
    public class ItemsRequest : ServiceRequest
    {
        /// <summary>Initializes a new instance of the <see cref="ItemsRequest" /> class.</summary>
        public ItemsRequest()
            : base(Services.Items)
        {
        }
    }
}