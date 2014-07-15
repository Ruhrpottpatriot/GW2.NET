// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Emblem.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a guild's emblem.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Guilds.Contracts
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;
    using GW2DotNET.V1.Colors.Contracts;
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents a guild's emblem.</summary>
    public class Emblem : ServiceContract
    {
        /// <summary>Gets or sets the background color.</summary>
        [DataMember(Name = "background_color_id")]
        [JsonConverter(typeof(UnknownColorPaletteConverter))]
        public ColorPalette BackgroundColor { get; set; }

        /// <summary>Gets or sets the background image identifier.</summary>
        [DataMember(Name = "background_id")]
        public int BackgroundId { get; set; }

        /// <summary>Gets or sets the image transformations.</summary>
        [DataMember(Name = "flags")]
        public EmblemTransformations Flags { get; set; }

        /// <summary>Gets or sets the foreground image identifier.</summary>
        [DataMember(Name = "foreground_id")]
        public int ForegroundId { get; set; }

        /// <summary>Gets or sets the primary foreground color.</summary>
        [DataMember(Name = "foreground_primary_color_id")]
        [JsonConverter(typeof(UnknownColorPaletteConverter))]
        public ColorPalette ForegroundPrimaryColor { get; set; }

        /// <summary>Gets or sets the secondary foreground color.</summary>
        [DataMember(Name = "foreground_secondary_color_id")]
        [JsonConverter(typeof(UnknownColorPaletteConverter))]
        public ColorPalette ForegroundSecondaryColor { get; set; }
    }
}