// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="WorldDTO" /> to objects of type <see cref="World" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Worlds.Converters
{
    using System;

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
                throw new ArgumentNullException("value");
            }

            if (state == null)
            {
                throw new ArgumentNullException("state");
            }

            var response = state as IResponse;
            if (response == null)
            {
                throw new ArgumentException("Precondition: state is IResponse", "state");
            }
  
            return new World
            {
                WorldId = value.Id, 
                Name = value.Name,
                Culture = response.Culture
            };
        }
    }
}