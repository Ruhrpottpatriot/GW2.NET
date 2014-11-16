namespace GW2NET.Factories
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Rendering;

    public class FactoryForRendering : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryForRendering"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FactoryForRendering(IServiceClient serviceClient)
            : base(serviceClient)
        {
            Contract.Requires(serviceClient != null);
        }

        public IRenderService RenderService
        {
            get
            {
                Contract.Ensures(Contract.Result<IRenderService>() != null);
                return new RenderService(this.ServiceClient);
            }
        }
    }
}
