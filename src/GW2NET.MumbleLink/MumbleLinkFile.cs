// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MumbleLinkFile.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides an implementation of the Mumble Link protocol.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.MumbleLink
{
    using System;
    using System.IO.MemoryMappedFiles;
    using System.Runtime.InteropServices;

    using GW2NET.Common;
    using GW2NET.MumbleLink.Interop;

    /// <summary>Provides an implementation of the Mumble Link protocol.</summary>
    /// <example>
    ///     <code>
    /// using (var mumbler = MumbleLinkFile.CreateOrOpen())
    /// {
    ///     var avatar = mumbler.Read();
    ///     Console.WriteLine("Hello " + avatar.Identity.Name + "!");
    /// }
    /// </code>
    /// </example>
    public class MumbleLinkFile : IDisposable
    {
        public const string MapName = "MumbleLink";

        private static readonly Lazy<long> LazyPreferredCapacity = new Lazy<long>(GetPreferredCapacity);

        private readonly IConverter<AvatarDataContract, Avatar> avatarConverter;

        /// <summary>Holds a reference to the shared memory block.</summary>
        private readonly MemoryMappedFile memoryMappedFile;

        /// <summary>The size of the shared memory block.</summary>
        private readonly int size;

        /// <summary>Indicates whether this object is disposed.</summary>
        private bool disposed;

        public MumbleLinkFile(MemoryMappedFile memoryMappedFile, IConverter<AvatarDataContract, Avatar> avatarConverter)
        {
            if (memoryMappedFile == null)
            {
                throw new ArgumentNullException("memoryMappedFile");
            }

            if (avatarConverter == null)
            {
                throw new ArgumentNullException("avatarConverter");
            }

            this.memoryMappedFile = memoryMappedFile;
            this.avatarConverter = avatarConverter;
        }

        /// <summary>
        ///     Gets the preferred size for the memory mapped file.
        /// </summary>
        public static long PreferredCapacity
        {
            get
            {
                return LazyPreferredCapacity.Value;
            }
        }

        /// <summary>
        ///     Creates or opens a memory-mapped file for the MumbleLink protocol.
        /// </summary>
        /// <returns>An object that provides wrapper methods for the MumbleLink protocol.</returns>
        public static MumbleLinkFile CreateOrOpen()
        {
            var memoryMappedFile = MemoryMappedFile.CreateOrOpen(MapName, PreferredCapacity);
            var converter = new AvatarConverter(
                new AvatarContextConverter(new IPEndPointConverter()),
                new IdentityConverter(),
                new Vector3DConverter());
            return new MumbleLinkFile(memoryMappedFile, converter);
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>Retrieves positional audio data from the shared memory block as defined by the Mumble Link protocol.</summary>
        /// <returns>Positional audio data as an instance of the <see cref="Avatar" /> class.</returns>
        public Avatar Read()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }

            using (var stream = this.memoryMappedFile.CreateViewStream())
            {
                // Copy the shared memory block to a local buffer in managed memory
                var buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);

                // Pin the managed memory so that the GC doesn't move it
                var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);

                // Get the address of the managed memory
                var ptr = handle.AddrOfPinnedObject();

                AvatarDataContract avatarDataContract;

                try
                {
                    // Copy the managed memory to a managed struct
                    avatarDataContract = (AvatarDataContract)Marshal.PtrToStructure(ptr, typeof(AvatarDataContract));
                }
                finally
                {
                    // Release the handle
                    handle.Free();
                }

                // Ensure that data is available and that it was generated by Guild Wars 2
                if (!avatarDataContract.name.Equals("Guild Wars 2", StringComparison.Ordinal))
                {
                    return null;
                }

                // Convert data contracts to managed data types
                return this.avatarConverter.Convert(avatarDataContract);
            }
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        /// <param name="disposing"><c>true</c> if managed resources should be released.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                this.memoryMappedFile.Dispose();
            }

            this.disposed = true;
        }

        private static long GetPreferredCapacity()
        {
            return Marshal.SizeOf(typeof(AvatarDataContract));
        }
    }
}