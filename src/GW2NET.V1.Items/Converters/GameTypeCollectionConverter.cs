// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameTypeCollectionConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="GameTypes" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="GameTypes"/>.</summary>
    public sealed class GameTypeCollectionConverter : IConverter<ICollection<string>, GameTypes>
    {
        private readonly IConverter<string, GameTypes> gameTypeConverter;

        /// <summary>Initializes a new instance of the <see cref="GameTypeCollectionConverter"/> class.</summary>
        /// <param name="gameTypeConverter">The converter for <see cref="GameTypes"/>.</param>
        public GameTypeCollectionConverter(IConverter<string, GameTypes> gameTypeConverter)
        {
            if (gameTypeConverter == null)
            {
                throw new ArgumentNullException("gameTypeConverter");
            }

            this.gameTypeConverter = gameTypeConverter;
        }

        /// <inheritdoc />
        public GameTypes Convert(ICollection<string> value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var result = default(GameTypes);
            foreach (var s in value)
            {
                result |= this.gameTypeConverter.Convert(s, state);
            }

            return result;
        }
    }
}