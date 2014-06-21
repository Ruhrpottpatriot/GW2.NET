// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ingredient.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a portion of crafting ingredients.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes.Details.Contracts
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;
    using GW2DotNET.V1.Items.Details.Contracts;

    /// <summary>Represents a portion of crafting ingredients.</summary>
    public class Ingredient : JsonObject
    {
        /// <summary>Gets or sets the number of ingredients.</summary>
        [DataMember(Name = "count", Order = 1)]
        public virtual int Count { get; set; }

        /// <summary>Gets or sets the ingredient.</summary>
        public virtual Item Item { get; set; }

        /// <summary>Gets or sets the ingredient's identifier.</summary>
        [DataMember(Name = "item_id", Order = 0)]
        public virtual int ItemId { get; set; }

        /// <summary>Gets or sets the ingredient's language.</summary>
        [DataMember(Name = "lang", Order = 2)]
        public virtual string Language { get; set; }
    }
}