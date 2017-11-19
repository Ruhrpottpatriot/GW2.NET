namespace GW2NET.V2.Items
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="AttributeDataContract"/> to objects of type <see cref="AgonyResistanceModifier"/>.</summary>
    internal sealed class ConverterForAgonyResistanceModifier : IConverter<AttributeDataContract, AgonyResistanceModifier>
    {
        /// <summary>Converts the given object of type <see cref="AttributeDataContract"/> to an object of type <see cref="AgonyResistanceModifier"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public AgonyResistanceModifier Convert(AttributeDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new AgonyResistanceModifier
            {
                Modifier = value.Modifier
            };
        }
    }
}
