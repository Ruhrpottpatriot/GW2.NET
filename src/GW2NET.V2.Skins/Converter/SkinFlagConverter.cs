// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinFlagConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="SkinFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Skins
{
    using System;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Skins;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="SkinFlags"/>.</summary>
    internal sealed class SkinFlagConverter : IConverter<string, SkinFlags>
    {
        /// <summary>Converts the given object of type <see cref="string"/> to an object of type <see cref="SkinFlags"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public SkinFlags Convert(string value)
        {
            Contract.Assume(value != null);
            SkinFlags result;
            return Enum.TryParse(value, true, out result) ? result : default(SkinFlags);
        }
    }
}