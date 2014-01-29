// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the WorldData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using GW2DotNET.V1.Events.Models;
using GW2DotNET.V1.Infrastructure;

namespace GW2DotNET.V1.Events.DataProviders
{
    /// <summary>
    /// Contains methods to get and modify the world data.
    /// </summary>
    public class WorldData : IEnumerable<GwWorld>
    {
        /// <summary>
        /// The world names will be retrieved in this language
        /// </summary>
        private readonly IApiManager apiManager;

        /// <summary>
        /// Cache the world_names list here
        /// </summary>
        private Lazy<IEnumerable<GwWorld>> worldCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldData"/> class.
        /// This should only be called by WorldManager.
        /// </summary>
        /// <param name="apiManager">The language in which to return world names</param>
        internal WorldData(IApiManager apiManager)
        {
            this.apiManager = apiManager;

            this.worldCache = new Lazy<IEnumerable<GwWorld>>(this.InitializeWorldCache);
        }

        private IEnumerable<GwWorld> InitializeWorldCache()
        {
            var arguments = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("lang", this.apiManager.ToString())
                };

            return ApiCall.GetContent<List<GwWorld>>("world_names.json", arguments,
                                                     ApiCall.Categories.World);
        }

        /// <summary>
        /// Gets all <see cref="GwWorld"/> from the API.
        /// </summary>
        /// ReSharper disable CSharpWarnings::CS1584
        /// <returns>A <see cref="T:System.Collections.Generic.IEnumerable"/> containing all world objects.
        /// ReSharper restore CSharpWarnings::CS1584
        /// </returns>
        private IEnumerable<GwWorld> Worlds
        {
            get { return this.worldCache.Value; }
        }

        /// <summary>
        /// Gets all worlds asynchronously.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<GwWorld>> GetAllWorldsAsync(CancellationToken cancellationToken)
        {
            Func<IEnumerable<GwWorld>> methodCall = () => this.Worlds;

            return Task.Factory.StartNew(methodCall, cancellationToken);
        }

        /// <summary>
        /// Gets a world by world ID
        /// </summary>
        /// <param name="worldId">The ID of the world</param>
        /// <returns>A single <see cref="GwWorld"/>.</returns>
        public GwWorld this[int worldId]
        {
            get
            {
                return this.Worlds.Single(n => n.Id == worldId);
            }
        }

        /// <summary>
        /// Gets a world by ID asynchronously.
        /// </summary>
        /// <param name="worldId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<GwWorld> GetWorldFromIdAsync(int worldId, CancellationToken cancellationToken)
        {
            Func<GwWorld> methodCall = () => this[worldId];

            return Task.Factory.StartNew(methodCall, cancellationToken);
        }

        /// <summary>
        /// Gets a world by name
        /// </summary>
        /// <param name="name">The name of the world</param>
        /// <returns>A single <see cref="GwWorld"/>.</returns>
        public GwWorld this[string name]
        {
            get
            {
                return this.Worlds.Single(n => n.Name == name);
            }
        }

        /// <summary>
        /// Gets a world by name asynchronously.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<GwWorld> GetWorldFromNameAsync(string name, CancellationToken cancellationToken)
        {
            Func<GwWorld> methodCall = () => this[name];

            return Task.Factory.StartNew(methodCall);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<GwWorld> GetEnumerator()
        {
            return this.Worlds.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Worlds.GetEnumerator();
        }
    }
}
