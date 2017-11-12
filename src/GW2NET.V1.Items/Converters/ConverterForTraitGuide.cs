﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForTraitGuide.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemDataContract" /> to objects of type <see cref="TraitGuide" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="ItemDataContract"/> to objects of type <see cref="TraitGuide"/>.</summary>
    internal sealed class ConverterForTraitGuide : IConverter<ItemDataContract, TraitGuide>
    {
        /// <inheritdoc />
        public TraitGuide Convert(ItemDataContract value)
        {
            // MEMO: value can be null / is always null
            return new TraitGuide();
        }
    }
}