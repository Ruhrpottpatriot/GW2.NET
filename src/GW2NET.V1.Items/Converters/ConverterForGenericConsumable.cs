﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForGenericConsumable.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ConsumableDataContract" /> to objects of type <see cref="GenericConsumable" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.Items;
using GW2NET.V1.Items.Json;

namespace GW2NET.V1.Items.Converters
{
    /// <summary>Converts objects of type <see cref="ConsumableDataContract"/> to objects of type <see cref="GenericConsumable"/>.</summary>
    internal sealed class ConverterForGenericConsumable : IConverter<ConsumableDataContract, GenericConsumable>
    {
        /// <inheritdoc />
        public GenericConsumable Convert(ConsumableDataContract value)
        {
            Contract.Assume(value != null);
            var genericConsumable = new GenericConsumable
            {
                Description = value.Description
            };

            double duration;
            if (double.TryParse(value.Duration, out duration))
            {
                genericConsumable.Duration = TimeSpan.FromMilliseconds(duration);
            }

            return genericConsumable;
        }
    }
}