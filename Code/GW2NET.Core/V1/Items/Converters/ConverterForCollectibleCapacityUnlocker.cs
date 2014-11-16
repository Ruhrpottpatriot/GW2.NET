// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForCollectibleCapacityUnlocker.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ConsumableDataContract" /> to objects of type <see cref="CollectibleCapacityUnlocker" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items.Converters
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Items.Consumables;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="ConsumableDataContract"/> to objects of type <see cref="CollectibleCapacityUnlocker"/>.</summary>
    internal sealed class ConverterForCollectibleCapacityUnlocker : IConverter<ConsumableDataContract, CollectibleCapacityUnlocker>
    {
        /// <summary>Converts the given object of type <see cref="ConsumableDataContract"/> to an object of type <see cref="CollectibleCapacityUnlocker"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public CollectibleCapacityUnlocker Convert(ConsumableDataContract value)
        {
            Contract.Assume(value != null);
            return new CollectibleCapacityUnlocker();
        }
    }
}