// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CombatBuffConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="CombatBuffDTO" /> to objects of type <see cref="CombatBuff" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="CombatBuffDTO"/> to objects of type <see cref="CombatBuff"/>.</summary>
    public sealed class CombatBuffConverter : IConverter<CombatBuffDTO, CombatBuff>
    {
        /// <inheritdoc />
        public CombatBuff Convert(CombatBuffDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

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