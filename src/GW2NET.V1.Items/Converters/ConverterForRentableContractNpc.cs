// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForRentableContractNpc.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="GizmoDataContract" /> to objects of type <see cref="RentableContractNpc" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="GizmoDataContract"/> to objects of type <see cref="RentableContractNpc"/>.</summary>
    internal sealed class ConverterForRentableContractNpc : IConverter<GizmoDataContract, RentableContractNpc>
    {
        /// <inheritdoc />
        public RentableContractNpc Convert(GizmoDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new RentableContractNpc();
        }
    }
}
