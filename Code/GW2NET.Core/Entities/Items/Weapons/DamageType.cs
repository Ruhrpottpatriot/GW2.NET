// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DamageType.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the possible weapon damage types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Entities.Items
{
    /// <summary>Enumerates the possible weapon damage types.</summary>
    public enum DamageType
    {
        /// <summary>The 'Unknown' damage type.</summary>
        Unknown = 0, 

        /// <summary>The 'Fire' damage type.</summary>
        Fire = 1 << 0, 

        /// <summary>The 'Ice' damage type.</summary>
        Ice = 1 << 1, 

        /// <summary>The 'Lightning' damage type.</summary>
        Lightning = 1 << 2, 

        /// <summary>The 'Physical' damage type.</summary>
        Physical = 1 << 3, 

        /// <summary>The 'Choking' damage type.</summary>
        Choking = 1 << 4
    }
}