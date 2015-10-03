// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuagganConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="QuagganDTO" /> to objects of type <see cref="Quaggan" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Quaggans.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Quaggans;
    using GW2NET.V2.Quaggans.Json;

    /// <summary>Converts objects of type <see cref="QuagganDTO"/> to objects of type <see cref="Quaggan"/>.</summary>
    public sealed class QuagganConverter : IConverter<QuagganDTO, Quaggan>
    {
        /// <inheritdoc />
        public Quaggan Convert(QuagganDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return new Quaggan
            {
                Id = value.Id,
                Url = new Uri(value.Url, UriKind.Absolute)
            };
        }
    }
}