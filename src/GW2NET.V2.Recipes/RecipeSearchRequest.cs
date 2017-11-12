// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeSearchRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a search request that targets the /v2/recipes/search interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Recipes
{
    using System.Collections.Generic;
    using System.Globalization;

    using GW2NET.Common;

    /// <summary>Represents a search request that targets the /v2/recipes/search interface.</summary>
    internal sealed class RecipeSearchRequest : IRequest
    {
        /// <inheritdoc />
        string IRequest.Resource
        {
            get
            {
                return @"/v2/recipes/search";
            }
        }

        /// <summary>Gets or sets the input item identifier.</summary>
        internal int? Input { get; set; }

        /// <summary>Gets or sets the output item identifier.</summary>
        internal int? Output { get; set; }

        /// <inheritdoc />
        IEnumerable<KeyValuePair<string, string>> IRequest.GetParameters()
        {
            var input = this.Input;
            if (input.HasValue)
            {
                yield return new KeyValuePair<string, string>("input", input.Value.ToString(NumberFormatInfo.InvariantInfo));
            }

            var output = this.Output;
            if (output.HasValue)
            {
                yield return new KeyValuePair<string, string>("output", output.Value.ToString(NumberFormatInfo.InvariantInfo));
            }
        }

        /// <inheritdoc />
        IEnumerable<string> IRequest.GetPathSegments()
        {
            yield break;
        }
    }
}
