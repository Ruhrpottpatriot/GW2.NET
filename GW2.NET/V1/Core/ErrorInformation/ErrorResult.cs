// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorResult.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ErrorInformation
{
    /// <summary>
    /// Represents the result that is returned when an error occurs.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1"/> for more information.
    /// </remarks>
    public class ErrorResult : JsonObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResult"/> class.
        /// </summary>
        public ErrorResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResult"/> class using the specified values.
        /// </summary>
        /// <param name="error">The error number.</param>
        /// <param name="product">The product number.</param>
        /// <param name="module">The module number.</param>
        /// <param name="line">The line number.</param>
        /// <param name="text">The error message.</param>
        public ErrorResult(int error, int product, int module, int line, string text)
        {
            this.Error = error;
            this.Product = product;
            this.Module = module;
            this.Line = line;
            this.Text = text;
        }

        /// <summary>
        /// Gets or sets a number that indicates the error kind.
        /// </summary>
        [JsonProperty("error")]
        public int Error { get; set; }

        /// <summary>
        /// Gets or sets the line number on which the error occurred.
        /// </summary>
        [JsonProperty("line")]
        public int Line { get; set; }

        /// <summary>
        /// Gets or sets a number that represents the module in which the error occurred.
        /// </summary>
        [JsonProperty("module")]
        public int Module { get; set; }

        /// <summary>
        /// Gets or sets a number that represents the product in which the error occurred.
        /// </summary>
        [JsonProperty("product")]
        public int Product { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}