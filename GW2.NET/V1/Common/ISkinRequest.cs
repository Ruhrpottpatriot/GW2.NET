// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISkinRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for skin requests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Common
{
    using GW2DotNET.Common;

    /// <summary>Provides the interface for skin requests.</summary>
    public interface ISkinRequest : IRequest
    {
        /// <summary>Gets or sets the skin identifier.</summary>
        int? SkinId { get; set; }
    }
}