// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="EventDTO" /> to objects of type <see cref="DynamicEvent" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Events.Converters
{
    using System;
    using System.Collections.Generic;
    using GW2NET.Common;
    using GW2NET.DynamicEvents;
    using GW2NET.V1.Events.Json;

    /// <summary>Converts objects of type <see cref="EventDTO"/> to objects of type <see cref="DynamicEvent"/>.</summary>
    public sealed class DynamicEventConverter : IConverter<EventDTO, DynamicEvent>
    {
        private readonly IConverter<ICollection<string>, DynamicEventFlags> dynamicEventFlagsConverter;

        private readonly IConverter<LocationDTO, Location> locationConverter;

        /// <summary>Initializes a new instance of the <see cref="DynamicEventConverter"/> class.</summary>
        /// <param name="dynamicEventFlagsConverter"></param>
        /// <param name="locationConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public DynamicEventConverter(IConverter<ICollection<string>, DynamicEventFlags> dynamicEventFlagsConverter, IConverter<LocationDTO, Location> locationConverter)
        {
            if (dynamicEventFlagsConverter == null)
            {
                throw new ArgumentNullException("dynamicEventFlagsConverter");
            }

            if (locationConverter == null)
            {
                throw new ArgumentNullException("locationConverter");
            }

            this.dynamicEventFlagsConverter = dynamicEventFlagsConverter;
            this.locationConverter = locationConverter;
        }

        /// <inheritdoc />
        public DynamicEvent Convert(EventDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
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
                dynamicEvent.Flags = this.dynamicEventFlagsConverter.Convert(flags, state);
            }

            var location = value.Location;
            if (location != null)
            {
                dynamicEvent.Location = this.locationConverter.Convert(location, state);
            }

            return dynamicEvent;
        }
    }
}