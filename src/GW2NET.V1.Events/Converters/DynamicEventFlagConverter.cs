// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventFlagConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="DynamicEventFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Events.Converters
{
    using System;
    using System.Diagnostics;
    using GW2NET.Common;
    using GW2NET.DynamicEvents;

    /// <summary>Converts objects of type <see cref="string" /> to objects of type <see cref="DynamicEventFlags" />.</summary>
    public sealed class DynamicEventFlagConverter : IConverter<string, DynamicEventFlags>
    {
        /// <inheritdoc />
        public DynamicEventFlags Convert(string value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            // MEMO: can't use Enum.Parse() because underscores violate naming conventions
            switch (value)
            {
                case @"group_event":
                    return DynamicEventFlags.GroupEvent;
                case @"map_wide":
                    return DynamicEventFlags.MapWide;
                case @"meta_event":
                    return DynamicEventFlags.MetaEvent;
                default:
                    Debug.Assert(false, "Unknown DynamicEventFlags: " + value);
                    return default(DynamicEventFlags);
            }
        }
    }
}