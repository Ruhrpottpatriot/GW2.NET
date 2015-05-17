// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForMace.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="WeaponDataContract" /> to objects of type <see cref="Mace" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.Items;
using GW2NET.V1.Items.Json;

namespace GW2NET.V1.Items.Converters
{
    /// <summary>Converts objects of type <see cref="WeaponDataContract"/> to objects of type <see cref="Mace"/>.</summary>
    internal sealed class ConverterForMace : IConverter<WeaponDataContract, Mace>
    {
        /// <inheritdoc />
        public Mace Convert(WeaponDataContract value)
        {
            Contract.Assume(value != null);
            return new Mace();
        }
    }
}