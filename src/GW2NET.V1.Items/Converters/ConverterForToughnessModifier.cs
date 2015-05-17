// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForToughnessModifier.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="AttributeDataContract" /> to objects of type <see cref="ToughnessModifier" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.Items;
using GW2NET.V1.Items.Json;

namespace GW2NET.V1.Items.Converters
{
    /// <summary>Converts objects of type <see cref="AttributeDataContract"/> to objects of type <see cref="ToughnessModifier"/>.</summary>
    internal sealed class ConverterForToughnessModifier : IConverter<AttributeDataContract, ToughnessModifier>
    {
        /// <inheritdoc />
        public ToughnessModifier Convert(AttributeDataContract value)
        {
            Contract.Assume(value != null);
            var attribute = new ToughnessModifier();
            int modifier;
            if (int.TryParse(value.Modifier, out modifier))
            {
                attribute.Modifier = modifier;
            }

            return attribute;
        }
    }
}