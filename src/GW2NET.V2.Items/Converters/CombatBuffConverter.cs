// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CombatBuffConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="BuffDTO" /> to objects of type <see cref="CombatBuff" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Items.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V2.Items.Json;

    /// <summary>Converts objects of type <see cref="BuffDTO" /> to objects of type <see cref="CombatBuff" />.</summary>
    public sealed class CombatBuffConverter : IConverter<BuffDTO, CombatBuff>
    {
        /// <summary>Converts the given object of type <see cref="BuffDTO" /> to an object of type <see cref="CombatBuff" />.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public CombatBuff Convert(BuffDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return new CombatBuff { SkillId = value.SkillId, Description = value.Description };
        }
    }
}