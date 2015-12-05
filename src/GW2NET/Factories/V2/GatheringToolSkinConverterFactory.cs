using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2NET.Factories.V2
{
    using System.Diagnostics;
    using Common;
    using GW2NET.V2.Skins.Converters;
    using GW2NET.V2.Skins.Json;
    using Skins;
    public class GatheringToolSkinConverterFactory : ITypeConverterFactory<SkinDTO, GatheringToolSkin>
    {
        public IConverter<SkinDTO, GatheringToolSkin> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "Foraging":
                    return new ForagingToolSkinConverter();
                case "Logging":
                    return new LoggingToolSkinConverter();
                case "Mining":
                    return new MiningToolSkinConverter();
                default:
                    Debug.Assert(false, "Unknown type discriminator: " + discriminator);
                    return new UnknownGatheringToolSkinConverter();
            }
        }
    }
}
