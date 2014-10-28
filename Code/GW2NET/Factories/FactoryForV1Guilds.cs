using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2NET.Factories
{
    using GW2NET.Common;
    using GW2NET.Entities.Guilds;
    using GW2NET.V1.Guilds;

    public sealed class FactoryForV1Guilds : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FactoryForV1Guilds(IServiceClient serviceClient)
            : base(serviceClient)
        {
        }

        public IRepository<Guid, Guild> ById
        {
            get
            {
                return new GuildRepository(this.ServiceClient);
            }
        }

        public IRepository<string, Guild> ByName
        {
            get
            {
                return new GuildRepository(this.ServiceClient);
            }
        }
    }
}
