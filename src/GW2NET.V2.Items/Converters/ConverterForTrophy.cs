// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForTrophy.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract" /> to objects of type <see cref="Trophy" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="Trophy"/>.</summary>
    internal sealed class ConverterForTrophy : IConverter<DetailsDataContract, Trophy>
    {
        /// <summary>Converts the given object of type <see cref="DetailsDataContract"/> to an object of type <see cref="Trophy"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Trophy Convert(DetailsDataContract value)
        {
            // MEMO: value is always null here because trophies never have details
            return new Trophy();
        }
    }
}
