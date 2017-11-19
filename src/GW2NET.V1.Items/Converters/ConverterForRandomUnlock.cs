namespace GW2NET.V1.Items.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="ConsumableDataContract"/> to objects of type <see cref="RandomUnlock"/>.</summary>
    internal sealed class ConverterForRandomUnlock : IConverter<ConsumableDataContract, RandomUnlock>
    {
        /// <inheritdoc />
        public RandomUnlock Convert(ConsumableDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new RandomUnlock();
        }
    }
}
