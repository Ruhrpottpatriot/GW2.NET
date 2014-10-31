using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2NET.Factories
{
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Runtime.CompilerServices;

    using GW2NET.Common;
    using GW2NET.Entities.Maps;
    using GW2NET.V1.Continents;

    public sealed class FactoryForV1Continents : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FactoryForV1Continents(IServiceClient serviceClient)
            : base(serviceClient)
        {
            Contract.Requires(serviceClient != null);
        }

        [IndexerName("Language")]
        public IRepository<int, Continent> this[string language]
        {
            get
            {
                Contract.Ensures(Contract.Result<IRepository<int, Continent>>() != null);
                return new ContinentRepository(this.ServiceClient) { Culture = new CultureInfo(language) };
            }
        }

        public IRepository<int, Continent> Default
        {
            get
            {
                Contract.Ensures(Contract.Result<IRepository<int, Continent>>() != null);
                return new ContinentRepository(this.ServiceClient);
            }
        }

        public IRepository<int, Continent> ForCurrentCulture
        {
            get
            {
                Contract.Ensures(Contract.Result<IRepository<int, Continent>>() != null);
                return this[CultureInfo.CurrentCulture.TwoLetterISOLanguageName];
            }
        }

        public IRepository<int, Continent> ForCurrentUICulture
        {
            get
            {
                Contract.Ensures(Contract.Result<IRepository<int, Continent>>() != null);
                return this[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName];
            }
        }
    }
}
