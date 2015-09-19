namespace GW2NET.MumbleLink.Converters
{
    using GW2NET.Common;

    public class ProfessionConverter : IConverter<int, Profession>
    {
        public Profession Convert(int value, object state)
        {
            switch (value)
            {
                case 1:
                    return Profession.Guardian;
                case 2:
                    return Profession.Warrior;
                case 3:
                    return Profession.Engineer;
                case 4:
                    return Profession.Ranger;
                case 5:
                    return Profession.Thief;
                case 6:
                    return Profession.Elementalist;
                case 7:
                    return Profession.Mesmer;
                case 8:
                    return Profession.Necromancer;
                default:
                    return Profession.Unknown;
            }
        }
    }
}