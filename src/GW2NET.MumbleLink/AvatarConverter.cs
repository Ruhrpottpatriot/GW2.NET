namespace GW2NET.MumbleLink
{
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization.Json;
    using System.Text;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.MumbleLink.Interop;

    internal class AvatarConverter : IConverter<AvatarDataContract, Avatar>
    {
        private readonly IConverter<MumbleContext, AvatarContext> avatarContextConverter;

        private readonly IConverter<IdentityDataContract, Identity> identityConverter;

        private readonly IConverter<float[], Vector3D> vector3DConverter;

        public AvatarConverter(IConverter<MumbleContext, AvatarContext> avatarContextConverter, IConverter<IdentityDataContract, Identity> identityConverter, IConverter<float[], Vector3D> vector3DConverter)
        {
            this.avatarContextConverter = avatarContextConverter;
            this.identityConverter = identityConverter;
            this.vector3DConverter = vector3DConverter;
        }

        public Avatar Convert(AvatarDataContract value)
        {
            var contextLength = (int)value.context_len;
            var ptr = Marshal.AllocHGlobal(contextLength);
            Marshal.Copy(value.context, 0, ptr, contextLength);
            var mumbleContext = (MumbleContext)Marshal.PtrToStructure(ptr, typeof(MumbleContext));

            var avatarContext = this.avatarContextConverter.Convert(mumbleContext);
            avatarContext.SetInnerContext(value.context);

            IdentityDataContract identityDataContract;
            using (var stringStream = new MemoryStream(Encoding.UTF8.GetBytes(value.identity)))
            {
                var serializer = new DataContractJsonSerializer(typeof(IdentityDataContract));
                identityDataContract = (IdentityDataContract)serializer.ReadObject(stringStream);
            }

            return new Avatar
            {
                UiVersion = (int)value.uiVersion,
                UiTick = value.uiTick,
                Context = avatarContext,
                Identity = this.identityConverter.Convert(identityDataContract),
                AvatarFront = this.vector3DConverter.Convert(value.fAvatarFront),
                AvatarTop = this.vector3DConverter.Convert(value.fAvatarPosition),
                AvatarPosition = this.vector3DConverter.Convert(value.fAvatarPosition),
                CameraFront = this.vector3DConverter.Convert(value.fCameraFront),
                CameraPosition = this.vector3DConverter.Convert(value.fCameraPosition)
            };

        }
    }
}
