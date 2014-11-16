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
    using GW2NET.V1.Maps;

    public sealed class FactoryForV1MapNames : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FactoryForV1MapNames(IServiceClient serviceClient)
            : base(serviceClient)
        {
            Contract.Requires(serviceClient != null);
        }

        [IndexerName("Language")]
        public IMapNameRepository this[string language]
        {
            get
            {
                Contract.Ensures(Contract.Result<IMapNameRepository>() != null);
                IMapNameRepository repository = new MapNameRepository(this.ServiceClient);
                repository.Culture = new CultureInfo(language);
                return repository;
            }
        }


        public IMapNameRepository Default
        {
            get
            {
                Contract.Ensures(Contract.Result<IMapNameRepository>() != null);
                return new MapNameRepository(this.ServiceClient);
            }
        }

        public IMapNameRepository ForCurrentCulture
        {
            get
            {
                Contract.Ensures(Contract.Result<IMapNameRepository>() != null);
                return this[CultureInfo.CurrentCulture.TwoLetterISOLanguageName];
            }
        }

        public IMapNameRepository ForCurrentUICulture
        {
            get
            {
                Contract.Ensures(Contract.Result<IMapNameRepository>() != null);
                return this[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName];
            }
        }
    }
}
