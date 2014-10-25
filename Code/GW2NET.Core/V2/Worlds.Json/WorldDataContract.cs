using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2NET.V2.Worlds.Json
{
    using System.Runtime.Serialization;

    [DataContract]
    internal sealed class WorldDataContract
    {
        [DataMember(Order = 0, Name = "id")]
        public int Id { get; set; }

        [DataMember(Order = 1, Name = "name")]
        public string Name { get; set; }
    }
}
