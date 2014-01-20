// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IApiManager.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The ApiManager interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Events.DataProviders;
using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Infrastructure.Logging;
using GW2DotNET.V1.Items.DataProvider;
using GW2DotNET.V1.MapInformation.DataProvider;

namespace GW2DotNET.V1
{
    /// <summary>The ApiManager interface.</summary>
    public interface IApiManager
    {
        /// <summary>Gets the build.</summary>
        int Build { get; }

        /// <summary>Gets or sets the language.</summary>
        /// <remarks>This property sets the language.
        /// This will also clear the complete cache
        /// so the user will get the data from the api in the set language.</remarks>
        Language Language { get; set; }

        /// <summary>Gets the logger.</summary>
        IEventLogger Logger { get; }

        /// <summary>Gets the continent data.</summary>
        ContinentData Continents { get; }

        /// <summary>Gets the floor data.</summary>
        MapFloorData FloorData { get; }

        /// <summary>Gets the maps data.</summary>
        MapsData Maps { get; }

        /// <summary>
        /// Gets the ColourData object.
        /// </summary>
        ColourData Colours { get; }

        /// <summary>
        /// Gets the EventData object.
        /// </summary>
        EventData Events { get; }

        /// <summary>Gets the instance of the guild data provider.</summary>
        /// <remarks>This property is the entry point to the guild api.
        /// From here the user can access all the information the guild api has to offer.</remarks>
        /// <seealso cref="V1.Guilds.DataProvider"/>
        Guilds.DataProvider GuildData { get; }

        /// <summary>
        /// Gets the ItemData object.
        /// </summary>
        ItemData Items { get; }

        /// <summary>
        /// Gets the RecipeData object.
        /// </summary>
        RecipeData Recipes { get; }
        
        /// <summary>
        /// Gets the WorldData object.
        /// </summary>
        WorldData Worlds { get; }

        /// <summary>
        /// Clears the cache for all data providers.
        /// WARNING! there is  no undo!
        /// </summary>
        void ClearCache();

        /// <summary>Gets the latest build from the server.</summary>
        /// <remarks>
        /// This function will query the server for the current build. 
        /// After a query this method will return the current build to the user.
        /// It will also store the new build in the <see cref="ApiManager.Build"/> property and therefore cache it.
        /// </remarks>
        /// <returns>
        /// The latest build.
        /// </returns>
        int GetLatestBuild();
    }
}