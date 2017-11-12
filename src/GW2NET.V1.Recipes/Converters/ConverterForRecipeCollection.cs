// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForRecipeCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="RecipeCollectionDataContract" /> to objects of type <see cref="T:ICollection{int}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using GW2NET.Common;
using GW2NET.Common.Converters;
using GW2NET.V1.Recipes.Json;

namespace GW2NET.V1.Recipes.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="RecipeCollectionDataContract"/> to objects of type <see cref="T:ICollection{int}"/>.</summary>
    internal sealed class ConverterForRecipeCollection : IConverter<RecipeCollectionDataContract, ICollection<int>>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<int>, ICollection<int>> converterForCollection;

        /// <summary>Initializes a new instance of the <see cref="ConverterForRecipeCollection"/> class.</summary>
        internal ConverterForRecipeCollection()
            : this(new ConverterAdapter<ICollection<int>>())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForRecipeCollection"/> class.</summary>
        /// <param name="converterForCollection">The converter for <see cref="T:ICollection{int}"/>.</param>
        internal ConverterForRecipeCollection(IConverter<ICollection<int>, ICollection<int>> converterForCollection)
        {
            if (converterForCollection == null)
            {
                throw new ArgumentNullException("converterForCollection", "Precondition: converterForCollection != null");
            }

            this.converterForCollection = converterForCollection;
        }

        /// <summary>Converts the given object of type <see cref="RecipeCollectionDataContract"/> to an object of type <see cref="T:ICollection{int}"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public ICollection<int> Convert(RecipeCollectionDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var values = value.Recipes;
            if (values == null)
            {
                return new List<int>(0);
            }

            return this.converterForCollection.Convert(values);
        }
    }
}