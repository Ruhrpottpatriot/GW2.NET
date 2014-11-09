// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForCylinderLocation.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="LocationDataContract" /> to objects of type <see cref="CylinderLocation" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.DynamicEvents.Converters
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.DynamicEvents;
    using GW2NET.V1.DynamicEvents.Json;

    /// <summary>Converts objects of type <see cref="LocationDataContract"/> to objects of type <see cref="CylinderLocation"/>.</summary>
    internal sealed class ConverterForCylinderLocation : IConverter<LocationDataContract, CylinderLocation>
    {
        /// <summary>Converts the given object of type <see cref="LocationDataContract"/> to an object of type <see cref="CylinderLocation"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public CylinderLocation Convert(LocationDataContract value)
        {
            Contract.Assume(value != null);
            return new CylinderLocation
            {
                Height = value.Height, 
                Radius = value.Radius, 
                Rotation = value.Rotation
            };
        }
    }
}