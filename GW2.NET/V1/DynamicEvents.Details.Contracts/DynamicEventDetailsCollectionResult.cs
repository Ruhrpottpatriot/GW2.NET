// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventDetailsCollectionResult.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Wraps a collection of dynamic events and their details.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents.Details.Contracts
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Types;

    /// <summary>Wraps a collection of dynamic events and their details.</summary>
    public class DynamicEventDetailsCollectionResult : JsonObject
    {
        /// <summary>Gets or sets a list of details about dynamic events.</summary>
        [DataMember(Name = "events")]
        public DynamicEventDetailsCollection EventDetails { get; set; }
    }
}