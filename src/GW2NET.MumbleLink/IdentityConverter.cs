namespace GW2NET.MumbleLink
{
    using System;

    using GW2NET.Common;

    internal class IdentityConverter : IConverter<IdentityDataContract, Identity>
    {
        public Identity Convert(IdentityDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new Identity
            {
                Name = value.Name,
                Profession = (Profession)value.Profession,
                Race = (Race)value.Race,
                MapId = value.MapId,
                WorldId = value.WorldId,
                TeamColorId = value.TeamColorId,
                Commander = value.Commander,
                FieldOfView = value.FieldOfView
            };
        }
    }
}