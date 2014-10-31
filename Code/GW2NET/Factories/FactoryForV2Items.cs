namespace GW2NET.Factories
{
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Runtime.CompilerServices;

    using GW2NET.Common;
    using GW2NET.Entities.Items;
    using GW2NET.V2.Items;

    public class FactoryForV2Items : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FactoryForV2Items(IServiceClient serviceClient)
            : base(serviceClient)
        {
            Contract.Requires(serviceClient != null);
        }

        [IndexerName("Language")]
        public IRepository<int, Item> this[string language]
        {
            get
            {
                Contract.Ensures(Contract.Result<IRepository<int, Item>>() != null);
                return new ItemRepository(this.ServiceClient) { Culture = new CultureInfo(language) };
            }
        }

        public IRepository<int, Item> Default
        {
            get
            {
                Contract.Ensures(Contract.Result<IRepository<int, Item>>() != null);
                return new ItemRepository(this.ServiceClient);
            }
        }

        public IRepository<int, Item> ForCurrentCulture
        {
            get
            {
                Contract.Ensures(Contract.Result<IRepository<int, Item>>() != null);
                return this[CultureInfo.CurrentCulture.TwoLetterISOLanguageName];
            }
        }

        public IRepository<int, Item> ForCurrentUICulture
        {
            get
            {
                Contract.Ensures(Contract.Result<IRepository<int, Item>>() != null);
                return this[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName];
            }
        }
    }
}
