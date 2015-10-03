// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfusionSlotFlagCollectionConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
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
    public sealed class InfusionSlotFlagCollectionConverter : IConverter<ICollection<string>, InfusionSlotFlags>
    {
        private readonly IConverter<string, InfusionSlotFlags> infusionSlotFlagConverter;

        /// <summary>Initializes a new instance of the <see cref="InfusionSlotFlagCollectionConverter"/> class.</summary>
        /// <param name="infusionSlotFlagConverter">The converter for <see cref="InfusionSlotFlags"/>.</param>
        public InfusionSlotFlagCollectionConverter(IConverter<string, InfusionSlotFlags> infusionSlotFlagConverter)
        {
            if (infusionSlotFlagConverter == null)
            {
                throw new ArgumentNullException("infusionSlotFlagConverter");
            }

            this.infusionSlotFlagConverter = infusionSlotFlagConverter;
        }

        /// <inheritdoc />
        public InfusionSlotFlags Convert(ICollection<string> value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var result = default(InfusionSlotFlags);
            foreach (var s in value)
            {
                result |= this.infusionSlotFlagConverter.Convert(s, value);
            }

            return result;
        }
    }
}