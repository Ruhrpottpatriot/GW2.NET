// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventRotationService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the event rotations service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Reflection;

namespace GW2NET.Local.DynamicEvents
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Runtime.Serialization;

    using GW2NET.DynamicEvents;
    using GW2NET.Local.DynamicEvents.Xml;

    /// <summary>Provides the default implementation of the event rotations service.</summary>
    public class DynamicEventRotationService : IDynamicEventRotationService
    {
        /// <summary>Gets a collection of dynamic events and their rotating shifts</summary>
        /// <returns>A collection of dynamic events and their rotating shifts.</returns>
        public IDictionary<Guid, DynamicEventRotation> GetDynamicEventRotations()
        {
            // Load the event rotations configuration file from this assembly
            var type = this.GetType().GetTypeInfo();
            using (var stream = type.Assembly.GetManifestResourceStream(type.Namespace + ".Rotations.xml"))
            {
                // Ensure that there is content
                if (stream == null)
                {
                    return new Dictionary<Guid, DynamicEventRotation>(0);
                }

                // Create a new serializer
                var serializer = new DataContractSerializer(typeof(RotationCollectionContract));

                // Deserialize the content
                var content = (ICollection<RotationContract>)serializer.ReadObject(stream);

                // Ensure that there is deserialized content
                if (content == null)
                {
                    return new Dictionary<Guid, DynamicEventRotation>(0);
                }

                // Convert the content to entities
                return ConvertRotationCollectionContract(content);
            }
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<Guid, DynamicEventRotation> ConvertRotationCollectionContract(ICollection<RotationContract> content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<IDictionary<Guid, DynamicEventRotation>>() != null);

            // Create a new collection of event rotations
            var values = new Dictionary<Guid, DynamicEventRotation>(content.Count);

            // Set the event rotations
            foreach (var value in content.Select(ConvertRotationContract))
            {
                Contract.Assume(value != null);
                values.Add(value.EventId, value);
            }

            // Return the collection
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static DynamicEventRotation ConvertRotationContract(RotationContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<DynamicEventRotation>() != null);

            // Create a new rotation object
            var value = new DynamicEventRotation();

            // Set the event identifier
            if (content.EventId != null)
            {
                value.EventId = Guid.Parse(content.EventId);
            }

            // Set the rotating shifts
            if (content.Shifts != null)
            {
                value.Shifts = ConvertShiftCollectionContract(content.Shifts);
            }

            // Return the rotation object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<DateTimeOffset> ConvertShiftCollectionContract(ShiftCollectionContract content)
        {
            Contract.Requires(content != null);

            // Create a new collection of rotating shifts
            var values = new List<DateTimeOffset>(content.Count);

            // Set the rotating shifts
            values.AddRange(content.Select(DateTimeOffset.Parse));

            // Return the collection
            return values;
        }
    }
}