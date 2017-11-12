﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForTransmutation.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract" /> to objects of type <see cref="Transmutation" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="Transmutation"/>.</summary>
    internal sealed class ConverterForTransmutation : IConverter<DetailsDataContract, Transmutation>
    {
        /// <summary>Converts the given object of type <see cref="DetailsDataContract"/> to an object of type <see cref="Transmutation"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Transmutation Convert(DetailsDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var item = new Transmutation();
            if (value.Skins == null)
            {
                item.SkinIds = new List<int>(0);
            }
            else
            {
                var values = new List<int>(value.Skins.Length);
                values.AddRange(value.Skins);
                item.SkinIds = values;
            }

            return item;
        }
    }
}