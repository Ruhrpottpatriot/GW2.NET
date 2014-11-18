// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForGloves.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ArmorDataContract" /> to objects of type <see cref="Gloves" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items
{
    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="ArmorDataContract"/> to objects of type <see cref="Gloves"/>.</summary>
    internal sealed class ConverterForGloves : IConverter<ArmorDataContract, Gloves>
    {
        /// <summary>Converts the given object of type <see cref="ArmorDataContract"/> to an object of type <see cref="Gloves"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Gloves Convert(ArmorDataContract value)
        {
            return new Gloves();
        }
    }
}