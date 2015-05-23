namespace GW2NET.MumbleLink
{
    using System.IO;
    using System.IO.MemoryMappedFiles;

    using GW2NET.Common;

    using Xunit;

    public class MumbleLinkFileTests
    {
        [Theory]
        [InlineData(@"blobs\1.bin", 1)]
        [InlineData(@"blobs\2.bin", 2)]
        public void CanRead(string fileName, int uiTick)
        {
            Assert.True(File.Exists(fileName), "File.Exists(fileName)");
            using (var memoryMappedFile = MemoryMappedFile.CreateFromFile(fileName))
            using (
                var mumbleLinkFile = new MumbleLinkFile(
                    memoryMappedFile,
                    new AvatarConverter(
                        new AvatarContextConverter(new IPEndPointConverter()),
                        new IdentityConverter(),
                        new Vector3DConverter())))
            {
                var avatar = mumbleLinkFile.Read();
                Assert.NotNull(avatar);
                Assert.Equal(uiTick, avatar.UiTick);
                Assert.NotNull(avatar.Context);
                Assert.NotNull(avatar.Identity);
                Assert.Equal("Isaac Newerton", avatar.Identity.Name);
                Assert.Equal(Profession.Engineer, avatar.Identity.Profession);
                Assert.Equal(Race.Human, avatar.Identity.Race);
                Assert.NotNull(avatar.Identity.Profession == Profession.Engineer);
                Assert.NotNull(avatar.Identity.Race == Race.Human);
            }
        }
    }
}