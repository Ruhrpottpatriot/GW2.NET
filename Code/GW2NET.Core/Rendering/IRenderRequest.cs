// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRenderRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for render service requests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Rendering
{
    using GW2NET.Common;

    /// <summary>Provides the interface for render service requests.</summary>
    public interface IRenderRequest : IRequest, IRenderable
    {
        /// <summary>Gets or sets the image format.</summary>
        string ImageFormat { get; set; }
    }
}