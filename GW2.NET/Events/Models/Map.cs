// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Map.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a map/region in the game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Events.Models
{
    /// <summary>
    /// Represents a map/region in the game.
    /// </summary>
    public struct Map
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> struct.
        /// </summary>
        /// <param name="id">The map id.</param>
        /// <param name="name">The map name.</param>
        public Map(int id, string name)
            : this()
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// Gets the map id.
        /// </summary>
        public int Id
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the map name.
        /// </summary>
        public string Name
        {
            get;
            private set;
        }
    }
}
