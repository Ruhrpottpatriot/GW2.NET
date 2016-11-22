// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveV2Repository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v2/wvw/objectives interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.WorldVersusWorld.Objectives
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Globalization;
    using System.Threading;
    using GW2NET.Common;
    using GW2NET.WorldVersusWorld;

    public class ObjectiveRepository : IObjectiveRepository
    {
        public CultureInfo Culture
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<int> Discover()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<int>> DiscoverAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<int>> DiscoverAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Objective Find(int identifier)
        {
            throw new NotImplementedException();
        }

        public IDictionaryRange<int, Objective> FindAll()
        {
            throw new NotImplementedException();
        }

        public IDictionaryRange<int, Objective> FindAll(ICollection<int> identifiers)
        {
            throw new NotImplementedException();
        }

        public Task<IDictionaryRange<int, Objective>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDictionaryRange<int, Objective>> FindAllAsync(ICollection<int> identifiers)
        {
            throw new NotImplementedException();
        }

        public Task<IDictionaryRange<int, Objective>> FindAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IDictionaryRange<int, Objective>> FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Objective> FindAsync(int identifier)
        {
            throw new NotImplementedException();
        }

        public Task<Objective> FindAsync(int identifier, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ICollectionPage<Objective> FindPage(int pageIndex)
        {
            throw new NotImplementedException();
        }

        public ICollectionPage<Objective> FindPage(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ICollectionPage<Objective>> FindPageAsync(int pageIndex)
        {
            throw new NotImplementedException();
        }

        public Task<ICollectionPage<Objective>> FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ICollectionPage<Objective>> FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ICollectionPage<Objective>> FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
