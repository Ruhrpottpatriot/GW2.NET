// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapFloorService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the map floor service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Maps;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Maps.Contracts;

    /// <summary>Provides the default implementation of the map floor service.</summary>
    public class MapFloorService : IMapFloorService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="MapFloorService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public MapFloorService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Floor GetMapFloor(int continent, int floor)
        {
            return this.GetMapFloor(continent, floor, CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Floor GetMapFloor(int continent, int floor, CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new MapFloorRequest { ContinentId = continent, Floor = floor, Culture = language };
            var response = this.serviceClient.Send(request, new JsonSerializer<FloorContract>());
            return MapFloorContract(continent, floor, language, response.Content);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continent, int floor)
        {
            return this.GetMapFloorAsync(continent, floor, CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continent, int floor, CancellationToken cancellationToken)
        {
            return this.GetMapFloorAsync(continent, floor, CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continent, int floor, CultureInfo language)
        {
            return this.GetMapFloorAsync(continent, floor, language, CancellationToken.None);
        }

        /// <summary>Gets a map floor and its localized details.</summary>
        /// <param name="continent">The continent identifier.</param>
        /// <param name="floor">The floor identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map floor and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor">wiki</a> for more information.</remarks>
        public Task<Floor> GetMapFloorAsync(int continent, int floor, CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new MapFloorRequest { ContinentId = continent, Floor = floor, Culture = language };
            return this.serviceClient.SendAsync(request, new JsonSerializer<FloorContract>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapFloorContract(continent, floor, language, response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetPointOfInterestType(PointOfInterestContract content)
        {
            switch (content.Type)
            {
                case "unlock":
                    return typeof(Dungeon);
                case "landmark":
                    return typeof(Landmark);
                case "vista":
                    return typeof(Vista);
                case "waypoint":
                    return typeof(Waypoint);
                default:
                    return typeof(UnknownPointOfInterest);
            }
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="continent">The continent.</param>
        /// <param name="floor">The floor.</param>
        /// <param name="culture">The culture.</param>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Floor MapFloorContract(int continent, int floor, CultureInfo culture, FloorContract content)
        {
            var value = new Floor { ContinentId = continent, FloorId = floor, Language = culture.TwoLetterISOLanguageName };

            if (content.TextureDimensions != null)
            {
                value.TextureDimensions = MapSize2DContract(content.TextureDimensions);
            }

            if (content.ClampedView != null)
            {
                value.ClampedView = MapRectangleContract(content.ClampedView);
            }

            if (content.Regions != null)
            {
                value.Regions = MapRegionContracts(content.Regions);
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Point2D MapPoint2DContract(double[] content)
        {
            return new Point2D(content[0], content[1]);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static PointOfInterest MapPointOfInterestContract(PointOfInterestContract content)
        {
            var value = (PointOfInterest)Activator.CreateInstance(GetPointOfInterestType(content));
            value.PointOfInterestId = content.PointOfInterestId;
            value.Name = content.Name;
            value.Floor = content.Floor;
            value.Coordinates = MapPoint2DContract(content.Coordinates);
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<PointOfInterest> MapPointOfInterestContracts(ICollection<PointOfInterestContract> content)
        {
            var values = new List<PointOfInterest>(content.Count);
            values.AddRange(content.Select(MapPointOfInterestContract));
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Rectangle MapRectangleContract(double[][] content)
        {
            var nw = MapPoint2DContract(content[0]);
            var se = MapPoint2DContract(content[1]);
            return new Rectangle(nw, se);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Region MapRegionContract(KeyValuePair<string, RegionContract> content)
        {
            return new Region
                       {
                           RegionId = int.Parse(content.Key), 
                           Name = content.Value.Name, 
                           LabelCoordinates = MapPoint2DContract(content.Value.LabelCoordinates), 
                           Maps = MapSubregionContracts(content.Value.Maps)
                       };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<int, Region> MapRegionContracts(IDictionary<string, RegionContract> content)
        {
            var values = new Dictionary<int, Region>(content.Count);
            foreach (var value in content.Select(MapRegionContract))
            {
                values.Add(value.RegionId, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static RenownTask MapRenownTaskContract(RenownTaskContract content)
        {
            return new RenownTask
                       {
                           TaskId = content.TaskId, 
                           Objective = content.Objective, 
                           Level = content.Level, 
                           Coordinates = MapPoint2DContract(content.Coordinates)
                       };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<RenownTask> MapRenownTaskContracts(ICollection<RenownTaskContract> content)
        {
            var values = new List<RenownTask>(content.Count);
            values.AddRange(content.Select(MapRenownTaskContract));
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Sector MapSectorContract(SectorContract content)
        {
            return new Sector { SectorId = content.SectorId, Name = content.Name, Level = content.Level, Coordinates = MapPoint2DContract(content.Coordinates) };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<Sector> MapSectorContracts(ICollection<SectorContract> content)
        {
            var values = new List<Sector>(content.Count);
            values.AddRange(content.Select(MapSectorContract));
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Size2D MapSize2DContract(double[] content)
        {
            return new Size2D(content[0], content[1]);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static SkillChallenge MapSkillChallengeContract(SkillChallengeContract content)
        {
            return new SkillChallenge { Coordinates = MapPoint2DContract(content.Coordinates) };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<SkillChallenge> MapSkillChallengeContracts(ICollection<SkillChallengeContract> content)
        {
            var values = new List<SkillChallenge>(content.Count);
            values.AddRange(content.Select(MapSkillChallengeContract));
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Subregion MapSubregionContract(KeyValuePair<string, SubregionContract> content)
        {
            return new Subregion
                       {
                           MapId = int.Parse(content.Key), 
                           Name = content.Value.Name, 
                           MinimumLevel = content.Value.MinimumLevel, 
                           MaximumLevel = content.Value.MaximumLevel, 
                           DefaultFloor = content.Value.DefaultFloor, 
                           MapRectangle = MapRectangleContract(content.Value.MapRectangle), 
                           ContinentRectangle = MapRectangleContract(content.Value.ContinentRectangle), 
                           PointsOfInterest = MapPointOfInterestContracts(content.Value.PointsOfInterest), 
                           Tasks = MapRenownTaskContracts(content.Value.Tasks), 
                           SkillChallenges = MapSkillChallengeContracts(content.Value.SkillChallenges), 
                           Sectors = MapSectorContracts(content.Value.Sectors)
                       };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<int, Subregion> MapSubregionContracts(IDictionary<string, SubregionContract> content)
        {
            var values = new Dictionary<int, Subregion>(content.Count);
            foreach (var value in content.Select(MapSubregionContract))
            {
                values.Add(value.MapId, value);
            }

            return values;
        }
    }
}