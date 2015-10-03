// <copyright file="PointOfInterestConverterFactory.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Factories.V1
{
    using GW2NET.Common;
    using GW2NET.Maps;
    using GW2NET.V1.Floors.Converters;
    using GW2NET.V1.Floors.Json;

    public class PointOfInterestConverterFactory : ITypeConverterFactory<PointOfInterestDTO, PointOfInterest>
    {
        public IConverter<PointOfInterestDTO, PointOfInterest> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "unlock":
                    return new DungeonConverter();
                case "landmark":
                    return new LandmarkConverter();
                case "vista":
                    return new VistaConverter();
                case "waypoint":
                    return new WaypointConverter();
                default:
                    return new UnknownPointOfInterestConverter();
            }
        }
    }
}