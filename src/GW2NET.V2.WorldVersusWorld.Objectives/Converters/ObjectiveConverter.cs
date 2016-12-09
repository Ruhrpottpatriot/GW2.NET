// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveNameConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ObjectiveDTO" /> to objects of type <see cref="Objective" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2NET.V2.WorldVersusWorld.Objectives.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.V2.WorldVersusWorld.Objectives.Json;
    using GW2NET.WorldVersusWorld;

    /// <summary>Converts objects of type <see cref="ObjectiveDTO"/> to objects of type <see cref="Objective"/>.</summary>
    public sealed class ObjectiveConverter : IConverter<ObjectiveDTO, Objective>
    {
        /// <summary>Converts the given object of type <see cref="ObjectiveDTO"/> to an object of type <see cref="Objective"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public Objective Convert(ObjectiveDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var objective = new Objective
            {
                ObjectiveId = value.Id,
                Name = value.Name,
                SectorId = value.SectorId,
                Type = value.Type,
                MapType = value.MapType,
                MapId = value.MapId,
                MapCoordinates = ConvertCoordinates(value.Coord),
                LabelCoordinates = ConvertCoordinates(value.LabelCoord)
            };

            return objective;
        }

        private Vector2D ConvertCoordinates(double[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (value.Length != 2)
            {
                throw new ArgumentException("Precondition: value.Length == 2", "value");
            }

            return new Vector2D(value[0], value[1]);
        }

    }
}
