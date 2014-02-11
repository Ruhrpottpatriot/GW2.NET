// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataManager.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the IDataManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.MapInformation.Models;

namespace GW2DotNET.V1
{
    /// <summary>Exposes properties and methods which allow the user to query 
    /// and manipulate data coming from the Guild Wars 2 api.</summary>
    public interface IDataManager
    {
        // --------------------------------------------------------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Gets or sets the language.</summary>
        Language Language { get; set; }

        /// <summary>
        /// Gets the game build.
        /// </summary>
        int Build { get; }

        /// <summary>
        /// Gets the path to the cache.
        /// </summary>
        string SavePath { get; }

        /// <summary>Gets the dynamic events data. This property is lazy-initialized.</summary>
        DynamicEvents.DataProvider DynamicEventsData { get; }

        /// <summary>Gets the guilds data.</summary>
        Guilds.DataProvider GuildsData { get; }

        /// <summary>Gets the colour data.</summary>
        Items.DataProviders.ColourData ColourData { get; }

        /// <summary>Gets the item dara data.</summary>
        Items.DataProviders.ItemData ItemData { get; }

        /// <summary>Gets the recipe data.</summary>
        Items.DataProviders.RecipeData RecipeData { get; }

        /// <summary>Gets the continent data.</summary>
        MapInformation.DataProvider.ContinentData ContinentData { get; }

        /// <summary>Gets the map floor data.</summary>
        MapInformation.DataProvider.MapFloorData MapFloorData { get; }

        /// <summary>Gets the maps data.</summary>
        MapInformation.DataProvider.MapsData MapsData { get; }

        /// <summary>Gets the wv w data.</summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        WvW.DataProvider WvWData { get; }

        // --------------------------------------------------------------------------------------------------------------------
        // Methods
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Gets the latest build from the server.</summary>
        /// <remarks>
        /// This function will query the server for the current build. 
        /// After a query this method will return the current build to the user.
        /// It will also store the new build in the <see cref="Build"/> property and therefore cache it.
        /// </remarks>
        /// <returns>An <see cref="T:System.Int32"/> containing the latest build.</returns>
        int GetLatestBuild();

        /// <summary>Completely clears the cache. There is no undo!</summary>
        void ClearCache();

        /// <summary>Changes the location the DataManager will store the written cache.</summary>
        /// <param name="newSavePath">The new location of the written cache.</param>
        /// <remarks><para>This method changes the location of the written cache 
        /// and moves the existing cache to it's new location.
        /// This method will not overwrite existing files. 
        /// If you want to overwrite existing files you have 
        /// to use the <see cref="ChangeSavePath(string,bool)"/> method.</para>
        /// <para>This method will check if the path ends with "GW2.NET". 
        /// If the path does not end with "GW2.NET" it will be added automatically.</para></remarks>
        void ChangeSavePath(string newSavePath);

        /// <summary>Changes the location the DataManager will store the written cache.</summary>
        /// <param name="newSavePath">The new location of the written cache.</param>
        /// <param name="overwriteExistingFiles">A value indicating whether we should overwrite existing files.</param>
        /// <remarks><para>This method will change the location of the data cache to the path specified in the method call.
        /// The user can also specify whether to overwrite existing files or not. If he does not the method will silently skip
        /// the move process, the user will get no feedback whether the file was actually moved.</para>
        /// <para>This method will check if the path ends with "GW2.NET". 
        /// If the path does not end with "GW2.NET" it will be added automatically.</para>
        /// </remarks>
        void ChangeSavePath(string newSavePath, bool overwriteExistingFiles);
    }
}
