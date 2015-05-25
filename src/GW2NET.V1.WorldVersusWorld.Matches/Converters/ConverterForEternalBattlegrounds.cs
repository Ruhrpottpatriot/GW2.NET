// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForEternalBattlegrounds.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="CompetitiveMapDataContract" /> to objects of type <see cref="EternalBattlegrounds" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.V1.WorldVersusWorld.Matches.Json;
using GW2NET.WorldVersusWorld;

namespace GW2NET.V1.WorldVersusWorld.Matches.Converters
{
    /// <summary>Converts objects of type <see cref="CompetitiveMapDataContract"/> to objects of type <see cref="EternalBattlegrounds"/>.</summary>
    internal sealed class ConverterForEternalBattlegrounds : IConverter<CompetitiveMapDataContract, EternalBattlegrounds>
    {
        /// <summary>Converts the given object of type <see cref="CompetitiveMapDataContract"/> to an object of type <see cref="EternalBattlegrounds"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public EternalBattlegrounds Convert(CompetitiveMapDataContract value)
        {
            Contract.Assume(value != null);
            Contract.Assume(value.Type == "Center");
            return new EternalBattlegrounds();
        }
    }
}