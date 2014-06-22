// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRenderRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for render service requests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Rendering
{
    using GW2DotNET.Common;

    /// <summary>Provides the interface for render service requests.</summary>
    public interface IRenderRequest : IRequest
    {
        /// <summary>Gets or sets the file identifier.</summary>
        int FileId { get; set; }

        /// <summary>Gets or sets the file signature.</summary>
        string FileSignature { get; set; }

        /// <summary>Gets or sets the image format.</summary>
        string ImageFormat { get; set; }
    }
}