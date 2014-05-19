// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemsResult.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Wraps a collection of item IDs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Contracts;
    using GW2DotNET.V1.Items.Contracts;

    /// <summary>Wraps a collection of item IDs.</summary>
    public sealed class ItemsResult : JsonObject
    {
        /// <summary>Gets or sets a collection of item IDs.</summary>
        [DataMember(Name = "items")]
        public ItemCollection Items { get; set; }
    }
}