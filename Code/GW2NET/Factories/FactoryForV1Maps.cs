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
    using GW2NET.V1.Maps;

    public sealed class FactoryForV1Maps : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FactoryForV1Maps(IServiceClient serviceClient)
            : base(serviceClient)
        {
        }

        [IndexerName("Language")]
        public IRepository<int, Map> this[string language]
        {
            get
            {
                return new MapRepository(this.ServiceClient) { Culture = new CultureInfo(language) };
            }
        }


        public IRepository<int, Map> Default
        {
            get
            {
                return new MapRepository(this.ServiceClient);
            }
        }

        public IRepository<int, Map> ForCurrentCulture
        {
            get
            {
                return this[CultureInfo.CurrentCulture.TwoLetterISOLanguageName];
            }
        }

        public IRepository<int, Map> ForCurrentUICulture
        {
            get
            {
                return this[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName];
            }
        }
    }
}
