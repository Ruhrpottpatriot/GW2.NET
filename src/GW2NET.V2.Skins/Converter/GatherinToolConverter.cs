// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GatherinToolConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="GatheringToolSkin"/>.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Converter
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Common;
    using Json;
    using Skins;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="GatheringToolSkin"/>.</summary>
    internal sealed class GatherinToolConverter : IConverter<DetailsDTO, GatheringToolSkin>
    {
        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<DetailsDTO, GatheringToolSkin>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="GatherinToolConverter"/> class.</summary>
        public GatherinToolConverter()
            : this(GetKnownTypeConverters())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="GatherinToolConverter"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="typeConverters"/> is a null reference.</exception>
        public GatherinToolConverter(IDictionary<string, IConverter<DetailsDTO, GatheringToolSkin>> typeConverters)
        {
            this.typeConverters = typeConverters ?? throw new ArgumentNullException(nameof(typeConverters), "Precondition: typeConverters != null");
        }

        /// <inheritdoc />
        public GatheringToolSkin Convert(DetailsDTO value, object state = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            GatheringToolSkin skin;
            if (this.typeConverters.TryGetValue(value.Type, out var converter))
            {
                skin = converter.Convert(value, state);
            }
            else
            {
                Debug.Assert(false, "Unknown type discriminator: " + value.Type);
                skin = new UnknownGatheringToolSkin();
            }

            return skin;
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<DetailsDTO, GatheringToolSkin>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<DetailsDTO, GatheringToolSkin>>
                       {
                           //{ "Foraging", new ConverterForObject<ForagingToolSkin>() }, 
                           //{ "Mining", new ConverterForObject<MiningToolSkin>() }, 
                           //{ "Logging", new ConverterForObject<LoggingToolSkin>() }, 
                       };
        }
    }
}