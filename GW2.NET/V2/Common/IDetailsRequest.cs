// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDetailsRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for resource details requests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Common
{
    using GW2DotNET.Common;

    /// <summary>Provides the interface for resource details requests.</summary>
    public interface IDetailsRequest : IRequest
    {
        /// <summary>Gets or sets the resource identifier.</summary>
        int Identifier { get; set; }
    }
}