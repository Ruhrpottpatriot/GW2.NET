// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForWarHorn.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="WeaponDataContract" /> to objects of type <see cref="WarHorn" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="WeaponDataContract"/> to objects of type <see cref="WarHorn"/>.</summary>
    internal sealed class ConverterForWarHorn : IConverter<WeaponDataContract, WarHorn>
    {
        /// <inheritdoc />
        public WarHorn Convert(WeaponDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new WarHorn();
        }
    }
}