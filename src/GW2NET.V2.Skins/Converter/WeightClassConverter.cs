// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeightClassConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type  to objects of type .
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Converter
{
    using System;
    using System.Diagnostics;
    using Common;
    using Items.Armors;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="WeightClass"/>.</summary>
    public sealed class WeightClassConverter : IConverter<string, WeightClass>
    {
        /// <inheritdoc />
        public WeightClass Convert(string value, object state)
        {
            WeightClass result;
            if (Enum.TryParse(value, true, out result))
            {
                return result;
            }

            Debug.Assert(false, "Unknown WeightClass: " + value);
            return default(WeightClass);
        }
    }
}