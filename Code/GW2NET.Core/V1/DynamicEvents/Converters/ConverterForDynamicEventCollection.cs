// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForDynamicEventCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="EventCollectionDataContract" /> to objects of type <see cref="T:ICollection{DynamicEvent}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.DynamicEvents
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.DynamicEvents;

    /// <summary>Converts objects of type <see cref="EventCollectionDataContract"/> to objects of type <see cref="T:ICollection{DynamicEvent}"/>.</summary>
    internal sealed class ConverterForDynamicEventCollection : IConverter<EventCollectionDataContract, ICollection<DynamicEvent>>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<EventDataContract, DynamicEvent> converterForDynamicEvent;

        /// <summary>Initializes a new instance of the <see cref="ConverterForDynamicEventCollection"/> class.</summary>
        public ConverterForDynamicEventCollection()
            : this(new ConverterForDynamicEvent())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForDynamicEventCollection"/> class.</summary>
        /// <param name="converterForDynamicEvent">The converter for <see cref="DynamicEvent"/>.</param>
        public ConverterForDynamicEventCollection(IConverter<EventDataContract, DynamicEvent> converterForDynamicEvent)
        {
            Contract.Requires(converterForDynamicEvent != null);
            this.converterForDynamicEvent = converterForDynamicEvent;
        }

        /// <summary>Converts the given object of type <see cref="EventCollectionDataContract"/> to an object of type <see cref="T:ICollection{DynamicEvent}"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public ICollection<DynamicEvent> Convert(EventCollectionDataContract value)
        {
            Contract.Assume(value != null);
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

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForDynamicEvent != null);
        }
    }
}