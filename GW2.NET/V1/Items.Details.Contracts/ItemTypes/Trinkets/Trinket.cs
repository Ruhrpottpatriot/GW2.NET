// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Trinket.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a trinket.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Trinkets
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    /// <summary>Represents a trinket.</summary>
    public abstract class Trinket : CombatItem
    {
        /// <summary>Gets the name of the property that provides additional information.</summary>
        /// <returns>The name of the property.</returns>
        protected override string GetTypeKey()
        {
            return "trinket";
        }
    }
}