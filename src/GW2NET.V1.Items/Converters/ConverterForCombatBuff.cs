// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForCombatBuff.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="CombatBuffDataContract" /> to objects of type <see cref="CombatBuff" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.Items;
using GW2NET.V1.Items.Json;

namespace GW2NET.V1.Items.Converters
{
    /// <summary>Converts objects of type <see cref="CombatBuffDataContract"/> to objects of type <see cref="CombatBuff"/>.</summary>
    internal sealed class ConverterForCombatBuff : IConverter<CombatBuffDataContract, CombatBuff>
    {
        /// <summary>Converts the given object of type <see cref="CombatBuffDataContract"/> to an object of type <see cref="CombatBuff"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public CombatBuff Convert(CombatBuffDataContract value)
        {
            Contract.Assume(value != null);
            var itemBuff = new CombatBuff
            {
                Description = value.Description
            };

            int skillId;
            if (int.TryParse(value.SkillId, out skillId))
            {
                itemBuff.SkillId = skillId;
            }

            return itemBuff;
        }
    }
}