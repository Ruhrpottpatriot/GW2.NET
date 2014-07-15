// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatchDetailsSerializerSettings.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The match details serializer settings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld
{
    using GW2DotNET.V1.WorldVersusWorld.Converters;

    using Newtonsoft.Json;

    /// <summary>The match details serializer settings.</summary>
    public class MatchDetailsSerializerSettings : JsonSerializerSettings
    {
        /// <summary>Initializes a new instance of the <see cref="MatchDetailsSerializerSettings"/> class.</summary>
        public MatchDetailsSerializerSettings()
        {
            this.Converters.Add(new CompetitiveMapConverter());
            this.Converters.Add(new MapBonusConverter());
        }
    }
}