// <copyright file="AvatarConverter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.MumbleLink.Converters
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization.Json;
    using System.Text;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.MumbleLink.Interop;

    [CLSCompliant(false)]
    public sealed class AvatarConverter : IConverter<AvatarDTO, Avatar>
    {
        private static readonly DataContractJsonSerializer JsonSerializer = new DataContractJsonSerializer(typeof(IdentityDTO));

        private readonly IConverter<MumbleContext, AvatarContext> avatarContextConverter;

        private readonly IConverter<IdentityDTO, Identity> identityConverter;

        private readonly IConverter<float[], Vector3D> vector3DConverter;

        public AvatarConverter(
            IConverter<MumbleContext, AvatarContext> avatarContextConverter,
            IConverter<IdentityDTO, Identity> identityConverter,
            IConverter<float[], Vector3D> vector3DConverter)
        {
            if (avatarContextConverter == null)
            {
                throw new ArgumentNullException("avatarContextConverter");
            }

            if (identityConverter == null)
            {
                throw new ArgumentNullException("identityConverter");
            }

            if (vector3DConverter == null)
            {
                throw new ArgumentNullException("vector3DConverter");
            }

            this.avatarContextConverter = avatarContextConverter;
            this.identityConverter = identityConverter;
            this.vector3DConverter = vector3DConverter;
        }

        public Avatar Convert(AvatarDTO value, object state)
        {
            var contextLength = (int)value.context_len;
            var ptr = Marshal.AllocHGlobal(contextLength);
            Marshal.Copy(value.context, 0, ptr, contextLength);
            var mumbleContext = (MumbleContext)Marshal.PtrToStructure(ptr, typeof(MumbleContext));

            var avatarContext = this.avatarContextConverter.Convert(mumbleContext, state);
            avatarContext.SetInnerContext(value.context);

            IdentityDTO identity;
            using (var stream = new MemoryStream(Encoding.Unicode.GetBytes(value.identity)))
            {
                identity = (IdentityDTO)JsonSerializer.ReadObject(stream);
            }

            return new Avatar
            {
                UiVersion = (int)value.uiVersion,
                UiTick = value.uiTick,
                Context = avatarContext,
                Identity = this.identityConverter.Convert(identity, value),
                AvatarFront = this.vector3DConverter.Convert(value.fAvatarFront, value),
                AvatarTop = this.vector3DConverter.Convert(value.fAvatarPosition, value),
                AvatarPosition = this.vector3DConverter.Convert(value.fAvatarPosition, value),
                CameraFront = this.vector3DConverter.Convert(value.fCameraFront, value),
                CameraPosition = this.vector3DConverter.Convert(value.fCameraPosition, value)
            };
        }
    }
}
