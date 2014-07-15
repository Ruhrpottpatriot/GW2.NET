// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapFloorSerializerSettings.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The map floor serializer settings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps
{
    using GW2DotNET.V1.Common.Converters;
    using GW2DotNET.V1.Maps.Converters;

    using Newtonsoft.Json;

    /// <summary>The map floor serializer settings.</summary>
    public class MapFloorSerializerSettings : JsonSerializerSettings
    {
        /// <summary>Initializes a new instance of the <see cref="MapFloorSerializerSettings"/> class.</summary>
        public MapFloorSerializerSettings()
        {
            this.Converters.Add(new PointOfInterestConverter());
            this.Converters.Add(new JsonPointFConverter());
            this.Converters.Add(new JsonRectangleConverter());
            this.Converters.Add(new JsonSizeConverter());
        }
    }
}