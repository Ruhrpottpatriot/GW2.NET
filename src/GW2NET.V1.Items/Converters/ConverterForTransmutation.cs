// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForTransmutation.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ConsumableDataContract" /> to objects of type <see cref="Transmutation" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="ConsumableDataContract"/> to objects of type <see cref="Transmutation"/>.</summary>
    internal sealed class ConverterForTransmutation : IConverter<ConsumableDataContract, Transmutation>
    {
        /// <inheritdoc />
        public Transmutation Convert(ConsumableDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var item = new Transmutation();
            if (value.Skins == null)
            {
                item.SkinIds = new List<int>(0);
            }
            else
            {
                var values = new List<int>(value.Skins.Length);
                values.AddRange(value.Skins);
                item.SkinIds = values;
            }

            return item;
        }
    }
}