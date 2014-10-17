// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TeamColor.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates known team colors.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Entities.WorldVersusWorld
{
    /// <summary>Enumerates known team colors.</summary>
    public enum TeamColor
    {
        /// <summary>An unknown team color.</summary>
        Unknown = 0, 

        /// <summary>The blue team color.</summary>
        Blue = 1 << 0, 

        /// <summary>The green team color.</summary>
        Green = 1 << 1, 

        /// <summary>The red team color.</summary>
        Red = 1 << 2, 

        /// <summary>The neutral color.</summary>
        Neutral = 1 << 3
    }
}