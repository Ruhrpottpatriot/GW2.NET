// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GatherinToolConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="GatheringToolSkin"/>.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;

namespace GW2NET.V2.Skins
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Skins;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="GatheringToolSkin"/>.</summary>
    internal sealed class GatherinToolConverter : IConverter<DetailsDataContract, GatheringToolSkin>
    {
        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<DetailsDataContract, GatheringToolSkin>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="GatherinToolConverter"/> class.</summary>
        public GatherinToolConverter()
            : this(GetKnownTypeConverters())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="GatherinToolConverter"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="typeConverters"/> is a null reference.</exception>
        public GatherinToolConverter(IDictionary<string, IConverter<DetailsDataContract, GatheringToolSkin>> typeConverters)
        {
            if (typeConverters == null)
            {
                throw new ArgumentNullException("typeConverters", "Precondition: typeConverters != null");
            }

            this.typeConverters = typeConverters;
        }

        /// <inheritdoc />
        public GatheringToolSkin Convert(DetailsDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            IConverter<DetailsDataContract, GatheringToolSkin> converter;

            GatheringToolSkin skin;
            if (this.typeConverters.TryGetValue(value.Type, out converter))
            {
                skin = converter.Convert(value);
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
        private static IDictionary<string, IConverter<DetailsDataContract, GatheringToolSkin>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<DetailsDataContract, GatheringToolSkin>>
                       {
                           { "Foraging", new ConverterForObject<ForagingToolSkin>() },
                           { "Mining", new ConverterForObject<MiningToolSkin>() },
                           { "Logging", new ConverterForObject<LoggingToolSkin>() },
                       };
        }
    }
}
