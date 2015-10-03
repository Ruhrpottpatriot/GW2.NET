// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfixUpgradeConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="InfixUpgradeDTO" /> to objects of type <see cref="InfixUpgrade" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="InfixUpgradeDTO"/> to objects of type <see cref="InfixUpgrade"/>.</summary>
    public sealed class InfixUpgradeConverter : IConverter<InfixUpgradeDTO, InfixUpgrade>
    {
        private readonly IConverter<ICollection<AttributeDTO>, ICollection<CombatAttribute>> combatAttributeCollectionConverter;

        private readonly IConverter<CombatBuffDTO, CombatBuff> combatBuffConverter;

        /// <summary>Initializes a new instance of the <see cref="InfixUpgradeConverter"/> class.</summary>
        /// <param name="combatAttributeCollectionConverter"></param>
        /// <param name="combatBuffConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public InfixUpgradeConverter(IConverter<ICollection<AttributeDTO>, ICollection<CombatAttribute>> combatAttributeCollectionConverter, IConverter<CombatBuffDTO, CombatBuff> combatBuffConverter)
        {
            if (combatAttributeCollectionConverter == null)
            {
                throw new ArgumentNullException("combatAttributeCollectionConverter");
            }

            if (combatBuffConverter == null)
            {
                throw new ArgumentNullException("combatBuffConverter");
            }

            this.combatAttributeCollectionConverter = combatAttributeCollectionConverter;
            this.combatBuffConverter = combatBuffConverter;
        }

        /// <inheritdoc />
        public InfixUpgrade Convert(InfixUpgradeDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var infixUpgrade = new InfixUpgrade();
            var buff = value.Buff;
            if (buff != null)
            {
                infixUpgrade.Buff = this.combatBuffConverter.Convert(buff, value);
            }

            var attributes = value.Attributes;
            if (attributes != null)
            {
                infixUpgrade.Attributes = this.combatAttributeCollectionConverter.Convert(attributes, value);
            }

            return infixUpgrade;
        }
    }
}