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
    using GW2NET.Maps;
    using GW2NET.V1.Maps;

    public sealed class FactoryForV1Maps : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FactoryForV1Maps(IServiceClient serviceClient)
            : base(serviceClient)
        {
            Contract.Requires(serviceClient != null);
        }

        [IndexerName("Language")]
        public IMapRepository this[string language]
        {
            get
            {
                Contract.Ensures(Contract.Result<IMapRepository>() != null);
                IMapRepository repository = new MapRepository(this.ServiceClient);
                repository.Culture = new CultureInfo(language);
                return repository;
            }
        }


        public IMapRepository Default
        {
            get
            {
                Contract.Ensures(Contract.Result<IMapRepository>() != null);
                return new MapRepository(this.ServiceClient);
            }
        }

        public IMapRepository ForCurrentCulture
        {
            get
            {
                Contract.Ensures(Contract.Result<IMapRepository>() != null);
                return this[CultureInfo.CurrentCulture.TwoLetterISOLanguageName];
            }
        }

        public IMapRepository ForCurrentUICulture
        {
            get
            {
                Contract.Ensures(Contract.Result<IMapRepository>() != null);
                return this[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName];
            }
        }
    }
}
