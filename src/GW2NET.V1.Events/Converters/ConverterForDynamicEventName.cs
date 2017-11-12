// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForDynamicEventName.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="EventNameDataContract" /> to objects of type <see cref="DynamicEventName" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using GW2NET.Common;
using GW2NET.DynamicEvents;
using GW2NET.V1.Events.Json;

namespace GW2NET.V1.Events.Converters
{
    /// <summary>Converts objects of type <see cref="EventNameDataContract"/> to objects of type <see cref="DynamicEventName"/>.</summary>
    internal sealed class ConverterForDynamicEventName : IConverter<EventNameDataContract, DynamicEventName>
    {
        /// <inheritdoc />
        public DynamicEventName Convert(EventNameDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

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