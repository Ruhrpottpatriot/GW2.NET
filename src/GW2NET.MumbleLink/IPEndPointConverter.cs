namespace GW2NET.MumbleLink
{
    using System.Net;

    using GW2NET.Common;
    using GW2NET.MumbleLink.Interop;

    internal class IPEndPointConverter : IConverter<SockaddrIn, IPEndPoint>
    {
        public IPEndPoint Convert(SockaddrIn value)
        {
            return
                new IPEndPoint(
                    new IPAddress(
                        new[]
                            {
                                value.sin_addr.S_un.S_un_b.s_b1,
                                value.sin_addr.S_un.S_un_b.s_b2,
                                value.sin_addr.S_un.S_un_b.s_b3,
                                value.sin_addr.S_un.S_un_b.s_b4
                            }),
                    value.sin_port);
        }
    }
}