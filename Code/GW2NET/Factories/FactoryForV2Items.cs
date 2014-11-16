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
        public IItemRepository this[string language]
        {
            get
            {
                Contract.Ensures(Contract.Result<IItemRepository>() != null);
                IItemRepository repository = new ItemRepository(this.ServiceClient);
                repository.Culture = new CultureInfo(language);
                return repository;
            }
        }

        public IItemRepository Default
        {
            get
            {
                Contract.Ensures(Contract.Result<IItemRepository>() != null);
                return new ItemRepository(this.ServiceClient);
            }
        }

        public IItemRepository ForCurrentCulture
        {
            get
            {
                Contract.Ensures(Contract.Result<IItemRepository>() != null);
                return this[CultureInfo.CurrentCulture.TwoLetterISOLanguageName];
            }
        }

        public IItemRepository ForCurrentUICulture
        {
            get
            {
                Contract.Ensures(Contract.Result<IItemRepository>() != null);
                return this[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName];
            }
        }
    }
}
