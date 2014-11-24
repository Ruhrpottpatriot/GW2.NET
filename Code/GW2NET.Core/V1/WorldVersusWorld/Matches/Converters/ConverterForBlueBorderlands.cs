// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForBlueBorderlands.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="CompetitiveMapDataContract" /> to objects of type <see cref="BlueBorderlands" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.WorldVersusWorld.Matches
{
    using System.Diagnostics.Contracts;
    using Common;
    using GW2NET.WorldVersusWorld;

    /// <summary>Converts objects of type <see cref="CompetitiveMapDataContract"/> to objects of type <see cref="BlueBorderlands"/>.</summary>
    internal sealed class ConverterForBlueBorderlands : IConverter<CompetitiveMapDataContract, BlueBorderlands>
    {
        /// <summary>Converts the given object of type <see cref="CompetitiveMapDataContract"/> to an object of type <see cref="BlueBorderlands"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public BlueBorderlands Convert(CompetitiveMapDataContract value)
        {
            Contract.Assume(value != null);
            Contract.Assume(value.Type == "BlueHome");
            return new BlueBorderlands();
        }
    }
}