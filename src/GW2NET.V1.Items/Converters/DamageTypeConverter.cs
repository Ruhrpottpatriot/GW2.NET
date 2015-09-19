// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DamageTypeConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="DamageType" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="DamageType"/>.</summary>
    public sealed class DamageTypeConverter : IConverter<string, DamageType>
    {
        /// <inheritdoc />
        public DamageType Convert(string value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            DamageType result;
            if (Enum.TryParse(value, true, out result))
            {
                return result;
            }

            return default(DamageType);
        }
    }
}