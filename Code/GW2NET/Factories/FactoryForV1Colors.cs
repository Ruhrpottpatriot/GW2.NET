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
    using GW2NET.Entities.Colors;
    using GW2NET.V1.Colors;

    public sealed class FactoryForV1Colors : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FactoryForV1Colors(IServiceClient serviceClient)
            : base(serviceClient)
        {
            Contract.Requires(serviceClient != null);
        }

        [IndexerName("Language")]
        public IColorRepository this[string language]
        {
            get
            {
                Contract.Ensures(Contract.Result<IColorRepository>() != null);
                IColorRepository repository = new ColorRepository(this.ServiceClient);
                repository.Culture = new CultureInfo(language);
                return repository;
            }
        }


        public IColorRepository Default
        {
            get
            {
                Contract.Ensures(Contract.Result<IColorRepository>() != null);
                return new ColorRepository(this.ServiceClient);
            }
        }

        public IColorRepository ForCurrentCulture
        {
            get
            {
                Contract.Ensures(Contract.Result<IColorRepository>() != null);
                return this[CultureInfo.CurrentCulture.TwoLetterISOLanguageName];
            }
        }

        public IColorRepository ForCurrentUICulture
        {
            get
            {
                Contract.Ensures(Contract.Result<IColorRepository>() != null);
                return this[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName];
            }
        }
    }
}
