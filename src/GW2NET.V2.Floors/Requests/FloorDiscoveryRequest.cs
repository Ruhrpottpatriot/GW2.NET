// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FloorDiscoveryRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a discovery request against the /v2/floors interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Floors
{
    using System.Collections.Generic;
    using System.Globalization;

    using GW2NET.Common;

    /// <summary>Represents a discovery request against the /v2/floors interface.</summary>
    internal sealed class FloorDiscoveryRequest : DiscoveryRequest
    {
        /// <summary>Gets or sets the continent id.</summary>
        public int ContinentId { get; set; }

        /// <summary>Gets the resource path.</summary>
        public override string Resource
        {
            get
            {
                return "/v2/floors/{0}/";
            }
        }

        /// <summary>Gets additional path segments for the targeted resource.</summary>
        /// <returns>A collection of path segments.</returns>
        public override IEnumerable<string> GetPathSegments()
        {
            return new List<string> { this.ContinentId.ToString(NumberFormatInfo.InvariantInfo) };
        }
    }
}