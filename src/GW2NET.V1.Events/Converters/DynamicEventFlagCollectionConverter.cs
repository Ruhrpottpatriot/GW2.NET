// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventFlagCollectionConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="DynamicEventFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Events.Converters
{
    using System;
    using System.Collections.Generic;
    using GW2NET.Common;
    using GW2NET.DynamicEvents;

    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="DynamicEventFlags"/>.</summary>
    public sealed class DynamicEventFlagCollectionConverter : IConverter<ICollection<string>, DynamicEventFlags>
    {
        private readonly IConverter<string, DynamicEventFlags> dynamicEventFlagConverter;

        /// <summary>Initializes a new instance of the <see cref="DynamicEventFlagCollectionConverter"/> class.</summary>
        /// <param name="dynamicEventFlagConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public DynamicEventFlagCollectionConverter(IConverter<string, DynamicEventFlags> dynamicEventFlagConverter)
        {
            if (dynamicEventFlagConverter == null)
            {
                throw new ArgumentNullException("dynamicEventFlagConverter");
            }

            this.dynamicEventFlagConverter = dynamicEventFlagConverter;
        }

        /// <inheritdoc />
        public DynamicEventFlags Convert(ICollection<string> value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var result = default(DynamicEventFlags);
            foreach (var s in value)
            {
                result |= this.dynamicEventFlagConverter.Convert(s, state);
            }

            return result;
        }
    }
}