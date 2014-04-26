﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemCollectionResult.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Wraps a collection of item identifiers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Contracts
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Types;

    /// <summary>Wraps a collection of item identifiers.</summary>
    public class ItemCollectionResult : JsonObject
    {
        /// <summary>Gets or sets a collection of item identifiers.</summary>
        [DataMember(Name = "items", Order = 0)]
        public ItemCollection Items { get; set; }
    }
}