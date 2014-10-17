// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Identity.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides contextual information about a player's avatar.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.MumbleLink
{
    using GW2NET.Common;
    using GW2NET.Entities.Colors;
    using GW2NET.Entities.Maps;
    using GW2NET.Entities.Worlds;

    /// <summary>Provides contextual information about a player's avatar.</summary>
    public sealed class Identity
    {
        /// <summary>Gets or sets a value indicating whether the avatar is commanding a squad.</summary>
        public bool Commander { get; set; }

        /// <summary>Gets or sets the current map. This is a navigation property. Use the value of <see cref="MapId"/> to obtain a reference.</summary>
        public Map Map { get; set; }

        /// <summary>Gets or sets the identifier of the current map.</summary>
        public int MapId { get; set; }

        /// <summary>Gets or sets the name of the avatar.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the avatar's profession.</summary>
        public Profession Profession { get; set; }

        /// <summary>Gets or sets the current team color. This is a navigation property. Use the value of <see cref="TeamColorId"/> to obtain a reference.</summary>
        public ColorPalette TeamColor { get; set; }

        /// <summary>Gets or sets the identifier of the current team color.</summary>
        public int TeamColorId { get; set; }

        /// <summary>Gets or sets the current world. This is a navigation property. Use the value of <see cref="WorldId"/> to obtain a reference.</summary>
        public World World { get; set; }

        /// <summary>Gets or sets the identifier of the current world.</summary>
        public long WorldId { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}