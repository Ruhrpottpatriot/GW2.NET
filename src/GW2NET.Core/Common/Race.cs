// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Race.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the known races.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Common
{
    /// <summary>
    ///     Enumerates the known races.
    /// </summary>
    public enum Race
    {
        /// <summary>Indicates an unknown race.</summary>
        Unknown = 0,

        /// <summary>The 'Asura' race.</summary>
        Asura = 1 << 0,

        /// <summary>The 'Charr' race.</summary>
        Charr = 1 << 1,

        /// <summary>The 'Human' race.</summary>
        Human = 1 << 2,

        /// <summary>The 'Norn' race.</summary>
        Norn = 1 << 3,

        /// <summary>The 'Sylvari' race.</summary>
        Sylvari = 1 << 4
    }
}