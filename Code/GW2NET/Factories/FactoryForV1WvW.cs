namespace GW2NET.Factories
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.V1.WorldVersusWorld;

    public class FactoryForV1WvW : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FactoryForV1WvW(IServiceClient serviceClient)
            : base(serviceClient)
        {
            Contract.Requires(serviceClient != null);
        }

        public IMatchService Matches
        {
            get
            {
                return new MatchService(this.ServiceClient);
            }
        }

        public FactoryForV1WvWObjectives Objectives
        {
            get
            {
                return new FactoryForV1WvWObjectives(this.ServiceClient);
            }
        }
    }
}
