// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Emblem.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a guild's emblem.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Guilds
{
    using GW2NET.Colors;

    /// <summary>Represents a guild's emblem.</summary>
    public class Emblem
    {
        /// <summary>Gets or sets the background color. This is a navigation property. Use the value of <see cref="BackgroundColorId"/> to obtain a reference.</summary>
        public virtual ColorPalette BackgroundColor { get; set; }

        /// <summary>Gets or sets the background color identifier.</summary>
        public virtual int BackgroundColorId { get; set; }

        /// <summary>Gets or sets the background image identifier.</summary>
        public virtual int BackgroundId { get; set; }

        /// <summary>Gets or sets the image transformations.</summary>
        public virtual EmblemTransformations Flags { get; set; }

        /// <summary>Gets or sets the foreground image identifier.</summary>
        public virtual int ForegroundId { get; set; }

        /// <summary>Gets or sets the primary foreground color. This is a navigation property. Use the value of <see cref="ForegroundPrimaryColorId"/> to obtain a reference.</summary>
        public virtual ColorPalette ForegroundPrimaryColor { get; set; }

        /// <summary>Gets or sets the primary foreground color identifier.</summary>
        public virtual int ForegroundPrimaryColorId { get; set; }

        /// <summary>Gets or sets the secondary foreground color. This is a navigation property. Use the value of <see cref="ForegroundSecondaryColorId"/> to obtain a reference.</summary>
        public virtual ColorPalette ForegroundSecondaryColor { get; set; }

        /// <summary>Gets or sets the secondary foreground color identifier.</summary>
        public virtual int ForegroundSecondaryColorId { get; set; }
    }
}