namespace GW2NET.Achievements
{
    using Skins;

    public class SkinBit : AchievementBit
    {
        public int SkinId { get; set; }

        public Skin Skin { get; set; }
    }
}