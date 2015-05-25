// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForInfixUpgrade.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="InfixUpgradeDataContract" /> to objects of type <see cref="InfixUpgrade" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="InfixUpgradeDataContract"/> to objects of type <see cref="InfixUpgrade"/>.</summary>
    internal sealed class ConverterForInfixUpgrade : IConverter<InfixUpgradeDataContract, InfixUpgrade>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<AttributeDataContract>, ICollection<CombatAttribute>> converterForCombatAttributeCollection;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<CombatBuffDataContract, CombatBuff> converterForCombatBuff;

        /// <summary>Initializes a new instance of the <see cref="ConverterForInfixUpgrade"/> class.</summary>
        public ConverterForInfixUpgrade()
            : this(new ConverterForCollection<AttributeDataContract, CombatAttribute>(new ConverterForCombatAttribute()), new ConverterForCombatBuff())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForInfixUpgrade"/> class.</summary>
        /// <param name="converterForCombatAttributeCollection">The converter for <see cref="ICollection{CombatAttribute}"/>.</param>
        /// <param name="converterForCombatBuff">The converter for <see cref="CombatBuff"/>.</param>
        public ConverterForInfixUpgrade(IConverter<ICollection<AttributeDataContract>, ICollection<CombatAttribute>> converterForCombatAttributeCollection, IConverter<CombatBuffDataContract, CombatBuff> converterForCombatBuff)
        {
            if (converterForCombatAttributeCollection == null)
            {
                throw new ArgumentNullException("converterForCombatAttributeCollection", "Precondition: converterForCombatAttributeCollection != null");
            }

            if (converterForCombatBuff == null)
            {
                throw new ArgumentNullException("converterForCombatBuff", "Precondition: converterForCombatBuff != null");
            }

            this.converterForCombatAttributeCollection = converterForCombatAttributeCollection;
            this.converterForCombatBuff = converterForCombatBuff;
        }

        /// <inheritdoc />
        public InfixUpgrade Convert(InfixUpgradeDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var infixUpgrade = new InfixUpgrade();
            var buffDataContract = value.Buff;
            if (buffDataContract != null)
            {
                infixUpgrade.Buff = this.converterForCombatBuff.Convert(buffDataContract, state);
            }

            var attributeDataContracts = value.Attributes;
            if (attributeDataContracts != null)
            {
                infixUpgrade.Attributes = this.converterForCombatAttributeCollection.Convert(attributeDataContracts, state);
            }

            return infixUpgrade;
        }
    }
}