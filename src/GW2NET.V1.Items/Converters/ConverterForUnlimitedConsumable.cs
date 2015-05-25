// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForUnlimitedConsumable.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="GizmoDataContract" /> to objects of type <see cref="UnlimitedConsumable" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="GizmoDataContract"/> to objects of type <see cref="UnlimitedConsumable"/>.</summary>
    internal sealed class ConverterForUnlimitedConsumable : IConverter<GizmoDataContract, UnlimitedConsumable>
    {
        /// <inheritdoc />
        public UnlimitedConsumable Convert(GizmoDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new UnlimitedConsumable();
        }
    }
}