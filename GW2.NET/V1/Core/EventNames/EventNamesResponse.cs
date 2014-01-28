// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventNamesResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2DotNET.V1.Core.EventNames.Converters;
using GW2DotNET.V1.Core.EventNames.Models;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.EventNames
{
    /// <summary>
    /// Represents a response that is the result of an <see cref="EventNamesRequest"/>.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names"/> for more information.
    /// </remarks>
    [JsonConverter(typeof(EventNamesResponseConverter))]
    public class EventNamesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventNamesResponse"/> class.
        /// </summary>
        public EventNamesResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventNamesResponse"/> class.
        /// </summary>
        /// <param name="eventNames">The list of localized event names.</param>
        public EventNamesResponse(IEnumerable<DynamicEventName> eventNames)
        {
            this.EventNames = eventNames;
        }

        /// <summary>
        /// Gets or sets a list of localized event names.
        /// </summary>
        public IEnumerable<DynamicEventName> EventNames { get; set; }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <param name="indent">A value that indicates whether to indent the output.</param>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public string ToString(bool indent)
        {
            return JsonConvert.SerializeObject(this, indent ? Formatting.Indented : Formatting.None);
        }
    }
}