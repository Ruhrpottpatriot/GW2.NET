// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Recipe.Ingredient.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The recipe model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Items.Models
{
    /// <summary>The recipe model.</summary>
    public partial class Recipe
    {
        /// <summary>The ingredients of a recipe.</summary>
        public class Ingredient : IEquatable<Ingredient>
        {
            /// <summary>The id of the ingredient.</summary>
            private readonly int id;

            /// <summary>Initializes a new instance of the <see cref="Ingredient"/> class.</summary>
            /// <param name="id">The id of the ingredient.</param>
            /// <param name="count">The ingredient count.</param>
            [JsonConstructor]
            public Ingredient(int id, int count)
            {
                this.id = id;
                this.Count = count;
            }

            /// <summary>Gets the id of the ingredient.</summary>
            [JsonProperty("item_id")]
            public int Id
            {
                get
                {
                    return this.id;
                }
            }

            /// <summary>Gets the ingredient count.</summary>
            [JsonProperty("count")]
            public int Count { get; private set; }

            /// <summary>Indicates whether this instance and the specified <see cref="Ingredient"/> are equal.</summary>
            /// <returns>true if <paramref name="ingredient"/> and this instance are the same type and represent the same value; otherwise, false.</returns>
            /// <param name="ingredient">Another object to compare to. </param>
            public bool Equals(Ingredient ingredient)
            {
                if ((object)ingredient == null)
                {
                    return false;
                }

                return this.Id == ingredient.Id;
            }

            /// <summary>Determines whether two specified instances of <see crdef="Ingredient" /> are equal.</summary>
            /// <param name="ingredientA">The first object to compare.</param>
            /// param>
            /// <param name="ingredientB">The second object to compare. </param>
            /// <returns>true if ingredientA and ingredientB represent the same ingredient; otherwise, false.</returns>
            public static bool operator ==(Ingredient ingredientA, Ingredient ingredientB)
            {
                if (ReferenceEquals(ingredientA, ingredientB))
                {
                    return true;
                }

                if (((object)ingredientA == null) || ((object)ingredientB == null))
                {
                    return false;
                }

                return ingredientA.Id == ingredientB.Id;
            }

            /// <summary>Determines whether two specified instances of <see crdef="Ingredient" /> are not equal.</summary>
            /// <param name="ingredientA">The first object to compare.</param>
            /// param>
            /// <param name="ingredientB">The second object to compare. </param>
            /// <returns>true if ingredientA and ingredientB do not represent the same ingredient; otherwise, false.</returns>
            public static bool operator !=(Ingredient ingredientA, Ingredient ingredientB)
            {
                return !(ingredientA == ingredientB);
            }

            /// <summary>Indicates whether this instance and a specified object are equal.</summary>
            /// <returns>true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.</returns>
            /// <param name="obj">Another object to compare to. </param>
            /// <filterpriority>2</filterpriority>
            public override bool Equals(object obj)
            {
                // If parameter is null return false.
                if (obj == null)
                {
                    return false;
                }

                // If parameter cannot be cast to Point return false.
                Ingredient ingredient = obj as Ingredient;

                if ((object)ingredient == null)
                {
                    return false;
                }

                return this.Id == ingredient.Id;
            }

            /// <summary>Returns the hash code for this instance.</summary>
            /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
            public override int GetHashCode()
            {
                return this.id.GetHashCode();
            }
        }
    }
}