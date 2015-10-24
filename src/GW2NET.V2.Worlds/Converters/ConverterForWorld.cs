// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForWorld.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="WorldDataContract" /> to objects of type <see cref="World" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Worlds
{
    using System;
    using System.Diagnostics;

    using GW2NET.Common;
    using GW2NET.Worlds;

    /// <summary>Converts objects of type <see cref="WorldDataContract"/> to objects of type <see cref="World"/>.</summary>
    internal sealed class ConverterForWorld : IConverter<WorldDataContract, World>
    {
        /// <inheritdoc />
        public World Convert(WorldDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var world = new World
            {
                WorldId = value.Id,
                Name = value.Name
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
                    world.Population = Population.Unknown;
                    Debug.Assert(false, "Unknown Population:" + value.Population);
                }
            }

            return world;
        }
    }
}