// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeightClassConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type  to objects of type .
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Skins.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="WeightClass"/>.</summary>
    public sealed class WeightClassConverter : IConverter<string, WeightClass>
    {
        /// <inheritdoc />
        public WeightClass Convert(string value, object state)
        {
            WeightClass result;
            return Enum.TryParse(value, true, out result) ? result : default(WeightClass);
        }
    }
}