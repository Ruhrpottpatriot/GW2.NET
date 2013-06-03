// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemManager.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ItemManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Items.DataProvider;

namespace GW2DotNET.V1.Items
{
    /// <summary>
    /// Contains methods and properties to get and modify the items and recipes from the API.
    /// </summary>
    public class ItemManager
    {
        /// <summary>
        /// The color data provider.
        /// </summary>
        private ColourData colourData;

        /// <summary>
        /// The recipe data provider.
        /// </summary>
        private RecipeData recipeData;

        /// <summary>
        /// The item data provider.
        /// </summary>
        private ItemData itemData;

        /// <summary>
        /// The language.
        /// </summary>
        private Language language;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemManager"/> class.
        /// </summary>
        public ItemManager()
        {
            this.language = Language.En;
        }

        /// <summary>
        /// Gets the colours.
        /// </summary>
        public ColourData Colours
        {
            get
            {
                return this.colourData ?? (this.colourData = new ColourData());
            }
        }

        /// <summary>
        /// Gets all the recipes from the server.
        /// !!WARNING!! This will take very long, be aware of that.
        /// </summary>
        public RecipeData Recipes
        {
            get
            {
                return this.recipeData ?? (this.recipeData = new RecipeData());
            }
        }

        /// <summary>
        /// Gets the items from the server..
        /// </summary>
        /// <exception cref="NotImplementedException">This method is not yet implemented.
        /// </exception>
        public ItemData Items
        {
            get
            {
                return this.itemData ?? (this.itemData = new ItemData());
            }
        }

        /// <summary>
        /// Gets or sets the language for the query.
        /// </summary>
        public Language Language
        {
            get
            {
                return this.language;
            }

            set
            {
                this.colourData = null;

                this.recipeData = null;

                this.itemData = null;

                this.language = value;
            }
        }
    }
}
