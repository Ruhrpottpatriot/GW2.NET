namespace GW2NET.V2.Files
{
    using System.Runtime.Serialization;

    [DataContract]
    internal sealed class FileDataContract
    {
        [DataMember(Name = "id", Order = 0)]
        public string Id { get; set; }

        [DataMember(Name = "icon", Order = 1)]
        public string Icon { get; set; }
    }
}