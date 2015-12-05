// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameTypeConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="GameTypes" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;
    using System.Diagnostics;
    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="GameTypes"/>.</summary>
    public sealed class GameTypeConverter : IConverter<string, GameTypes>
    {
        /// <inheritdoc />
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

            Debug.Assert(false, "Unknown GameTypes: " + value);
            return default(GameTypes);
        }
    }
}