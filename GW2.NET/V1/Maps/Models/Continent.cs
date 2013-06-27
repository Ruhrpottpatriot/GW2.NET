// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Continent.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Continent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Maps.Models
{
    /// <summary>Represents a continent.</summary>
    public struct Continent
    {
        /// <summary>Initializes a new instance of the <see cref="Continent"/> struct.</summary>
        /// <param name="name">The name.</param>
        /// <param name="continentDims">The continent dims.</param>
        /// <param name="minimumZoom">The minimum zoom.</param>
        /// <param name="maximumZoom">The maximum zoom.</param>
        /// <param name="floors">The floors.</param>
        [JsonConstructor]
        public Continent(string name, int[] continentDims, int minimumZoom, int maximumZoom, int[] floors)
            : this()
        {
            this.Floors = floors;
            this.MaximumZoom = maximumZoom;
            this.MinimumZoom = minimumZoom;
            this.ContinentDims = continentDims;
            this.Name = name;
        }

        /// <summary>Gets the id.</summary>
        public int Id
        {
            get;
            private set;
        }

        /// <summary>Gets the name.</summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            private set;
        }

        /// <summary>Gets the continent dims.</summary>
        [JsonProperty("continent_dims")]
        public int[] ContinentDims
        {
            get;
            private set;
        }

        /// <summary>Gets the minimum zoom.</summary>
        [JsonProperty("min_zoom")]
        public int MinimumZoom
        {
            get;
            private set;
        }

        /// <summary>Gets the maximum zoom.</summary>
        [JsonProperty("max_zoom")]
        public int MaximumZoom
        {
            get;
            private set;
        }

        /// <summary>Gets the floors.</summary>
        [JsonProperty("floors")]
        public int[] Floors
        {
            get;
            private set;
        }

        /// <summary>Resolves the id for the continent.</summary>
        /// <param name="idToResolve">The id to resolve.</param>
        /// <returns>The <see cref="Continent"/> with a resolved id.</returns>
        internal Continent ResolveId(int idToResolve)
        {
            var newContinent = this;

            newContinent.Id = idToResolve;

            return newContinent;
        }
    }
}
