// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForDynamicEventFlagCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="DynamicEventFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2NET.Common;
using GW2NET.DynamicEvents;

namespace GW2NET.V1.Events.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="DynamicEventFlags"/>.</summary>
    internal sealed class ConverterForDynamicEventFlagCollection : IConverter<ICollection<string>, DynamicEventFlags>
    {
        private readonly IConverter<string, DynamicEventFlags> converterForDynamicEventFlag;

        /// <summary>Initializes a new instance of the <see cref="ConverterForDynamicEventFlagCollection"/> class.</summary>
        public ConverterForDynamicEventFlagCollection()
            : this(new ConverterForDynamicEventFlag())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForDynamicEventFlagCollection"/> class.</summary>
        /// <param name="converterForDynamicEventFlag">The converter for <see cref="DynamicEventFlags"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForDynamicEventFlag"/> is a null reference.</exception>
        public ConverterForDynamicEventFlagCollection(IConverter<string, DynamicEventFlags> converterForDynamicEventFlag)
        {
            if (converterForDynamicEventFlag == null)
            {
                throw new ArgumentNullException("converterForDynamicEventFlag", "Precondition: converterForDynamicEventFlag != null");
            }

            this.converterForDynamicEventFlag = converterForDynamicEventFlag;
        }

        /// <inheritdoc />
        public DynamicEventFlags Convert(ICollection<string> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var result = default(DynamicEventFlags);
            foreach (var s in value)
            {
                result |= this.converterForDynamicEventFlag.Convert(s);
            }

            return result;
        }
    }
}