// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Character.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents the character of a Guild Wars 2 player.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Characters
{
    using System;
    using GW2NET.Common;

    /// <summary>Represents the character of a Guild Wars 2 player.</summary>
    public class Character
    {
        /// <summary>Gets or sets the name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the race.</summary>
        public Race Race { get; set; }

        /// <summary>Gets or sets the gender.</summary>
        public Gender Gender { get; set; }

        /// <summary>Gets or sets the profession.</summary>
        public Profession Profession { get; set; }

        /// <summary>Gets or sets the level.</summary>
        public short Level { get; set; }

        /// <summary>Gets or sets the guild.</summary>
        public Guid Guild { get; set; }
    }
}