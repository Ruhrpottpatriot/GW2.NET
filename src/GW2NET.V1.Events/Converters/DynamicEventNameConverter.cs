// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventNameConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="EventNameDTO" /> to objects of type <see cref="DynamicEventName" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using GW2NET.Common;
using GW2NET.DynamicEvents;
using GW2NET.V1.Events.Json;

namespace GW2NET.V1.Events.Converters
{
    /// <summary>Converts objects of type <see cref="EventNameDTO"/> to objects of type <see cref="DynamicEventName"/>.</summary>
    public sealed class DynamicEventNameConverter : IConverter<EventNameDTO, DynamicEventName>
    {       
        /// <inheritdoc />
        public DynamicEventName Convert(EventNameDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
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