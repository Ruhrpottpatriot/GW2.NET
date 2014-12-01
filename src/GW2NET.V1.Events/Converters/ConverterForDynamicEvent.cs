// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForDynamicEvent.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="EventDataContract" /> to objects of type <see cref="DynamicEvent" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.DynamicEvents;
using GW2NET.V1.Events.Json;

namespace GW2NET.V1.Events.Converters
{
    /// <summary>Converts objects of type <see cref="EventDataContract"/> to objects of type <see cref="DynamicEvent"/>.</summary>
    internal sealed class ConverterForDynamicEvent : IConverter<EventDataContract, DynamicEvent>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<string>, DynamicEventFlags> converterForDynamicEventFlags;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<LocationDataContract, Location> converterForLocation;

        /// <summary>Initializes a new instance of the <see cref="ConverterForDynamicEvent"/> class.</summary>
        public ConverterForDynamicEvent()
            : this(new ConverterForDynamicEventFlagCollection(), new ConverterForLocation())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForDynamicEvent"/> class.</summary>
        /// <param name="converterForDynamicEventFlags">The converter for <see cref="DynamicEventFlags"/>.</param>
        /// <param name="converterForLocation">The converter for <see cref="Location"/>.</param>
        public ConverterForDynamicEvent(IConverter<ICollection<string>, DynamicEventFlags> converterForDynamicEventFlags, IConverter<LocationDataContract, Location> converterForLocation)
        {
            Contract.Requires(converterForDynamicEventFlags != null);
            Contract.Requires(converterForLocation != null);
            this.converterForDynamicEventFlags = converterForDynamicEventFlags;
            this.converterForLocation = converterForLocation;
        }

        /// <summary>Converts the given object of type <see cref="EventDataContract"/> to an object of type <see cref="DynamicEvent"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public DynamicEvent Convert(EventDataContract value)
        {
            Contract.Assume(value != null);
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

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForDynamicEventFlags != null);
            Contract.Invariant(this.converterForLocation != null);
        }
    }
}