// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmblemContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a guild's emblem.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Guilds.Json
{
    using System.Runtime.Serialization;

    /// <summary>Represents a guild's emblem.</summary>
    [DataContract]
    public sealed class EmblemContract
    {
        /// <summary>Gets or sets the background color identifier.</summary>
        [DataMember(Name = "background_color_id", Order = 3)]
        public int BackgroundColorId { get; set; }

        /// <summary>Gets or sets the background image identifier.</summary>
        [DataMember(Name = "background_id", Order = 0)]
        public int BackgroundId { get; set; }

        /// <summary>Gets or sets the image transformations.</summary>
        [DataMember(Name = "flags", Order = 2)]
        public string[] Flags { get; set; }

        /// <summary>Gets or sets the foreground image identifier.</summary>
        [DataMember(Name = "foreground_id", Order = 1)]
        public int ForegroundId { get; set; }

        /// <summary>Gets or sets the primary foreground color identifier.</summary>
        [DataMember(Name = "foreground_primary_color_id", Order = 4)]
        public int ForegroundPrimaryColorId { get; set; }

        /// <summary>Gets or sets the secondary foreground color identifier.</summary>
        [DataMember(Name = "foreground_secondary_color_id", Order = 5)]
        public int ForegroundSecondaryColorId { get; set; }
    }
}