// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForRecipeFlagCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="RecipeFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Recipes.Converters
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

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
        internal ConverterForRecipeFlagCollection(IConverter<string, RecipeFlags> converterForRecipeFlag)
        {
            this.converterForRecipeFlag = converterForRecipeFlag;
        }

        /// <summary>Converts the given object of type <see cref="T:ICollection{string}"/> to an object of type <see cref="RecipeFlags"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public RecipeFlags Convert(ICollection<string> value)
        {
            Contract.Assume(value != null);
            RecipeFlags result = default(RecipeFlags);
            foreach (var s in value)
            {
                result |= this.converterForRecipeFlag.Convert(s);
            }

            return result;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForRecipeFlag != null);
        }
    }
}