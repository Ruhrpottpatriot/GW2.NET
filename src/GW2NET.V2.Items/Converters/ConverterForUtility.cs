// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForUtility.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract" /> to objects of type <see cref="Utility" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="Utility"/>.</summary>
    internal sealed class ConverterForUtility : IConverter<DetailsDataContract, Utility>
    {
        /// <summary>Converts the given object of type <see cref="DetailsDataContract"/> to an object of type <see cref="Utility"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public Utility Convert(DetailsDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var utility = new Utility();

            // Set the duration
            var duration = value.Duration;
            if (duration.HasValue)
            {
                utility.Duration = TimeSpan.FromMilliseconds(duration.Value);
            }

            // Set the effect description
            utility.Effect = value.Description;

            return utility;
        }
    }
}