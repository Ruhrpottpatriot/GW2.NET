using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2.NET.MumbleLink
{
    using System.IO;
    using System.IO.MemoryMappedFiles;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization.Json;

    public partial class MumbleLinkFile : IDisposable
    {
        private bool disposed;

        private readonly int size;

        private readonly MemoryMappedFile mumbleLink;

        public MumbleLinkFile()
        {
            this.size = Marshal.SizeOf(typeof(AvatarDataContract));
            this.mumbleLink = MemoryMappedFile.CreateOrOpen("MumbleLink", this.size, MemoryMappedFileAccess.ReadWrite);
        }

        public Avatar Read()
        {
            var buffer = new byte[this.size];
            using (var stream = this.mumbleLink.CreateViewStream())
            {
                stream.Read(buffer, 0, buffer.Length);
                var avatarDataContract = FromBytes(buffer);

                // TODO: override Equals()
                if (avatarDataContract.Equals(default(AvatarDataContract)))
                {
                    return null;
                }

                return ConvertAvatarDataContract(avatarDataContract);
            }
        }

        private Avatar ConvertAvatarDataContract(AvatarDataContract dataContract)
        {
            return new Avatar
                {
                    Context = ConvertAvatarContextDataContract(dataContract.context),
                    Identity = ConvertIdentityDataContract(dataContract.identity)
                };
        }

        private static Identity ConvertIdentityDataContract(string identity)
        {
            var serializer = new DataContractJsonSerializer(typeof(IdentityDataContract));

            IdentityDataContract dataContract;
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(identity)))
            {
                dataContract = (IdentityDataContract)serializer.ReadObject(stream);
            }

            return new Identity
            {
                Name = dataContract.Name,
                Profession = dataContract.Profession,
                MapId = dataContract.MapId,
                WorldId = dataContract.WorldId,
                TeamColorId = dataContract.TeamColorId,
                Commander = dataContract.Commander
            };
        }

        private static AvatarContext ConvertAvatarContextDataContract(MumbleContext context)
        {
            return new AvatarContext
                {
                    ServerAddress = ConvertServerAddress(context.serverAddress),
                    MapId = (int)context.mapId,
                    MapType = (int)context.mapType,
                    ShardId = (int)context.shardId,
                    Instance = (int)context.instance,
                    BuildId = (int)context.buildId
                };
        }

        private static IPEndPoint ConvertServerAddress(SockaddrIn serverAddress)
        {
            return new IPEndPoint(
                new IPAddress(
                    new[]
                    {
                        serverAddress.sin_addr.S_un.S_un_b.s_b1,
                        serverAddress.sin_addr.S_un.S_un_b.s_b2,
                        serverAddress.sin_addr.S_un.S_un_b.s_b3,
                        serverAddress.sin_addr.S_un.S_un_b.s_b4
                    }),
                    serverAddress.sin_port);
        }

        internal static AvatarDataContract FromBytes(byte[] buffer)
        {
            return (AvatarDataContract)Marshal.PtrToStructure(ToUnmanaged(buffer), typeof(AvatarDataContract));
        }

        internal static IntPtr ToUnmanaged(byte[] bytes)
        {
            var ptr = Marshal.AllocHGlobal(bytes.Length);
            Marshal.Copy(bytes, 0, ptr, bytes.Length);
            return ptr;
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.disposed)
                {
                    return;
                }

                this.mumbleLink.Dispose();
                this.disposed = true;
            }
        }
    }
}
