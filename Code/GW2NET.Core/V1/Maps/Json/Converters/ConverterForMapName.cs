// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForMapName.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="MapNameDataContract" /> to objects of type <see cref="MapName" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Maps.Json.Converters
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Maps;

    /// <summary>Converts objects of type <see cref="MapNameDataContract"/> to objects of type <see cref="MapName"/>.</summary>
    internal sealed class ConverterForMapName : IConverter<MapNameDataContract, MapName>
    {
        /// <summary>Converts the given object of type <see cref="MapNameDataContract"/> to an object of type <see cref="MapName"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public MapName Convert(MapNameDataContract value)
        {
            Contract.Requires(value != null);
            Contract.Ensures(Contract.Result<MapName>() != null);
            var mapName = new MapName();
            mapName.MapId = int.Parse(value.Id);
            mapName.Name = value.Name;
            return mapName;
        }
    }
}