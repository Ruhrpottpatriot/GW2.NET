// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRenderServiceClient.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for the render service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Rendering
{
    using System.Drawing;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides the interface for the render service.</summary>
    public interface IRenderServiceClient
    {
        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <returns>The response.</returns>
        Image Send(IRenderRequest request);

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <returns>The response.</returns>
        Task<Image> SendAsync(IRenderRequest request);

        /// <summary>Sends a request and returns the response.</summary>
        /// <param name="request">The service request.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        Task<Image> SendAsync(IRenderRequest request, CancellationToken cancellationToken);
    }
}