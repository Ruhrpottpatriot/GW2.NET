// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForRing.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="TrinketDataContract" /> to objects of type <see cref="Ring" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.Items;
using GW2NET.V1.Items.Json;

namespace GW2NET.V1.Items.Converters
{
    /// <summary>Converts objects of type <see cref="TrinketDataContract"/> to objects of type <see cref="Ring"/>.</summary>
    internal sealed class ConverterForRing : IConverter<TrinketDataContract, Ring>
    {
        /// <summary>Converts the given object of type <see cref="TrinketDataContract"/> to an object of type <see cref="Ring"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Ring Convert(TrinketDataContract value)
        {
            Contract.Assume(value != null);
            return new Ring();
        }
    }
}