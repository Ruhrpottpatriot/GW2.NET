using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2NET.Factories
{
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
        }

        [IndexerName("Language")]
        public IRepository<int, ObjectiveName> this[string language]
        {
            get
            {
                return new ObjectiveRepository(this.ServiceClient) { Culture = new CultureInfo(language) };
            }
        }


        public IRepository<int, ObjectiveName> Default
        {
            get
            {
                return new ObjectiveRepository(this.ServiceClient);
            }
        }

        public IRepository<int, ObjectiveName> ForCurrentCulture
        {
            get
            {
                return this[CultureInfo.CurrentCulture.TwoLetterISOLanguageName];
            }
        }

        public IRepository<int, ObjectiveName> ForCurrentUICulture
        {
            get
            {
                return this[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName];
            }
        }
    }
}
