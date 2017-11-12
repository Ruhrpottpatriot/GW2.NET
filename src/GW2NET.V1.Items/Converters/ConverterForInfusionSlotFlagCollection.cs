// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForInfusionSlotFlagCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="InfusionSlotFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="InfusionSlotFlags"/>.</summary>
    internal sealed class ConverterForInfusionSlotFlagCollection : IConverter<ICollection<string>, InfusionSlotFlags>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, InfusionSlotFlags> converterForInfusionSlotFlag;

        /// <summary>Initializes a new instance of the <see cref="ConverterForInfusionSlotFlagCollection"/> class.</summary>
        internal ConverterForInfusionSlotFlagCollection()
            : this(new ConverterForInfusionSlotFlag())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForInfusionSlotFlagCollection"/> class.</summary>
        /// <param name="converterForInfusionSlotFlag">The converter for <see cref="InfusionSlotFlags"/>.</param>
        internal ConverterForInfusionSlotFlagCollection(IConverter<string, InfusionSlotFlags> converterForInfusionSlotFlag)
        {
            if (converterForInfusionSlotFlag == null)
            {
                throw new ArgumentNullException("converterForInfusionSlotFlag", "Precondition: converterForInfusionSlotFlag != null");
            }

            this.converterForInfusionSlotFlag = converterForInfusionSlotFlag;
        }

        /// <inheritdoc />
        public InfusionSlotFlags Convert(ICollection<string> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var result = default(InfusionSlotFlags);
            foreach (var s in value)
            {
                result |= this.converterForInfusionSlotFlag.Convert(s);
            }

            return result;
        }
    }
}
