// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a plain text response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.RestSharp.ServiceResponses
{
    using System.IO;
    using System.Text;

    using global::RestSharp;

    /// <summary>Represents a plain text response.</summary>
    public class TextResponse : ServiceResponse<string>
    {
        /// <summary>Initializes a new instance of the <see cref="TextResponse"/> class.</summary>
        /// <param name="restResponse">The <see cref="IRestResponse"/>.</param>
        public TextResponse(IRestResponse restResponse)
            : base(restResponse)
        {
        }

        /// <summary>Gets the response content as an instance of the specified type.</summary>
        /// <param name="stream">The response stream.</param>
        /// <returns>The response content.</returns>
        protected override string Deserialize(Stream stream)
        {
            var encoding = Encoding.GetEncoding(this.ContentType.CharSet);

            using (var streamReader = new StreamReader(stream, encoding))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}