// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForDynamicEventFlag.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="DynamicEventFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.DynamicEvents.Converters
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.DynamicEvents;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="DynamicEventFlags"/>.</summary>
    internal sealed class ConverterForDynamicEventFlag : IConverter<string, DynamicEventFlags>
    {
        /// <summary>The dynamic event flags.</summary>
        private readonly IDictionary<string, DynamicEventFlags> dynamicEventFlags;

        /// <summary>Initializes a new instance of the <see cref="ConverterForDynamicEventFlag"/> class.</summary>
        internal ConverterForDynamicEventFlag()
            : this(GetKnownFlags())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForDynamicEventFlag"/> class.</summary>
        /// <param name="dynamicEventFlags">The known flags.</param>
        internal ConverterForDynamicEventFlag(IDictionary<string, DynamicEventFlags> dynamicEventFlags)
        {
            Contract.Requires(dynamicEventFlags != null);
            this.dynamicEventFlags = dynamicEventFlags;
        }

        /// <summary>Converts the given object of type <see cref="string"/> to an object of type <see cref="DynamicEventFlags"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public DynamicEventFlags Convert(string value)
        {
            Contract.Assume(value != null);
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

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.dynamicEventFlags != null);
        }
    }
}