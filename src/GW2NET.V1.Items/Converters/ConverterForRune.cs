// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForRune.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="UpgradeComponentDataContract" /> to objects of type <see cref="Rune" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="UpgradeComponentDataContract"/> to objects of type <see cref="Rune"/>.</summary>
    internal sealed class ConverterForRune : IConverter<UpgradeComponentDataContract, Rune>
    {
        /// <inheritdoc />
        public Rune Convert(UpgradeComponentDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new Rune();
        }
    }
}