// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for service requests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Common
{
    /// <summary>Provides the interface for service requests.</summary>
    public interface IServiceRequest
    {
        /// <summary>Gets the resource identifier.</summary>
        int? Identifier { get; }

        /// <summary>Gets the resource path.</summary>
        string Resource { get; }
    }
}