// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MumbleLinkFile.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
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
    using GW2NET.MumbleLink.Converters;
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
    [CLSCompliant(false)]
    public sealed class MumbleLinkFile : IDisposable
    {
        /// <summary>The name of the shared memory mapped file.</summary>
        public const string MapName = "MumbleLink";

        private static readonly Lazy<long> LazyPreferredCapacity = new Lazy<long>(GetPreferredCapacity);

        private readonly IConverter<AvatarDTO, Avatar> avatarConverter;

        /// <summary>Holds a reference to the shared memory block.</summary>
        private readonly MemoryMappedFile memoryMappedFile;

        /// <summary>Indicates whether this object is disposed.</summary>
        private bool disposed;

        /// <summary>Initializes a new instance of the <see cref="MumbleLinkFile"/> class.</summary>
        /// <param name="memoryMappedFile"></param>
        /// <param name="avatarConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MumbleLinkFile(MemoryMappedFile memoryMappedFile, IConverter<AvatarDTO, Avatar> avatarConverter)
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
                new IdentityConverter(new ProfessionConverter(), new RaceConverter()),
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
        /// <exception cref="ObjectDisposedException">Method was called after the memory mapped file was closed.</exception>
        /// <exception cref="UnauthorizedAccessException">Access to the memory-mapped file is unauthorized.</exception>
        /// <exception cref="MumbleException">A serialization error occurred while reading from the Mumble Link shared memory block.</exception>
        public Avatar Read()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }

            using (var stream = this.memoryMappedFile.CreateViewStream())
            {
                var buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);

                // Pin the managed memory so that the GC doesn't move it
                var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                var ptr = handle.AddrOfPinnedObject();
                AvatarDTO avatar;
                try
                {
                    avatar = (AvatarDTO)Marshal.PtrToStructure(ptr, typeof(AvatarDTO));
                }
                finally
                {
                    handle.Free();
                }

                // Ensure that data is available and that it was generated by Guild Wars 2
                if (!avatar.name.Equals("Guild Wars 2", StringComparison.Ordinal))
                {
                    return null;
                }

                try
                {
                    return this.avatarConverter.Convert(avatar, null);
                }
                catch (SerializationException exception)
                {
                    throw new MumbleException("A serialization error occurred while reading from the Mumble Link shared memory block.", exception);
                }
            }
        }

        private static long GetPreferredCapacity()
        {
            return Marshal.SizeOf(typeof(AvatarDTO));
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        /// <param name="disposing"><c>true</c> if managed resources should be released.</param>
        private void Dispose(bool disposing)
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
    }
}