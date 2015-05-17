// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForDynamicEvent.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="EventDataContract" /> to objects of type <see cref="DynamicEvent" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2NET.Common;
using GW2NET.DynamicEvents;
using GW2NET.V1.Events.Json;

namespace GW2NET.V1.Events.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="EventDataContract"/> to objects of type <see cref="DynamicEvent"/>.</summary>
    internal sealed class ConverterForDynamicEvent : IConverter<EventDataContract, DynamicEvent>
    {
        private readonly IConverter<ICollection<string>, DynamicEventFlags> converterForDynamicEventFlags;

        private readonly IConverter<LocationDataContract, Location> converterForLocation;

        /// <summary>Initializes a new instance of the <see cref="ConverterForDynamicEvent"/> class.</summary>
        public ConverterForDynamicEvent()
            : this(new ConverterForDynamicEventFlagCollection(), new ConverterForLocation())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForDynamicEvent"/> class.</summary>
        /// <param name="converterForDynamicEventFlags">The converter for <see cref="DynamicEventFlags"/>.</param>
        /// <param name="converterForLocation">The converter for <see cref="Location"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForDynamicEventFlags"/> or <paramref name="converterForLocation"/> is a null reference.</exception>
        public ConverterForDynamicEvent(IConverter<ICollection<string>, DynamicEventFlags> converterForDynamicEventFlags, IConverter<LocationDataContract, Location> converterForLocation)
        {
            if (converterForDynamicEventFlags == null)
            {
                throw new ArgumentNullException("converterForDynamicEventFlags", "Precondition: converterForDynamicEventFlags != null");
            }

            if (converterForLocation == null)
            {
                throw new ArgumentNullException("converterForLocation", "Precondition: converterForLocation != null");
            }

            this.converterForDynamicEventFlags = converterForDynamicEventFlags;
            this.converterForLocation = converterForLocation;
        }

        /// <inheritdoc />
        public DynamicEvent Convert(EventDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var dynamicEvent = new DynamicEvent
            {
                Name = value.Name, 
                Level = value.Level, 
                MapId = value.MapId
            };

            var flags = value.Flags;
            if (flags != null)
            {
                dynamicEvent.Flags = this.converterForDynamicEventFlags.Convert(flags);
            }

            var location = value.Location;
            if (location != null)
            {
                dynamicEvent.Location = this.converterForLocation.Convert(location);
            }

            return dynamicEvent;
        }
    }
}