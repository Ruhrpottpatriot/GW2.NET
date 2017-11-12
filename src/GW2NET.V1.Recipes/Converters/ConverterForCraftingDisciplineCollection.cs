﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForCraftingDisciplineCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="CraftingDisciplines" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using GW2NET.Common;
using GW2NET.Recipes;

namespace GW2NET.V1.Recipes.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="CraftingDisciplines"/>.</summary>
    internal sealed class ConverterForCraftingDisciplineCollection : IConverter<ICollection<string>, CraftingDisciplines>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, CraftingDisciplines> converterForCraftingDiscipline;

        /// <summary>Initializes a new instance of the <see cref="ConverterForCraftingDisciplineCollection"/> class.</summary>
        internal ConverterForCraftingDisciplineCollection()
            : this(new ConverterForCraftingDiscipline())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForCraftingDisciplineCollection"/> class.</summary>
        /// <param name="converterForCraftingDiscipline">The converter for <see cref="CraftingDisciplines"/></param>
        internal ConverterForCraftingDisciplineCollection(IConverter<string, CraftingDisciplines> converterForCraftingDiscipline)
        {
            if (converterForCraftingDiscipline == null)
            {
                throw new ArgumentNullException("converterForCraftingDiscipline", "Precondition: converterForCraftingDiscipline != null");
            }

            this.converterForCraftingDiscipline = converterForCraftingDiscipline;
        }

        /// <summary>Converts the given object of type <see cref="T:ICollection{string}"/> to an object of type <see cref="CraftingDisciplines"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public CraftingDisciplines Convert(ICollection<string> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            CraftingDisciplines result = default(CraftingDisciplines);
            foreach (var s in value)
            {
                result |= this.converterForCraftingDiscipline.Convert(s);
            }

            return result;
        }
    }
}