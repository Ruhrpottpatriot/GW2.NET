// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForSigil.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="UpgradeComponentDataContract" /> to objects of type <see cref="Sigil" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.Items;
using GW2NET.V1.Items.Json;

namespace GW2NET.V1.Items.Converters
{
    /// <summary>Converts objects of type <see cref="UpgradeComponentDataContract"/> to objects of type <see cref="Sigil"/>.</summary>
    internal sealed class ConverterForSigil : IConverter<UpgradeComponentDataContract, Sigil>
    {
        /// <inheritdoc />
        public Sigil Convert(UpgradeComponentDataContract value)
        {
            Contract.Assume(value != null);
            return new Sigil();
        }
    }
}