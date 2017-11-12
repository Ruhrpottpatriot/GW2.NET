// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForAmulet.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="TrinketDataContract" /> to objects of type <see cref="Amulet" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.Common;
using GW2NET.Items;
using GW2NET.V1.Items.Json;

namespace GW2NET.V1.Items.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="TrinketDataContract"/> to objects of type <see cref="Amulet"/>.</summary>
    internal sealed class ConverterForAmulet : IConverter<TrinketDataContract, Amulet>
    {
        /// <inheritdoc />
        public Amulet Convert(TrinketDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new Amulet();
        }
    }
}