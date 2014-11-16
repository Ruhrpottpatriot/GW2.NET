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
    using GW2NET.V1.WorldVersusWorld.Objectives;
    using GW2NET.V2.Items;
    using GW2NET.WorldVersusWorld.Objectives;

    public sealed class FactoryForV1WvWObjectives : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FactoryForV1WvWObjectives(IServiceClient serviceClient)
            : base(serviceClient)
        {
            Contract.Requires(serviceClient != null);
        }

        [IndexerName("Language")]
        public IObjectiveNameRepository this[string language]
        {
            get
            {
                Contract.Ensures(Contract.Result<IObjectiveNameRepository>() != null);
                IObjectiveNameRepository repository = new ObjectiveNameRepository(this.ServiceClient);
                repository.Culture = new CultureInfo(language);
                return repository;
            }
        }


        public IObjectiveNameRepository Default
        {
            get
            {
                Contract.Ensures(Contract.Result<IObjectiveNameRepository>() != null);
                return new ObjectiveNameRepository(this.ServiceClient);
            }
        }

        public IObjectiveNameRepository ForCurrentCulture
        {
            get
            {
                Contract.Ensures(Contract.Result<IObjectiveNameRepository>() != null);
                return this[CultureInfo.CurrentCulture.TwoLetterISOLanguageName];
            }
        }

        public IObjectiveNameRepository ForCurrentUICulture
        {
            get
            {
                Contract.Ensures(Contract.Result<IObjectiveNameRepository>() != null);
                return this[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName];
            }
        }
    }
}
