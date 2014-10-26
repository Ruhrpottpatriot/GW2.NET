using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2NET.Factories
{
    using System.Globalization;
    using System.Runtime.CompilerServices;

    using GW2NET.Common;
    using GW2NET.Entities.Maps;
    using GW2NET.Entities.WorldVersusWorld;
    using GW2NET.V1.Maps;
    using GW2NET.V1.WorldVersusWorld.Objectives;

    public sealed class FactoryForV1MapNames : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FactoryForV1MapNames(IServiceClient serviceClient)
            : base(serviceClient)
        {
        }

        [IndexerName("Language")]
        public IRepository<int, MapName> this[string language]
        {
            get
            {
                return new MapNameRepository(this.ServiceClient) { Culture = new CultureInfo(language) };
            }
        }


        public IRepository<int, MapName> Default
        {
            get
            {
                return new MapNameRepository(this.ServiceClient);
            }
        }

        public IRepository<int, MapName> ForCurrentCulture
        {
            get
            {
                return this[CultureInfo.CurrentCulture.TwoLetterISOLanguageName];
            }
        }

        public IRepository<int, MapName> ForCurrentUICulture
        {
            get
            {
                return this[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName];
            }
        }
    }
}
