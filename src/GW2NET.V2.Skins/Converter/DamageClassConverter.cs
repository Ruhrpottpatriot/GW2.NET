// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DamageClassConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="DamageType" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Skins
{
    using System;
    using System.Diagnostics;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="DamageType"/>.</summary>
    internal sealed class DamageClassConverter : IConverter<string, DamageType>
    {
        /// <inheritdoc />
        public DamageType Convert(string value)
        {
            DamageType result;
            if (Enum.TryParse(value, out result))
            {
                return result;
            }

            Debug.Assert(false, "Unknown DamageType: " + value);
            return default(DamageType);
        }
    }
}
