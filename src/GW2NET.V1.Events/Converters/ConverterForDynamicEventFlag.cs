// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForDynamicEventFlag.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="DynamicEventFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using GW2NET.Common;
using GW2NET.DynamicEvents;

namespace GW2NET.V1.Events.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="DynamicEventFlags"/>.</summary>
    internal sealed class ConverterForDynamicEventFlag : IConverter<string, DynamicEventFlags>
    {
        private readonly IDictionary<string, DynamicEventFlags> dynamicEventFlags;

        /// <summary>Initializes a new instance of the <see cref="ConverterForDynamicEventFlag"/> class.</summary>
        internal ConverterForDynamicEventFlag()
            : this(GetKnownFlags())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForDynamicEventFlag"/> class.</summary>
        /// <param name="dynamicEventFlags">The known flags.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="dynamicEventFlags"/> is a null reference.</exception>
        internal ConverterForDynamicEventFlag(IDictionary<string, DynamicEventFlags> dynamicEventFlags)
        {
            if (dynamicEventFlags == null)
            {
                throw new ArgumentNullException("dynamicEventFlags", "Precondition: dynamicEventFlags != null");
            }

            this.dynamicEventFlags = dynamicEventFlags;
        }

        /// <inheritdoc />
        public DynamicEventFlags Convert(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            DynamicEventFlags result;
            if (this.dynamicEventFlags.TryGetValue(value, out result))
            {
                return result;
            }

            return default(DynamicEventFlags);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private static IDictionary<string, DynamicEventFlags> GetKnownFlags()
        {
            return new Dictionary<string, DynamicEventFlags>
            {
                { "group_event", DynamicEventFlags.GroupEvent },
                { "map_wide", DynamicEventFlags.MapWide }
            };
        }
    }
}
