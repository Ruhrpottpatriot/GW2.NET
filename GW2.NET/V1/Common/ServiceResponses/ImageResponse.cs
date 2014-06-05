// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageResponse.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an image response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Common.ServiceResponses
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Net;

    using GW2DotNET.Extensions;

    /// <summary>Represents an image response.</summary>
    public class ImageResponse : ServiceResponse<Image>
    {
        /// <summary>Initializes a new instance of the <see cref="ImageResponse"/> class.</summary>
        /// <param name="webResponse">The <see cref="System.Net.HttpWebResponse"/>.</param>
        public ImageResponse(HttpWebResponse webResponse)
            : base(webResponse)
        {
        }

        /// <summary>Gets the response content as an instance of the specified type.</summary>
        /// <param name="stream">The response stream.</param>
        /// <returns>The response content.</returns>
        protected override Image Deserialize(Stream stream)
        {
            if (!this.StatusCode.IsSuccessStatusCode())
            {
                // if the service returned an error code
                throw new InvalidOperationException("Unable to deserialize the response content: the service returned an error code.");
            }

            return Image.FromStream(stream);
        }
    }
}