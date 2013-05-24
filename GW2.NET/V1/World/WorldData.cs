// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the WorldData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.World.Models;

namespace GW2DotNET.V1.World
{
    /// <summary>
    /// Contains methods to get and modify the world data.
    /// </summary>
    internal class WorldData
    {
        /// <summary>
        /// Gets all <see cref="GwWorld"/> from the api.
        /// </summary>
        /// <param name="language">The language to get the worlds in. Default is english.</param>
        /// ReSharper disable CSharpWarnings::CS1584
        /// <returns>A <see cref="IList"/> containing all world objects.
        /// ReSharper restore CSharpWarnings::CS1584
        /// </returns>
        internal IList<GwWorld> GetWorlds(Language language = Language.En)
        {
            var arguments = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("lang", language.ToString())
            };

            return ApiCall.GetContent<List<GwWorld>>("world_names.json", arguments, ApiCall.Categories.World);
        }
    }
}
