// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForBackpackSkin.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="SkinDataContract" /> to objects of type <see cref="BackpackSkin" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Skins
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Skins.Backpacks;

    /// <summary>Converts objects of type <see cref="SkinDataContract"/> to objects of type <see cref="BackpackSkin"/>.</summary>
    internal sealed class ConverterForBackpackSkin : IConverter<SkinDataContract, BackpackSkin>
    {
        /// <summary>Converts the given object of type <see cref="SkinDataContract"/> to an object of type <see cref="BackpackSkin"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public BackpackSkin Convert(SkinDataContract value)
        {
            Contract.Assume(value != null);
            return new BackpackSkin();
        }
    }
}