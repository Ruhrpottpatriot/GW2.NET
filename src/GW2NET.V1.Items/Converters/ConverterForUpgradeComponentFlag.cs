// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForUpgradeComponentFlag.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="UpgradeComponentFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using GW2NET.Common;
using GW2NET.Items;

namespace GW2NET.V1.Items.Converters
{
    using System.Diagnostics;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="UpgradeComponentFlags"/>.</summary>
    internal sealed class ConverterForUpgradeComponentFlag : IConverter<string, UpgradeComponentFlags>
    {
        /// <inheritdoc />
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