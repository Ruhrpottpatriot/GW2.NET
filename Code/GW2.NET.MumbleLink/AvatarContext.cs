

namespace GW2DotNET.MumbleLink
{
    using System.Net;

    public class AvatarContext
    {
        public IPEndPoint ServerAddress { get; set; }

        public int MapId { get; set; }

        public int MapType { get; set; }

        public int ShardId { get; set; }

        public int Instance { get; set; }

        public int BuildId { get; set; }
    }
}
