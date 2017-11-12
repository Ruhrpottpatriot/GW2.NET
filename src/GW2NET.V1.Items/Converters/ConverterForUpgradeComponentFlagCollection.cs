// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForUpgradeComponentFlagCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="UpgradeComponentFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="UpgradeComponentFlags"/>.</summary>
    internal sealed class ConverterForUpgradeComponentFlagCollection : IConverter<ICollection<string>, UpgradeComponentFlags>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, UpgradeComponentFlags> converterForUpgradeComponentFlag;

        /// <summary>Initializes a new instance of the <see cref="ConverterForUpgradeComponentFlagCollection"/> class.</summary>
        public ConverterForUpgradeComponentFlagCollection()
            : this(new ConverterForUpgradeComponentFlag())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForUpgradeComponentFlagCollection"/> class.</summary>
        /// <param name="converterForUpgradeComponentFlag">The converter for <see cref="UpgradeComponentFlags"/>.</param>
        public ConverterForUpgradeComponentFlagCollection(IConverter<string, UpgradeComponentFlags> converterForUpgradeComponentFlag)
        {
            if (converterForUpgradeComponentFlag == null)
            {
                throw new ArgumentNullException("converterForUpgradeComponentFlag", "Precondition: converterForUpgradeComponentFlag != null");
            }

            this.converterForUpgradeComponentFlag = converterForUpgradeComponentFlag;
        }

        /// <inheritdoc />
        public UpgradeComponentFlags Convert(ICollection<string> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var result = default(UpgradeComponentFlags);
            foreach (var s in value)
            {
                result |= this.converterForUpgradeComponentFlag.Convert(s);
            }

            return result;
        }
    }
}
