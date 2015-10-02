// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenownTaskConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="RenownTaskDTO" /> to objects of type <see cref="RenownTask" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Floors.Converters
{
    using System;
    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.Maps;
    using GW2NET.V1.Floors.Json;

    /// <summary>Converts objects of type <see cref="RenownTaskDTO"/> to objects of type <see cref="RenownTask"/>.</summary>
    public sealed class RenownTaskConverter : IConverter<RenownTaskDTO, RenownTask>
    {
        private readonly IConverter<double[], Vector2D> vector2DConverter;

        /// <summary>Initializes a new instance of the <see cref="RenownTaskConverter"/> class.</summary>
        /// <param name="vector2DConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public RenownTaskConverter(IConverter<double[], Vector2D> vector2DConverter)
        {
            if (vector2DConverter == null)
            {
                throw new ArgumentNullException("vector2DConverter");
            }

            this.vector2DConverter = vector2DConverter;
        }

        /// <inheritdoc />
        public RenownTask Convert(RenownTaskDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var renownTask = new RenownTask
            {
                TaskId = value.TaskId,
                Objective = value.Objective,
                Level = value.Level
            };

            var coordinates = value.Coordinates;
            if (coordinates != null && coordinates.Length == 2)
            {
                renownTask.Coordinates = this.vector2DConverter.Convert(coordinates, value);
            }

            return renownTask;
        }
    }
}