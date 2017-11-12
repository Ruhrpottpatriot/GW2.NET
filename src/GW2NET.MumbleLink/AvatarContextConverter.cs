namespace GW2NET.MumbleLink
{
    using System;
    using System.Net;

    using GW2NET.Common;
    using GW2NET.MumbleLink.Interop;

    internal class AvatarContextConverter : IConverter<MumbleContext, AvatarContext>
    {
        private readonly IConverter<SockaddrIn, IPEndPoint> ipEndPointConverter;

        public AvatarContextConverter(IConverter<SockaddrIn, IPEndPoint> ipEndPointConverter)
        {
            if (ipEndPointConverter == null)
            {
                throw new ArgumentNullException("ipEndPointConverter");
            }

            this.ipEndPointConverter = ipEndPointConverter;
        }

        public AvatarContext Convert(MumbleContext value)
        {
            return new AvatarContext
            {
                ServerAddress = this.ipEndPointConverter.Convert(value.serverAddress),
                MapId = (int)value.mapId,
                MapType = (int)value.mapType,
                ShardId = (int)value.shardId,
                Instance = (int)value.instance,
                BuildId = (int)value.buildId
            };
        }
    }
}
