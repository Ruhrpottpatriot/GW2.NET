namespace GW2NET.V1.Items.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="ContainerDataContract"/> to objects of type <see cref="ImmediateContainer"/>.</summary>
    internal sealed class ConverterForImmediateContainer : IConverter<ContainerDataContract, ImmediateContainer>
    {
        /// <inheritdoc />
        public ImmediateContainer Convert(ContainerDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new ImmediateContainer();
        }
    }
}
