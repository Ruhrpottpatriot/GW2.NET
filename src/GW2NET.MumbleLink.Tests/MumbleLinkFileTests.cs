namespace GW2NET.MumbleLink
{
    using System.IO;
    using System.IO.MemoryMappedFiles;

    using GW2NET.Common;
    using GW2NET.MumbleLink.Converters;

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
                        new IdentityConverter(new ProfessionConverter(), new RaceConverter()),
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
            }
        }

        [Theory]
        [InlineData(@"blobs\1.bin", @"blobs\2.bin")]
        public void CanCompareAvatarContext(string fileName1, string fileName2)
        {
            Assert.True(File.Exists(fileName1), "File.Exists(fileName1)");
            Assert.True(File.Exists(fileName2), "File.Exists(fileName2)");
            using (var memoryMappedFile1 = MemoryMappedFile.CreateFromFile(fileName1))
            using (
                var mumbleLinkFile1 = new MumbleLinkFile(
                    memoryMappedFile1,
                    new AvatarConverter(
                        new AvatarContextConverter(new IPEndPointConverter()),
                        new IdentityConverter(new ProfessionConverter(), new RaceConverter()),
                        new Vector3DConverter())))
            using (var memoryMappedFile2 = MemoryMappedFile.CreateFromFile(fileName2))
            using (
                var mumbleLinkFile2 = new MumbleLinkFile(
                    memoryMappedFile2,
                    new AvatarConverter(
                        new AvatarContextConverter(new IPEndPointConverter()),
                        new IdentityConverter(new ProfessionConverter(), new RaceConverter()),
                        new Vector3DConverter())))
            {
                var avatar1 = mumbleLinkFile1.Read();
                var avatar2 = mumbleLinkFile2.Read();
                Assert.Equal(avatar1.Context, avatar2.Context);
            }
        }
    }
}