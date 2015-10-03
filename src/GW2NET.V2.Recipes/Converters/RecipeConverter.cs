// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="RecipeDTO" /> to objects of type <see cref="Recipe" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Recipes.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.Recipes;
    using GW2NET.V2.Recipes.Json;

    public partial class RecipeConverter
    {
        private readonly IConverter<ICollection<string>, CraftingDisciplines> craftingDisciplineCollectionConverter;

        private readonly IConverter<ICollection<IngredientDTO>, ICollection<ItemQuantity>> ingredientsCollectionConverter;

        private readonly IConverter<ICollection<string>, RecipeFlags> recipeFlagCollectionConverter;

        /// <summary>Initializes a new instance of the <see cref="RecipeConverter"/> class.</summary>
        /// <param name="converterFactory"></param>
        /// <param name="craftingDisciplineCollectionConverter">The converter for <see cref="CraftingDisciplines"/>.</param>
        /// <param name="recipeFlagCollectionConverter">The converter for <see cref="RecipeFlags"/>.</param>
        /// <param name="ingredientsCollectionConverter">The converter for <see cref="T:ICollection{ItemQuantity}"/>.</param>
        public RecipeConverter(
            ITypeConverterFactory<RecipeDTO, Recipe> converterFactory,
            IConverter<ICollection<string>, CraftingDisciplines> craftingDisciplineCollectionConverter,
            IConverter<ICollection<string>, RecipeFlags> recipeFlagCollectionConverter,
            IConverter<ICollection<IngredientDTO>, ICollection<ItemQuantity>> ingredientsCollectionConverter)
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

            if (ingredientsCollectionConverter == null)
            {
                throw new ArgumentNullException("ingredientsCollectionConverter");
            }

            this.craftingDisciplineCollectionConverter = craftingDisciplineCollectionConverter;
            this.recipeFlagCollectionConverter = recipeFlagCollectionConverter;
            this.ingredientsCollectionConverter = ingredientsCollectionConverter;
        }

        partial void Merge(Recipe entity, RecipeDTO dto, object state)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state", "Precondition: state is IResponse");
            }

            var response = state as IResponse;
            if (response == null)
            {
                throw new ArgumentException("Precondition: state is IResponse", "state");
            }

            entity.Culture = response.Culture;
            entity.RecipeId = dto.Id;
            entity.OutputItemId = dto.OutputItemId;
            entity.OutputItemCount = dto.OutputItemCount;
            entity.MinimumRating = dto.MinRating;
            entity.TimeToCraft = TimeSpan.FromMilliseconds(dto.TimeToCraftMs);

            if (dto.Disciplines != null)
            {
                entity.CraftingDisciplines = this.craftingDisciplineCollectionConverter.Convert(dto.Disciplines, dto);
            }

            if (dto.Flags != null)
            {
                entity.Flags = this.recipeFlagCollectionConverter.Convert(dto.Flags, dto);
            }

            if (dto.Ingredients != null)
            {
                entity.Ingredients = this.ingredientsCollectionConverter.Convert(dto.Ingredients, dto);
            }
        }
    }
}