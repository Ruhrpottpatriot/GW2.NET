// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventCollectionConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="EventCollectionDTO" /> to objects of type <see cref="T:ICollection{DynamicEvent}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Events.Converters
{
    using System;
    using System.Collections.Generic;
    using GW2NET.Common;
    using GW2NET.DynamicEvents;
    using GW2NET.V1.Events.Json;

    /// <summary>Converts objects of type <see cref="EventCollectionDTO"/> to objects of type <see cref="T:ICollection{DynamicEvent}"/>.</summary>
    public sealed class DynamicEventCollectionConverter : IConverter<EventCollectionDTO, ICollection<DynamicEvent>>
    {
        private readonly IConverter<EventDTO, DynamicEvent> dynamicEventConverter;

        /// <summary>Initializes a new instance of the <see cref="DynamicEventCollectionConverter"/> class.</summary>
        /// <param name="dynamicEventConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public DynamicEventCollectionConverter(IConverter<EventDTO, DynamicEvent> dynamicEventConverter)
        {
            if (dynamicEventConverter == null)
            {
                throw new ArgumentNullException("dynamicEventConverter");
            }

            this.dynamicEventConverter = dynamicEventConverter;
        }

        /// <inheritdoc />
        public ICollection<DynamicEvent> Convert(EventCollectionDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var eventDTOs = value.Events;
            if (eventDTOs == null)
            {
                return new List<DynamicEvent>(0);
            }

            var dynamicEvents = new List<DynamicEvent>(eventDTOs.Count);
            foreach (var kvp in eventDTOs)
            {
                Guid eventId;
                if (!Guid.TryParse(kvp.Key, out eventId))
                {
                    continue;
                }

                var dynamicEvent = this.dynamicEventConverter.Convert(kvp.Value, state);
                if (dynamicEvent == null)
                {
                    continue;
                }

                dynamicEvent.EventId = eventId;
                dynamicEvents.Add(dynamicEvent);
            }

            return dynamicEvents;
        }
    }
}