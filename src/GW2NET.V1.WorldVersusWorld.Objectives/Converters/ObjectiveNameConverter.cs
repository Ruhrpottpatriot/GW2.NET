// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveNameConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ObjectiveNameDTO" /> to objects of type <see cref="ObjectiveName" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.WorldVersusWorld.Objectives.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.V1.WorldVersusWorld.Objectives.Json;
    using GW2NET.WorldVersusWorld;

    /// <summary>Converts objects of type <see cref="ObjectiveNameDTO"/> to objects of type <see cref="ObjectiveName"/>.</summary>
    public sealed class ObjectiveNameConverter : IConverter<ObjectiveNameDTO, ObjectiveName>
    {
        /// <summary>Converts the given object of type <see cref="ObjectiveNameDTO"/> to an object of type <see cref="ObjectiveName"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public ObjectiveName Convert(ObjectiveNameDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var objectiveName = new ObjectiveName
            {
                Name = value.Name
            };
            int objectiveId;
            if (int.TryParse(value.Id, out objectiveId))
            {
                objectiveName.ObjectiveId = objectiveId;
            }

            return objectiveName;
        }
    }
}