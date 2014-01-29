// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataManager.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the IDataManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Infrastructure;

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
        string StoragePath { get; }

        /// <summary>Gets the dynamic events data. This property is lazy-initialized.</summary>
        DynamicEvents.DataProvider DynamicEventsData { get; }

        Items.DataProviders.ColourData ColourData { get; }

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
    }
}
