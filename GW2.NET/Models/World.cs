// --------------------------------------------------------------------------------------------------------------------
// <copyright file="World.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the World type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Models
{
    /// <summary>
    /// Represents a Guild Wars 2 world.
    /// </summary>
    public struct World
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="World"/> struct.
        /// </summary>
        /// <param name="id">The id of the world.</param>
        /// <param name="name">The name of the world.</param>
        public World(int id, string name)
            : this()
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// Gets the id of the world.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Gets the name of the world.
        /// </summary>
        public string Name { get; private set; }
    }
}
