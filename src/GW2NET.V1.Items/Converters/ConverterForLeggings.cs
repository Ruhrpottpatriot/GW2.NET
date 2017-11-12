// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForLeggings.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ArmorDataContract" /> to objects of type <see cref="Leggings" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.Common;
using GW2NET.Items;
using GW2NET.V1.Items.Json;

namespace GW2NET.V1.Items.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="ArmorDataContract"/> to objects of type <see cref="Leggings"/>.</summary>
    internal sealed class ConverterForLeggings : IConverter<ArmorDataContract, Leggings>
    {
        /// <inheritdoc />
        public Leggings Convert(ArmorDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new Leggings();
        }
    }
}
