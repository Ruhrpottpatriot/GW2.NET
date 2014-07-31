// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUpgrade.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for items that provide a bonus when equipped.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Items
{
    /// <summary>Provides the interface for items that provide a bonus when equipped.</summary>
    public interface IUpgrade
    {
        /// <summary>Gets or sets the buff.</summary>
        ItemBuff Buff { get; set; }

        /// <summary>Gets or sets the Condition Damage modifier.</summary>
        int ConditionDamage { get; set; }

        /// <summary>Gets or sets the Ferocity modifier.</summary>
        int Ferocity { get; set; }

        /// <summary>Gets or sets the Healing modifier.</summary>
        int Healing { get; set; }

        /// <summary>Gets or sets the Power modifier.</summary>
        int Power { get; set; }

        /// <summary>Gets or sets the Precision modifier.</summary>
        int Precision { get; set; }

        /// <summary>Gets or sets the Toughness modifier.</summary>
        int Toughness { get; set; }

        /// <summary>Gets or sets the Vitality modifier.</summary>
        int Vitality { get; set; }
    }
}