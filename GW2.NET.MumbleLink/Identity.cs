using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2.NET.MumbleLink
{
    using GW2DotNET.Entities.Maps;
    using GW2DotNET.Entities.Worlds;

    public class Identity
    {
        public string Name { get; set; }

        public int Profession { get; set; }

        public int MapId { get; set; }

        public Map Map { get; set; }

        public long WorldId { get; set; }

        public World World { get; set; }

        public int TeamColorId { get; set; }

        public bool Commander { get; set; }
    }
}
