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
        public IContinentRepository this[string language]
        {
            get
            {
                Contract.Ensures(Contract.Result<IContinentRepository>() != null);
                IContinentRepository repository = new ContinentRepository(this.ServiceClient);
                repository.Culture = new CultureInfo(language);
                return repository;
            }
        }

        public IContinentRepository Default
        {
            get
            {
                Contract.Ensures(Contract.Result<IContinentRepository>() != null);
                return new ContinentRepository(this.ServiceClient);
            }
        }

        public IContinentRepository ForCurrentCulture
        {
            get
            {
                Contract.Ensures(Contract.Result<IContinentRepository>() != null);
                return this[CultureInfo.CurrentCulture.TwoLetterISOLanguageName];
            }
        }

        public IContinentRepository ForCurrentUICulture
        {
            get
            {
                Contract.Ensures(Contract.Result<IContinentRepository>() != null);
                return this[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName];
            }
        }
    }
}
