// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CombatAttribute.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for combat attribute modifiers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Items
{
    /// <summary>Provides the base class for combat attribute modifiers.</summary>
    public abstract class CombatAttribute
    {
        /// <summary>Gets or sets the modifier for the attribute.</summary>
        public virtual int Modifier { get; set; }
    }
}