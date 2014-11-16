namespace GW2NET.Factories
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.V1.WorldVersusWorld.Matches;
    using GW2NET.V1.WorldVersusWorld.Objectives;
    using GW2NET.WorldVersusWorld;

    public class FactoryForV1WvW : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FactoryForV1WvW(IServiceClient serviceClient)
            : base(serviceClient)
        {
            Contract.Requires(serviceClient != null);
        }

        public IMatchRepository Matches
        {
            get
            {
                Contract.Ensures(Contract.Result<IMatchRepository>() != null);
                return new MatchRepository(this.ServiceClient);
            }
        }

        public ObjectiveNameRepositoryFactory Objectives
        {
            get
            {
                Contract.Ensures(Contract.Result<ObjectiveNameRepositoryFactory>() != null);
                return new ObjectiveNameRepositoryFactory(this.ServiceClient);
            }
        }
    }
}
