// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Emblem.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a guild's emblem.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Guilds.Details.Contracts
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;

    /// <summary>Represents a guild's emblem.</summary>
    public class Emblem : JsonObject
    {
        /// <summary>Gets or sets the background color ID.</summary>
        [DataMember(Name = "background_color_id")]
        public int BackgroundColorId { get; set; }

        /// <summary>Gets or sets the background image ID.</summary>
        [DataMember(Name = "background_id")]
        public int BackgroundId { get; set; }

        /// <summary>Gets or sets the image transformations, if any.</summary>
        [DataMember(Name = "flags")]
        public EmblemTransformations Flags { get; set; }

        /// <summary>Gets or sets the foreground image ID.</summary>
        [DataMember(Name = "foreground_id")]
        public int ForegroundId { get; set; }

        /// <summary>Gets or sets the primary foreground color ID.</summary>
        [DataMember(Name = "foreground_primary_color_id")]
        public int ForegroundPrimaryColorId { get; set; }

        /// <summary>Gets or sets the secondary foreground color ID.</summary>
        [DataMember(Name = "foreground_secondary_color_id")]
        public int ForegroundSecondaryColorId { get; set; }
    }
}