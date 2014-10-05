namespace GW2DotNET.MumbleLink
{
    using System.Runtime.Serialization;

    [DataContract]
    internal class IdentityDataContract
    {
        [DataMember(Name = "name", Order = 0)]
        internal string Name { get; set; }

        [DataMember(Name = "profession", Order = 1)]
        internal int Profession { get; set; }

        [DataMember(Name = "map_id", Order = 2)]
        internal int MapId { get; set; }

        [DataMember(Name = "world_id", Order = 3)]
        internal long WorldId { get; set; }

        [DataMember(Name = "team_color_id", Order = 4)]
        internal int TeamColorId { get; set; }

        [DataMember(Name = "commander", Order = 5)]
        internal bool Commander { get; set; }
    }
}
