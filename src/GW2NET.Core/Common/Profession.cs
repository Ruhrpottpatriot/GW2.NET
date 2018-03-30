// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Profession.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the known professions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    /// <summary>
    /// Enumerates the known professions.
    /// </summary>
    public enum Profession
    {
        /// <summary>Indicates an unknown profession.</summary>
        Unknown = 0,

        /// <summary>The 'Guardian' profession.</summary>
        Guardian = 1 << 0,

        /// <summary>The 'Warrior' profession.</summary>
        Warrior = 1 << 1,

        /// <summary>The 'Engineer' profession.</summary>
        Engineer = 1 << 2,

        /// <summary>The 'Ranger' profession.</summary>
        Ranger = 1 << 3,

        /// <summary>The 'Thief' profession.</summary>
        Thief = 1 << 4,

        /// <summary>The 'Elementalist' profession.</summary>
        Elementalist = 1 << 5,

        /// <summary>The 'Mesmer' profession.</summary>
        Mesmer = 1 << 6,

        /// <summary>The 'Necromancer' profession.</summary>
        Necromancer = 1 << 7,

        /// <summary>The 'Revenant' profession.</summary>
        Revenant = 1 << 8
    }
}