// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an image response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RestSharp.GW2DotNET.ServiceResponses
{
    using System;
    using System.Drawing;
    using System.IO;

    /// <summary>Represents an image response.</summary>
    public class ImageResponse : ServiceResponse<Image>
    {
        /// <summary>Initializes a new instance of the <see cref="ImageResponse"/> class.</summary>
        /// <param name="restResponse">The <see cref="IRestResponse"/>.</param>
        public ImageResponse(IRestResponse restResponse)
            : base(restResponse)
        {
        }

        /// <summary>Gets the response content as an instance of the specified type.</summary>
        /// <param name="stream">The response stream.</param>
        /// <returns>The response content.</returns>
        protected override Image Deserialize(Stream stream)
        {
            if (!this.IsSuccessStatusCode)
            {
                // if the service returned an error code
                throw new InvalidOperationException("Unable to deserialize the response content: the service returned an error code.");
            }

            return Image.FromStream(stream);
        }
    }
}