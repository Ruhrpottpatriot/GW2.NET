// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventNameServiceRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for a list of events and their localized name.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.DynamicEvents.Names
{
    using GW2DotNET.V1.Common;

    /// <summary>Represents a request for a list of events and their localized name.</summary>
    public class DynamicEventNameServiceRequest : ServiceRequest
    {
        /// <summary>Initializes a new instance of the <see cref="DynamicEventNameServiceRequest" /> class.</summary>
        public DynamicEventNameServiceRequest()
            : base(Services.EventNames)
        {
        }
    }
}