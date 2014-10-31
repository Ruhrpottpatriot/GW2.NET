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
    using GW2NET.Entities.Items;
    using GW2NET.Entities.WorldVersusWorld;
    using GW2NET.V1.WorldVersusWorld.Objectives;
    using GW2NET.V2.Items;

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
        public IRepository<int, ObjectiveName> this[string language]
        {
            get
            {
                Contract.Ensures(Contract.Result<IRepository<int, ObjectiveName>>() != null);
                return new ObjectiveNameRepository(this.ServiceClient) { Culture = new CultureInfo(language) };
            }
        }


        public IRepository<int, ObjectiveName> Default
        {
            get
            {
                Contract.Ensures(Contract.Result<IRepository<int, ObjectiveName>>() != null);
                return new ObjectiveNameRepository(this.ServiceClient);
            }
        }

        public IRepository<int, ObjectiveName> ForCurrentCulture
        {
            get
            {
                Contract.Ensures(Contract.Result<IRepository<int, ObjectiveName>>() != null);
                return this[CultureInfo.CurrentCulture.TwoLetterISOLanguageName];
            }
        }

        public IRepository<int, ObjectiveName> ForCurrentUICulture
        {
            get
            {
                Contract.Ensures(Contract.Result<IRepository<int, ObjectiveName>>() != null);
                return this[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName];
            }
        }
    }
}
