// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForDynamicEventCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="EventCollectionDataContract" /> to objects of type <see cref="T:ICollection{DynamicEvent}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using GW2NET.Common;
using GW2NET.DynamicEvents;
using GW2NET.V1.Events.Json;

namespace GW2NET.V1.Events.Converters
{
    /// <summary>Converts objects of type <see cref="EventCollectionDataContract"/> to objects of type <see cref="T:ICollection{DynamicEvent}"/>.</summary>
    internal sealed class ConverterForDynamicEventCollection : IConverter<EventCollectionDataContract, ICollection<DynamicEvent>>
    {
        private readonly IConverter<EventDataContract, DynamicEvent> converterForDynamicEvent;

        /// <summary>Initializes a new instance of the <see cref="ConverterForDynamicEventCollection"/> class.</summary>
        public ConverterForDynamicEventCollection()
            : this(new ConverterForDynamicEvent())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForDynamicEventCollection"/> class.</summary>
        /// <param name="converterForDynamicEvent">The converter for <see cref="DynamicEvent"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForDynamicEvent"/> is a null reference.</exception>
        public ConverterForDynamicEventCollection(IConverter<EventDataContract, DynamicEvent> converterForDynamicEvent)
        {
            if (converterForDynamicEvent == null)
            {
                throw new ArgumentNullException("converterForDynamicEvent", "Precondition: converterForDynamicEvent != null");
            }

            this.converterForDynamicEvent = converterForDynamicEvent;
        }

        /// <inheritdoc />
        public ICollection<DynamicEvent> Convert(EventCollectionDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var eventDataContracts = value.Events;
            if (eventDataContracts == null)
            {
                return new List<DynamicEvent>(0);
            }

            var dynamicEvents = new List<DynamicEvent>(eventDataContracts.Count);
            foreach (var kvp in eventDataContracts)
            {
                Guid eventId;
                if (!Guid.TryParse(kvp.Key, out eventId))
                {
                    continue;
                }

                var dynamicEvent = this.converterForDynamicEvent.Convert(kvp.Value);
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