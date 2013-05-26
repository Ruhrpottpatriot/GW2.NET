// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the WorldData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.World.Models;

namespace GW2DotNET.V1.World
{
    /// <summary>
    /// Contains methods to get and modify the world data.
    /// </summary>
    public class WorldData : IEnumerable<GwWorld>
    {
        /// <summary>
        /// Cache the world_names list here
        /// </summary>
        private List<GwWorld> gwWorldCache = null;

        /// <summary>
        /// The world names will be retrieved in this language
        /// </summary>
        private Language language;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldData"/> class.
        /// This should only be called by WorldManager.
        /// </summary>
        /// <param name="language">The language in which to return world names</param>
        internal WorldData(Language language)
        {
            this.language = language;
        }

        /// <summary>
        /// Gets all <see cref="GwWorld"/> from the API.
        /// </summary>
        /// ReSharper disable CSharpWarnings::CS1584
        /// <returns>A <see cref="IList"/> containing all world objects.
        /// ReSharper restore CSharpWarnings::CS1584
        /// </returns>
        private IList<GwWorld> Worlds
        {
            get
            {
                if (this.gwWorldCache == null)
                {
                    var arguments = new List<KeyValuePair<string, object>>
                    {
                        new KeyValuePair<string, object>("lang", this.language.ToString())
                    };

                    this.gwWorldCache = ApiCall.GetContent<List<GwWorld>>("world_names.json", arguments, ApiCall.Categories.World);
                }

                return this.gwWorldCache;
            }
        }

        /// <summary>
        /// Gets a world by world ID
        /// </summary>
        /// <param name="worldID">The ID of the world</param>
        /// <returns>A GwWorld</returns>
        public GwWorld this[int worldID]
        {
            get
            {
                return (from n in this.Worlds where n.Id == worldID select n).Single();
            }
        }

        /// <summary>
        /// Gets a world by name
        /// </summary>
        /// <param name="name">The name of the world</param>
        /// <returns>A GwWorld</returns>
        public GwWorld this[string name]
        {
            get
            {
                return (from n in this.Worlds where n.Name == name select n).Single();
            }
        }

        /// <summary>
        /// IEnumerable<> implementation
        /// </summary>
        /// <returns>An enumerator</returns>
        public IEnumerator<GwWorld> GetEnumerator()
        {
            return this.Worlds.GetEnumerator();
        }

        /// <summary>
        /// IEnumerable implementation
        /// </summary>
        /// <returns>An enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Worlds.GetEnumerator();
        }
    }
}
