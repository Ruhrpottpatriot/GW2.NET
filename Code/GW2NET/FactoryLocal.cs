using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2NET
{
    using GW2NET.Common.Serializers;
    using GW2NET.Local.DynamicEvents;
    using GW2NET.Local.Worlds;
    using GW2NET.V1.Worlds;

    public class FactoryLocal
    {
        public IWorldNameService Worlds
        {
            get
            {
                return new OfflineWorldService(new JsonSerializerFactory());
            }
        }

        public IDynamicEventRotationService EventRotations
        {
            get
            {
                return new DynamicEventRotationService();
            }
        }
    }
}
