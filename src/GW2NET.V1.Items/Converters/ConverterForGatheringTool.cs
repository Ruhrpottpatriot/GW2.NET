// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForGatheringTool.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemDataContract" /> to objects of type <see cref="GatheringTool" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.Items;
using GW2NET.V1.Items.Json;

namespace GW2NET.V1.Items.Converters
{
    /// <summary>Converts objects of type <see cref="ItemDataContract"/> to objects of type <see cref="GatheringTool"/>.</summary>
    internal sealed class ConverterForGatheringTool : IConverter<ItemDataContract, GatheringTool>
    {
        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<GatheringToolDataContract, GatheringTool>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForGatheringTool"/> class.</summary>
        internal ConverterForGatheringTool()
            : this(GetKnownTypeConverters())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForGatheringTool"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        internal ConverterForGatheringTool(IDictionary<string, IConverter<GatheringToolDataContract, GatheringTool>> typeConverters)
        {
            Contract.Requires(typeConverters != null);
            this.typeConverters = typeConverters;
        }

        /// <summary>Converts the given object of type <see cref="ItemDataContract"/> to an object of type <see cref="GatheringTool"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public GatheringTool Convert(ItemDataContract value)
        {
            Contract.Assume(value != null);
            GatheringTool gatheringTool;
            var gatheringToolDataContract = value.GatheringTool;

            IConverter<GatheringToolDataContract, GatheringTool> converter;
            if (this.typeConverters.TryGetValue(gatheringToolDataContract.Type, out converter))
            {
                gatheringTool = converter.Convert(gatheringToolDataContract);
            }
            else
            {
                gatheringTool = new UnknownGatheringTool();
            }

            int defaultSkinId;
            if (int.TryParse(value.DefaultSkin, out defaultSkinId))
            {
                gatheringTool.DefaultSkinId = defaultSkinId;
            }

            return gatheringTool;
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<GatheringToolDataContract, GatheringTool>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<GatheringToolDataContract, GatheringTool>>
            {
                { "Foraging", new ConverterForForagingTool() }, 
                { "Logging", new ConverterForLoggingTool() }, 
                { "Mining", new ConverterForMiningTool() }, 
            };
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.typeConverters != null);
        }
    }
}