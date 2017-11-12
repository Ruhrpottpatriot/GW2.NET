// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForQuaggan.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="QuagganDataContract" /> to objects of type <see cref="Quaggan" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Quaggans
{
    using System;

    using GW2NET.Common;
    using GW2NET.Quaggans;

    /// <summary>Converts objects of type <see cref="QuagganDataContract"/> to objects of type <see cref="Quaggan"/>.</summary>
    internal sealed class ConverterForQuaggan : IConverter<QuagganDataContract, Quaggan>
    {
        /// <inheritdoc />
        public Quaggan Convert(QuagganDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new Quaggan
            {
                Id = value.Id,
                Url = new Uri(value.Url, UriKind.Absolute)
            };
        }
    }
}
