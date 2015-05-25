// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForRing.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="TrinketDataContract" /> to objects of type <see cref="Ring" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="TrinketDataContract"/> to objects of type <see cref="Ring"/>.</summary>
    internal sealed class ConverterForRing : IConverter<TrinketDataContract, Ring>
    {
        /// <inheritdoc />
        public Ring Convert(TrinketDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new Ring();
        }
    }
}