// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for details regarding maps in the game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps
{
    using System.Globalization;

    using GW2DotNET.Common;
    using GW2DotNET.V1.Common;

    /// <summary>Represents a request for details regarding maps in the game.</summary>
    public class MapRequest : IMapRequest, ILocalizable
    {
        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <summary>Gets or sets the map identifier.</summary>
        public int? MapId { get; set; }

        /// <summary>Gets the resource path.</summary>
        public string Resource
        {
            get
            {
                return Services.Maps;
            }
        }
    }
}