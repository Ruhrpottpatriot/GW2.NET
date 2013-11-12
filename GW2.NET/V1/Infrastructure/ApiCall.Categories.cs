// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiCall.Categories.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ApiCall type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Infrastructure
{
    /// <summary>Contains static methods to call the guild wars 2 API.</summary>
    public static partial class ApiCall
    {
        // --------------------------------------------------------------------------------------------------------------------
        // Enumerations
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Enumerates the possible categories a request can be.
        /// </summary>
        public enum Categories
        {
            /// <summary>
            /// The world part of the API.
            /// Includes world names, map names and events
            /// </summary>
            World,

            /// <summary>
            /// The world versus world part of the API.
            /// </summary>
            WvW,

            /// <summary>
            /// The items part of the API
            /// </summary>
            Items,

            /// <summary>
            /// The guild part of the api.
            /// </summary>
            Guild,

            /// <summary>
            /// The miscellaneous part of the api.
            /// </summary>
            Miscellaneous
        }
    }
}
