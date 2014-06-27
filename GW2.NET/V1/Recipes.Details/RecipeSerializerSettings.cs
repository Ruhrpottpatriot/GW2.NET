// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeSerializerSettings.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The recipe details serializer settings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes.Details
{
    using GW2DotNET.V1.Common.Converters;
    using GW2DotNET.V1.Recipes.Details.Converters;

    using Newtonsoft.Json;

    /// <summary>The recipe details serializer settings.</summary>
    public class RecipeSerializerSettings : JsonSerializerSettings
    {
        /// <summary>Initializes a new instance of the <see cref="RecipeSerializerSettings"/> class.</summary>
        public RecipeSerializerSettings()
        {
            this.Converters.Add(new RecipeConverter());
            this.Converters.Add(new JsonTimespanConverter());
        }
    }
}