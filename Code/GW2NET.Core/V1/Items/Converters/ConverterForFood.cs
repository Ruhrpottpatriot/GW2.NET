// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForFood.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ConsumableDataContract" /> to objects of type <see cref="Food" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items.Converters
{
    using System;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Items.Consumables;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="ConsumableDataContract"/> to objects of type <see cref="Food"/>.</summary>
    internal sealed class ConverterForFood : IConverter<ConsumableDataContract, Food>
    {
        /// <summary>Converts the given object of type <see cref="ConsumableDataContract"/> to an object of type <see cref="Food"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Food Convert(ConsumableDataContract value)
        {
            Contract.Assume(value != null);
            var food = new Food
            {
                Description = value.Description
            };

            double duration;
            if (double.TryParse(value.Duration, out duration))
            {
                food.Duration = TimeSpan.FromMilliseconds(duration);
            }

            return food;
        }
    }
}