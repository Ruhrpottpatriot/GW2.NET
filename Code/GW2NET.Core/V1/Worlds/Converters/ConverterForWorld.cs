// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForWorld.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="WorldDataContract" /> to objects of type <see cref="World" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Worlds.Converters
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Worlds;
    using GW2NET.V1.Worlds.Json;

    /// <summary>Converts objects of type <see cref="WorldDataContract"/> to objects of type <see cref="World"/>.</summary>
    internal sealed class ConverterForWorld : IConverter<WorldDataContract, World>
    {
        /// <summary>Converts the given object of type <see cref="WorldDataContract"/> to an object of type <see cref="World"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public World Convert(WorldDataContract value)
        {
            Contract.Assume(value != null);
            var world = new World
            {
                Name = value.Name
            };

            int worldId;
            if (int.TryParse(value.Id, out worldId))
            {
                world.WorldId = worldId;
            }

            return world;
        }
    }
}