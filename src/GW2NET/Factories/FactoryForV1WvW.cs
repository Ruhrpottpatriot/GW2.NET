// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FactoryForV1WvW.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to WvW data sources.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Factories
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.WorldVersusWorld;
    using GW2NET.V1.WorldVersusWorld.Matches;
    using GW2NET.V1.WorldVersusWorld.Objectives;
    /// <summary>Provides access to WvW data sources.</summary>
    public class FactoryForV1WvW : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryForV1WvW"/> class. Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FactoryForV1WvW(IServiceClient serviceClient)
            : base(serviceClient)
        {
            Contract.Requires(serviceClient != null);
        }

        /// <summary>Provides access to the matches data source.</summary>
        public IMatchRepository Matches
        {
            get
            {
                Contract.Ensures(Contract.Result<IMatchRepository>() != null);
                return new MatchRepository(this.ServiceClient);
            }
        }

        /// <summary>Provides access to the objective names data source.</summary>
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