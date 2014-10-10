// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Avatar.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a player's avatar.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.MumbleLink
{
    using GW2DotNET.Entities.Maps;

    /// <summary>Represents a player's avatar.</summary>
    public class Avatar
    {
        /// <summary>Gets or sets the unit vector pointing out of the avatars eyes.</summary>
        public Vector3D AvatarFront { get; set; }

        /// <summary>Gets or sets the position of the avatar.</summary>
        public Vector3D AvatarPosition { get; set; }

        /// <summary>Gets or sets the unit vector pointing out of the top of the avatars head.</summary>
        public Vector3D AvatarTop { get; set; }

        /// <summary>Gets or sets the unit vector pointing out of the camera.</summary>
        public Vector3D CameraFront { get; set; }

        /// <summary>Gets or sets the position of the camera.</summary>
        public Vector3D CameraPosition { get; set; }

        /// <summary>Gets or sets the avatar's context.</summary>
        public AvatarContext Context { get; set; }

        /// <summary>Gets or sets the avatar's identity.</summary>
        public Identity Identity { get; set; }

        /// <summary>Gets or sets a numeric value that is used for change tracking.</summary>
        public long UiTick { get; set; }

        /// <summary>Gets or sets the UI version.</summary>
        public int UiVersion { get; set; }
    }
}