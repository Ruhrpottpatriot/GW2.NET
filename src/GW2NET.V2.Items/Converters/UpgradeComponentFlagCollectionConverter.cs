// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponentFlagCollectionConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="UpgradeComponentFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Items.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items.UpgradeComponents;

    /// <summary>
    ///     Converts objects of type <see cref="T:ICollection{string}" /> to objects of type
    ///     <see cref="UpgradeComponentFlags" />.
    /// </summary>
    public sealed class UpgradeComponentFlagCollectionConverter : IConverter<ICollection<string>, UpgradeComponentFlags>
    {
        private readonly IConverter<string, UpgradeComponentFlags> upgradeComponentFlagConverter;

        /// <summary>Initializes a new instance of the <see cref="UpgradeComponentFlagCollectionConverter" /> class.</summary>
        /// <param name="upgradeComponentFlagConverter">The converter for <see cref="UpgradeComponentFlags" />.</param>
        public UpgradeComponentFlagCollectionConverter(
            IConverter<string, UpgradeComponentFlags> upgradeComponentFlagConverter)
        {
            if (upgradeComponentFlagConverter == null)
            {
                throw new ArgumentNullException(nameof(upgradeComponentFlagConverter));
            }

            this.upgradeComponentFlagConverter = upgradeComponentFlagConverter;
        }

        /// <summary>
        ///     Converts the given object of type <see cref="T:ICollection{string}" /> to an object of type
        ///     <see cref="UpgradeComponentFlags" />.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public UpgradeComponentFlags Convert(ICollection<string> value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var result = default(UpgradeComponentFlags);
            foreach (var s in value)
            {
                result |= this.upgradeComponentFlagConverter.Convert(s, state);
            }

            return result;
        }
    }
}