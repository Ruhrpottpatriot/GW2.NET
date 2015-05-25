// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForTool.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemDataContract" /> to objects of type <see cref="Tool" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="ItemDataContract"/> to objects of type <see cref="Tool"/>.</summary>
    internal sealed class ConverterForTool : IConverter<ItemDataContract, Tool>
    {
        /// <summary>Infrastructure. Holds a reference to type converters.</summary>
        private readonly IDictionary<string, IConverter<ToolDataContract, Tool>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForTool"/> class.</summary>
        internal ConverterForTool()
            : this(GetKnownTypeConverters())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForTool"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        internal ConverterForTool(IDictionary<string, IConverter<ToolDataContract, Tool>> typeConverters)
        {
            if (typeConverters == null)
            {
                throw new ArgumentNullException("typeConverters", "Precondition: typeConverters != null");
            }

            this.typeConverters = typeConverters;
        }

        /// <inheritdoc />
        public Tool Convert(ItemDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var toolDataContract = value.Tool;
            if (toolDataContract == null)
            {
                return new UnknownTool();
            }

            IConverter<ToolDataContract, Tool> converterForTool;
            if (this.typeConverters.TryGetValue(toolDataContract.Type, out converterForTool))
            {
                return converterForTool.Convert(toolDataContract, state);
            }

            return new UnknownTool();
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static Dictionary<string, IConverter<ToolDataContract, Tool>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<ToolDataContract, Tool>>
            {
                { "Salvage", new ConverterForSalvageTool() }
            };
        }
    }
}