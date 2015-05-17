// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BackpackConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract" /> to objects of type <see cref="BackpackSkin" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Skins
{
    using System;

    using GW2NET.Common;
    using GW2NET.Skins;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="BackpackSkin"/>.</summary>
    internal class BackpackConverter : IConverter<DetailsDataContract, BackpackSkin>
    {
        /// <inheritdoc />
        public BackpackSkin Convert(DetailsDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new BackpackSkin();
        }
    }
}