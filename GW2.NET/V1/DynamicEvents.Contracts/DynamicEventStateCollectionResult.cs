// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventStateCollectionResult.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Wraps a collection of dynamic events.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents.Contracts
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;

    /// <summary>Wraps a collection of dynamic events.</summary>
    public class DynamicEventStateCollectionResult : ServiceContract
    {
        /// <summary>Gets or sets a collection of event details.</summary>
        [DataMember(Name = "events")]
        public DynamicEventStateCollection Events { get; set; }
    }
}