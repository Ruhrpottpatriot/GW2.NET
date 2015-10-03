// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameTypeConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="GameTypes" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Items.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="string" /> to objects of type <see cref="GameTypes" />.</summary>
    public sealed class GameTypeConverter : IConverter<string, GameTypes>
    {
        /// <summary>Converts the given object of type <see cref="string" /> to an object of type <see cref="GameTypes" />.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public GameTypes Convert(string value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            GameTypes result;
            if (Enum.TryParse(value, true, out result))
            {
                return result;
            }

            return default(GameTypes);
        }
    }
}