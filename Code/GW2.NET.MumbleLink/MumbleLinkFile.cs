namespace GW2DotNET.MumbleLink
{
    using System;
    using System.IO;
    using System.IO.MemoryMappedFiles;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization.Json;
    using System.Text;

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
                // Copy the shared memory block to a local buffer in managed memory
                stream.Read(buffer, 0, buffer.Length);

                // Pin the managed memory so that the GC doesn't move it
                var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);

                // Get the address of the managed memory
                var ptr = handle.AddrOfPinnedObject();

                // Copy the managed memory to a managed struct
                var avatarDataContract = (AvatarDataContract)Marshal.PtrToStructure(ptr, typeof(AvatarDataContract));

                // Ensure that data is available and that it has a well known format
                // MEMO: the context length for GW2 is always 48 of 256 bytes
                if (avatarDataContract.context_len != 48)
                {
                    return null;
                }

                // Convert data contracts to managed data types
                return ConvertAvatarDataContract(avatarDataContract);
            }
        }

        private static Avatar ConvertAvatarDataContract(AvatarDataContract dataContract)
        {
            // Copy the context data to an unmanaged memory pointer
            var contextLength = (int)dataContract.context_len;
            var ptr = Marshal.AllocHGlobal(contextLength);
            Marshal.Copy(dataContract.context, 0, ptr, contextLength);

            // Copy the unmanaged memory to a managed struct
            var mumbleContext = (MumbleContext)Marshal.PtrToStructure(ptr, typeof(MumbleContext));

            // Convert data contracts to managed data types
            return new Avatar
            {
                Context = ConvertAvatarContextDataContract(mumbleContext),
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
