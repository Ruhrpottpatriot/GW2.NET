// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForFood.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract" /> to objects of type <see cref="Food" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items.Converters
{
    using System;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Items.Consumables;
    using GW2NET.V2.Items.Json;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="Food"/>.</summary>
    internal sealed class ConverterForFood : IConverter<DetailsDataContract, Food>
    {
        /// <summary>Converts the given object of type <see cref="DetailsDataContract"/> to an object of type <see cref="Food"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Food Convert(DetailsDataContract value)
        {
            Contract.Assume(value != null);
            var food = new Food();

            // Set the duration
            var duration = value.Duration;
            if (duration.HasValue)
            {
                food.Duration = TimeSpan.FromMilliseconds(duration.Value);
            }

            // Set the effect description
            food.Effect = value.Description;

            return food;
        }
    }
}