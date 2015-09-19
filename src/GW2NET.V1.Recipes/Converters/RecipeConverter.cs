// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="RecipeDTO" /> to objects of type <see cref="Recipe" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Recipes.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.Recipes;
    using GW2NET.V1.Recipes.Json;

    /// <summary>Converts objects of type <see cref="RecipeDTO"/> to objects of type <see cref="Recipe"/>.</summary>
    public partial class RecipeConverter
    {
        private readonly IConverter<ICollection<string>, CraftingDisciplines> craftingDisciplineCollectionConverter;

        private readonly IConverter<ICollection<IngredientDTO>, ICollection<ItemQuantity>> itemQuantityCollectionConverter;

        private readonly IConverter<ICollection<string>, RecipeFlags> recipeFlagCollectionConverter;

        /// <summary>Initializes a new instance of the <see cref="RecipeConverter"/> class.</summary>
        /// <param name="converterFactory"></param>
        /// <param name="craftingDisciplineCollectionConverter">The converter for <see cref="CraftingDisciplines"/>.</param>
        /// <param name="recipeFlagCollectionConverter">The converter for <see cref="RecipeFlags"/>.</param>
        /// <param name="itemQuantityCollectionConverter">The converter for <see cref="T:ICollection{ItemQuantity}"/>.</param>
        public RecipeConverter(ITypeConverterFactory<RecipeDTO, Recipe> converterFactory,
            IConverter<ICollection<string>, CraftingDisciplines> craftingDisciplineCollectionConverter,
            IConverter<ICollection<string>, RecipeFlags> recipeFlagCollectionConverter,
            IConverter<ICollection<IngredientDTO>, ICollection<ItemQuantity>> itemQuantityCollectionConverter)
            : this(converterFactory)
        {
            if (craftingDisciplineCollectionConverter == null)
            {
                throw new ArgumentNullException("craftingDisciplineCollectionConverter");
            }

            if (recipeFlagCollectionConverter == null)
            {
                throw new ArgumentNullException("recipeFlagCollectionConverter");
            }

            if (itemQuantityCollectionConverter == null)
            {
                throw new ArgumentNullException("itemQuantityCollectionConverter");
            }

            this.craftingDisciplineCollectionConverter = craftingDisciplineCollectionConverter;
            this.recipeFlagCollectionConverter = recipeFlagCollectionConverter;
            this.itemQuantityCollectionConverter = itemQuantityCollectionConverter;
        }

        /// <inheritdoc />
        partial void Merge(Recipe entity, RecipeDTO dto, object state)
        {
            int recipeId;
            if (int.TryParse(dto.RecipeId, out recipeId))
            {
                entity.RecipeId = recipeId;
            }

            int outputItemId;
            if (int.TryParse(dto.OutputItemId, out outputItemId))
            {
                entity.OutputItemId = outputItemId;
            }

            int outputItemCount;
            if (int.TryParse(dto.OutputItemCount, out outputItemCount))
            {
                entity.OutputItemCount = outputItemCount;
            }

            int minimumRating;
            if (int.TryParse(dto.MinimumRating, out minimumRating))
            {
                entity.MinimumRating = minimumRating;
            }

            double timeToCraft;
            if (double.TryParse(dto.TimeToCraft, out timeToCraft))
            {
                entity.TimeToCraft = TimeSpan.FromMilliseconds(timeToCraft);
            }

            var craftingDisciplines = dto.CraftingDisciplines;
            if (craftingDisciplines != null)
            {
                entity.CraftingDisciplines = this.craftingDisciplineCollectionConverter.Convert(craftingDisciplines, state);
            }

            var flags = dto.Flags;
            if (flags != null)
            {
                entity.Flags = this.recipeFlagCollectionConverter.Convert(flags, state);
            }

            var ingredients = dto.Ingredients;
            if (ingredients != null)
            {
                entity.Ingredients = this.itemQuantityCollectionConverter.Convert(ingredients, state);
            }
        }
    }
}