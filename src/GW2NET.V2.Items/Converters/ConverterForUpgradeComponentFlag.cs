// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForUpgradeComponentFlag.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="UpgradeComponentFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items
{
    using System;
    using System.Diagnostics;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="UpgradeComponentFlags"/>.</summary>
    internal sealed class ConverterForUpgradeComponentFlag : IConverter<string, UpgradeComponentFlags>
    {
        /// <summary>Converts the given object of type <see cref="string"/> to an object of type <see cref="UpgradeComponentFlags"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public UpgradeComponentFlags Convert(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            UpgradeComponentFlags result;
            if (Enum.TryParse(value, out result))
            {
                return result;
            }

            Debug.Assert(false, "Unknown UpgradeComponentFlags: " + value);
            return default(UpgradeComponentFlags);
        }
    }
}
