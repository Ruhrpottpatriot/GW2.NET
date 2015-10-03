// <copyright file="AvatarContextConverter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.MumbleLink.Converters
{
    using System;
    using System.Net;

    using GW2NET.Common;
    using GW2NET.MumbleLink.Interop;

    [CLSCompliant(false)]
    public sealed class AvatarContextConverter : IConverter<MumbleContext, AvatarContext>
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

        public AvatarContext Convert(MumbleContext value, object state)
        {
            return new AvatarContext
            {
                ServerAddress = this.ipEndPointConverter.Convert(value.serverAddress, state),
                MapId = (int)value.mapId,
                MapType = (int)value.mapType,
                ShardId = (int)value.shardId,
                Instance = (int)value.instance,
                BuildId = (int)value.buildId
            };
        }
    }
}
