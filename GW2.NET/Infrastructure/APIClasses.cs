// --------------------------------------------------------------------------------------------------------------------
// <copyright file="APIClasses.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Contains simple classes for deserialization of JSON data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2DotNET.Infrastructure
{
    /// <summary>
    /// An item returned by a call to event_names.json
    /// </summary>
    public class APIEventName
    {
        public Guid id { get; set; }
        public string name { get; set; }
    }

    /// <summary>
    /// An item returned by a call to world_names.json
    /// </summary>
    public class APIWorldName
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    /// <summary>
    /// An item returned by a call to events.json
    /// </summary>
    public class APIEvent
    {
        public int world_id { get; set; }
        public int map_id { get; set; }
        public Guid event_id { get; set; }
        public APIEventState state { get; set; }
    }

    public enum APIEventState
    {
        Active,
        Success,
        Fail,
        Warmup,
        Preparation
    }
}
