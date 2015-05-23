// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForImmediateConsumable.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ConsumableDataContract" /> to objects of type <see cref="ImmediateConsumable" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="ConsumableDataContract"/> to objects of type <see cref="ImmediateConsumable"/>.</summary>
    internal sealed class ConverterForImmediateConsumable : IConverter<ConsumableDataContract, ImmediateConsumable>
    {
        /// <inheritdoc />
        public ImmediateConsumable Convert(ConsumableDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var immediateConsumable = new ImmediateConsumable
            {
                Description = value.Description
            };

            double duration;
            if (double.TryParse(value.Duration, out duration))
            {
                immediateConsumable.Duration = TimeSpan.FromMilliseconds(duration);
            }

            return immediateConsumable;
        }
    }
}