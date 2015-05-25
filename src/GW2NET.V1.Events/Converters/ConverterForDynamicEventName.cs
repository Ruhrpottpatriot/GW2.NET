// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForDynamicEventName.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="EventNameDataContract" /> to objects of type <see cref="DynamicEventName" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.DynamicEvents;
using GW2NET.V1.Events.Json;

namespace GW2NET.V1.Events.Converters
{
    /// <summary>Converts objects of type <see cref="EventNameDataContract"/> to objects of type <see cref="DynamicEventName"/>.</summary>
    internal sealed class ConverterForDynamicEventName : IConverter<EventNameDataContract, DynamicEventName>
    {
        /// <summary>Converts the given object of type <see cref="EventNameDataContract"/> to an object of type <see cref="DynamicEventName"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public DynamicEventName Convert(EventNameDataContract value)
        {
            Contract.Assume(value != null);
            var eventName = new DynamicEventName
            {
                Name = value.Name
            };

            Guid eventId;
            if (Guid.TryParse(value.Id, out eventId))
            {
                eventName.EventId = eventId;
            }

            return eventName;
        }
    }
}