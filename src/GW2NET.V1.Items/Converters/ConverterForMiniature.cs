// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForMiniature.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemDataContract" /> to objects of type <see cref="Miniature" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="ItemDataContract"/> to objects of type <see cref="Miniature"/>.</summary>
    internal sealed class ConverterForMiniature : IConverter<ItemDataContract, Miniature>
    {
        /// <inheritdoc />
        public Miniature Convert(ItemDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var item = new Miniature();
            if (value.MiniPet != null)
            {
                item.MiniatureId = value.MiniPet.MiniPetId;
            }

            return item;
        }
    }
}