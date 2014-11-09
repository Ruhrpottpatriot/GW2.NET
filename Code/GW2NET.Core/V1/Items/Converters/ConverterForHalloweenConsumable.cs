// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForHalloweenConsumable.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ConsumableDataContract" /> to objects of type <see cref="HalloweenConsumable" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items.Converters
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="ConsumableDataContract"/> to objects of type <see cref="HalloweenConsumable"/>.</summary>
    internal sealed class ConverterForHalloweenConsumable : IConverter<ConsumableDataContract, HalloweenConsumable>
    {
        /// <summary>Converts the given object of type <see cref="ConsumableDataContract"/> to an object of type <see cref="HalloweenConsumable"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public HalloweenConsumable Convert(ConsumableDataContract value)
        {
            Contract.Assume(value != null);
            return new HalloweenConsumable();
        }
    }
}