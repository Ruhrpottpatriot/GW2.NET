// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForCombatBuff.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="BuffDataContract" /> to objects of type <see cref="CombatBuff" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="BuffDataContract"/> to objects of type <see cref="CombatBuff"/>.</summary>
    internal sealed class ConverterForItemBuff : IConverter<BuffDataContract, CombatBuff>
    {
        /// <summary>Converts the given object of type <see cref="BuffDataContract"/> to an object of type <see cref="CombatBuff"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public CombatBuff Convert(BuffDataContract value)
        {
            Contract.Assume(value != null);
            return new CombatBuff
            {
                SkillId = value.SkillId, 
                Description = value.Description
            };
        }
    }
}