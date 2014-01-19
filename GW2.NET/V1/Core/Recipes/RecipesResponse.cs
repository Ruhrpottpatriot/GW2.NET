// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipesResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.Recipes
{
    /// <summary>
    /// Represents a response that is the result of a <see cref="RecipesRequest"/>.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes"/> for more information.
    /// </remarks>
    public class RecipesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecipesResponse"/> class.
        /// </summary>
        public RecipesResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipesResponse"/> class using the specified values.
        /// </summary>
        /// <param name="recipes">The list of discovered recipes.</param>
        public RecipesResponse(IEnumerable<int> recipes)
        {
            this.Recipes = recipes;
        }

        /// <summary>
        /// Gets or sets the list of discovered recipes.
        /// </summary>
        [JsonProperty("recipes", Order = 0)]
        public IEnumerable<int> Recipes { get; set; }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <param name="indent">A value that indicates whether to indent the output.</param>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public string ToString(bool indent)
        {
            return JsonConvert.SerializeObject(this, indent ? Formatting.Indented : Formatting.None);
        }
    }
}