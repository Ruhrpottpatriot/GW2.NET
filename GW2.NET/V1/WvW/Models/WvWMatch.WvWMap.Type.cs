// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WvWMatch.WvWMap.Type.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a world vs world match.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.WvW.Models
{
    /// <summary>
    /// Represents a world vs world match.
    /// </summary>
    public partial struct WvWMatch
    {
        /// <summary>
        /// Represents a world vs world map.
        /// </summary>
        public partial struct WvWMap
        {
            /// <summary>
            /// Enumerates the objective type.
            /// </summary>
            public enum Type
            {
                /// <summary>
                /// The red home.
                /// </summary>
                RedHome,

                /// <summary>
                /// The blue home.
                /// </summary>
                BlueHome,

                /// <summary>
                /// The green home.
                /// </summary>
                GreenHome,

                /// <summary>
                /// The center.
                /// </summary>
                Center
            }
        }
    }
}