// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="WorldDTO" /> to objects of type <see cref="World" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Worlds.Converters
{
    using System;
    using System.Diagnostics;
    using GW2NET.Common;
    using GW2NET.V2.Worlds.Json;
    using GW2NET.Worlds;

    /// <summary>Converts objects of type <see cref="WorldDTO"/> to objects of type <see cref="World"/>.</summary>
    public sealed class WorldConverter : IConverter<WorldDTO, World>
    {
        /// <inheritdoc />
        public World Convert(WorldDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            var response = state as IResponse;
            if (response == null)
            {
                throw new ArgumentException("Precondition: state is IResponse", nameof(state));
            }

            var world = new World
            {
                WorldId = value.Id,
                Name = value.Name,
                Culture = response.Culture
            };

            if (value.Population != null)
            {
                Population population;
                if (Enum.TryParse(value.Population, true, out population))
                {
                    world.Population = population;
                }
                else
                {
                    Debug.Assert(false, "Unknown Population:" + value.Population);
                    world.Population = Population.Unknown;
                }
            }

            return world;
        }
    }
}