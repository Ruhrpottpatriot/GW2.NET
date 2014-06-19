// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventRotationService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the event rotations service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents.Rotations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    using GW2DotNET.V1.DynamicEvents.Rotations.Contracts;

    /// <summary>Provides the default implementation of the event rotations service.</summary>
    public class DynamicEventRotationService : IDynamicEventRotationService
    {
        /// <summary>Gets a collection of dynamic events and their start times.</summary>
        /// <returns>A collection of dynamic events and their start times.</returns>
        public IEnumerable<DynamicEventRotation> GetDynamicEventRotations()
        {
            return (from rotationElement in this.LoadConfiguration().Descendants("rotation").Where(element => element.Attributes("event_id").Any())
                    let shiftElements = rotationElement.Descendants("shift")
                    let eventId = Guid.Parse(rotationElement.Attribute("event_id").Value)
                    let shifts = shiftElements.Select(
                        element =>
                            {
                                var shift = DateTimeOffset.Parse(element.Value);
                                if (shift < DateTime.UtcNow)
                                {
                                    shift = shift.AddDays(1D);
                                }

                                return shift;
                            }).OrderBy(offset => offset.Ticks)
                    select new DynamicEventRotation { EventId = eventId, Shifts = new DynamicEventShifts(shifts) }).ToList();
        }

        /// <summary>Infrastructure. Loads the configuration.</summary>
        /// <returns>The configuration.</returns>
        private XDocument LoadConfiguration()
        {
            var type = this.GetType();
            using (var stream = type.Assembly.GetManifestResourceStream(type.Namespace + ".Rotations.xml"))
            {
                return XDocument.Load(stream);
            }
        }
    }
}