// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventFlags.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates known dynamic event flags.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.DynamicEvents
{
    using System;

    /// <summary>Enumerates known dynamic event flags.</summary>
    [Flags]
    public enum DynamicEventFlags
    {
        /// <summary>Indicates no additional flags.</summary>
        None = 0,

        /// <summary>The 'group event' flag.</summary>
        GroupEvent = 1 << 0,

        /// <summary>The 'map-wide' event flag.</summary>
        MapWide = 1 << 1,

        /// <summary>The 'meta event' event flag.</summary>
        MetaEvent = 1 << 2
    }
}