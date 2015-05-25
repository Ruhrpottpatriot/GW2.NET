// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForRecipeFlagCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="RecipeFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Recipes
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Recipes;

    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="RecipeFlags"/>.</summary>
    internal sealed class ConverterForRecipeFlagCollection : IConverter<ICollection<string>, RecipeFlags>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, RecipeFlags> converterForRecipeFlag;

        /// <summary>Initializes a new instance of the <see cref="ConverterForRecipeFlagCollection"/> class.</summary>
        internal ConverterForRecipeFlagCollection()
            : this(new ConverterForRecipeFlag())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForRecipeFlagCollection"/> class.</summary>
        /// <param name="converterForRecipeFlag">The converter for <see cref="RecipeFlags"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForRecipeFlag"/> is a null reference.</exception>
        internal ConverterForRecipeFlagCollection(IConverter<string, RecipeFlags> converterForRecipeFlag)
        {
            if (converterForRecipeFlag == null)
            {
                throw new ArgumentNullException("converterForRecipeFlag", "Precondition: converterForRecipeFlag != null");
            }

            this.converterForRecipeFlag = converterForRecipeFlag;
        }

        /// <inheritdoc />
        public RecipeFlags Convert(ICollection<string> value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            RecipeFlags result = default(RecipeFlags);
            foreach (var s in value)
            {
                result |= this.converterForRecipeFlag.Convert(s, state);
            }

            return result;
        }
    }
}