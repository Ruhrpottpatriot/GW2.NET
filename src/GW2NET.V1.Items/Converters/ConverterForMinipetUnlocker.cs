namespace GW2NET.V1.Items.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="ConsumableDataContract"/> to objects of type <see cref="MinipetUnlocker"/>.</summary>
    internal sealed class ConverterForMinipetUnlocker : IConverter<ConsumableDataContract, MinipetUnlocker>
    {
        /// <inheritdoc />
        public MinipetUnlocker Convert(ConsumableDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new MinipetUnlocker();
        }
    }
}
