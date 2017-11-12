// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForCylinderLocation.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="LocationDataContract" /> to objects of type <see cref="CylinderLocation" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.Common;
using GW2NET.DynamicEvents;
using GW2NET.V1.Events.Json;

namespace GW2NET.V1.Events.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="LocationDataContract"/> to objects of type <see cref="CylinderLocation"/>.</summary>
    internal sealed class ConverterForCylinderLocation : IConverter<LocationDataContract, CylinderLocation>
    {
        /// <inheritdoc />
        public CylinderLocation Convert(LocationDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new CylinderLocation
            {
                Height = value.Height,
                Radius = value.Radius,
                Rotation = value.Rotation
            };
        }
    }
}