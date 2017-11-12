﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForDefaultContainer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ContainerDataContract" /> to objects of type <see cref="DefaultContainer" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.Common;
using GW2NET.Items;
using GW2NET.V1.Items.Json;

namespace GW2NET.V1.Items.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="ContainerDataContract"/> to objects of type <see cref="DefaultContainer"/>.</summary>
    internal sealed class ConverterForDefaultContainer : IConverter<ContainerDataContract, DefaultContainer>
    {
        /// <inheritdoc />
        public DefaultContainer Convert(ContainerDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new DefaultContainer();
        }
    }
}