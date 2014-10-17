using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2NET
{
    using GW2NET.Common;
    using GW2NET.V1.Builds;
    using GW2NET.V1.Colors;
    using GW2NET.V1.DynamicEvents;
    using GW2NET.V1.Files;
    using GW2NET.V1.Guilds;
    using GW2NET.V1.Items;
    using GW2NET.V1.Maps;
    using GW2NET.V1.Recipes;
    using GW2NET.V1.Skins;
    using GW2NET.V1.Worlds;

    public static partial class GW2
    {
        public partial class Factory1
        {
            public IBuildService Build
            {
                get
                {
                    return new BuildService(this.ServiceClient);
                }
            }

            public IColorService Colors
            {
                get
                {
                    return new ColorService(this.ServiceClient);
                }
            }

            public IContinentDetailsService Continents
            {
                get
                {
                    return new MapService(this.ServiceClient);
                }
            }

            public IDynamicEventDetailsService Events
            {
                get
                {
                    return new DynamicEventService(this.ServiceClient);
                }
            }

            public IDynamicEventStateService EventStates
            {
                get
                {
                    return new DynamicEventService(this.ServiceClient);
                }
            }

            public IDynamicEventStateService EventNames
            {
                get
                {
                    return new DynamicEventService(this.ServiceClient);
                }
            }

            public IFileService Files
            {
                get
                {
                    return new FileService(this.ServiceClient);
                }
            }

            public IGuildDetailsService Guilds
            {
                get
                {
                    return new GuildService(this.ServiceClient);
                }
            }

            public IItemService Items
            {
                get
                {
                    return new ItemService(this.ServiceClient);
                }
            }

            public IMapDetailsService Maps
            {
                get
                {
                    return new MapService(this.ServiceClient);
                }
            }

            public IMapFloorService Floors
            {
                get
                {
                    return new MapService(this.ServiceClient);
                }
            }

            public IMapNameService MapNames
            {
                get
                {
                    return new MapService(this.ServiceClient);
                }
            }

            public IRecipeService Recipes
            {
                get
                {
                    return new RecipeService(this.ServiceClient);
                }
            }

            public ISkinService Skins
            {
                get
                {
                    return new SkinService(this.ServiceClient);
                }
            }

            public IWorldService Worlds
            {
                get
                {
                    return new WorldService(this.ServiceClient);
                }
            }

            public WvWFactory1 WvW
            {
                get
                {
                    return new WvWFactory1(this.ServiceClient);
                }
            }
        }
    }
}
