// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForUtility.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ConsumableDataContract" /> to objects of type <see cref="Utility" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items
{
    using System;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Items.Consumables;

    /// <summary>Converts objects of type <see cref="ConsumableDataContract"/> to objects of type <see cref="Utility"/>.</summary>
    internal sealed class ConverterForUtility : IConverter<ConsumableDataContract, Utility>
    {
        /// <summary>Converts the given object of type <see cref="ConsumableDataContract"/> to an object of type <see cref="Utility"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Utility Convert(ConsumableDataContract value)
        {
            Contract.Assume(value != null);
            var utility = new Utility
            {
                Description = value.Description
            };

            double duration;
            if (double.TryParse(value.Duration, out duration))
            {
                utility.Duration = TimeSpan.FromMilliseconds(duration);
            }

            return utility;
        }
    }
}