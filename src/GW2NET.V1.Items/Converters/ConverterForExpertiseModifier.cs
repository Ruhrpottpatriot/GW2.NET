// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForExpertiseModifier.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="AttributeDataContract" /> to objects of type <see cref="ExpertiseModifier" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.Common;
using GW2NET.Items;
using GW2NET.V1.Items.Json;

namespace GW2NET.V1.Items.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="AttributeDataContract"/> to objects of type <see cref="ExpertiseModifier"/>.</summary>
    internal sealed class ConverterForExpertiseModifier : IConverter<AttributeDataContract, ExpertiseModifier>
    {
        /// <inheritdoc />
        public ExpertiseModifier Convert(AttributeDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var attribute = new ExpertiseModifier();
            int modifier;
            if (int.TryParse(value.Modifier, out modifier))
            {
                attribute.Modifier = modifier;
            }

            return attribute;
        }
    }
}