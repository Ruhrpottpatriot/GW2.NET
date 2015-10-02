// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Gender.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the gender possibilities of a character.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Characters
{
    /// <summary>Enumerates the possible genders of a character.</summary>
    public enum Gender
    {
        /// <summary>Indicates that the character's gender is unknown.</summary>
        Unknown = 0,

        /// <summary>Indicates that the character is a male.</summary>
        Male = 1 << 0,

        /// <summary>Indicates that the character is a female.</summary>
        Female = 1 << 1
    }
}