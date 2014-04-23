// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveNameService.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the objective names service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Objectives.Names
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.WorldVersusWorld.Objectives.Names.Contracts;

    /// <summary>Provides the default implementation of the objective names service.</summary>
    public class ObjectiveNameService : ServiceBase, IObjectiveNameService
    {
        /// <summary>Initializes a new instance of the <see cref="ObjectiveNameService"/> class.</summary>
        public ObjectiveNameService()
            : this(new ServiceClient(new Uri(Services.DataServiceUrl)))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ObjectiveNameService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ObjectiveNameService(IServiceClient serviceClient)
            : base(serviceClient)
        {
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public IEnumerable<ObjectiveName> GetObjectiveNames()
        {
            return this.GetObjectiveNames(ServiceBase.DefaultLanguage);
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public IEnumerable<ObjectiveName> GetObjectiveNames(CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var serviceRequest = new ObjectiveNameServiceRequest { Language = language };
            var result = this.Request<ObjectiveNameCollection>(serviceRequest);

            foreach (var objectiveName in result)
            {
                // patch missing language information
                objectiveName.Language = language;
            }

            return result;
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ObjectiveName>> GetObjectiveNamesAsync()
        {
            return this.GetObjectiveNamesAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ObjectiveName>> GetObjectiveNamesAsync(CancellationToken cancellationToken)
        {
            return this.GetObjectiveNamesAsync(ServiceBase.DefaultLanguage, cancellationToken);
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ObjectiveName>> GetObjectiveNamesAsync(CultureInfo language)
        {
            return this.GetObjectiveNamesAsync(language, CancellationToken.None);
        }

        /// <summary>Gets a collection of World versus World objectives and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of World versus World objectives and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/wvw/objective_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ObjectiveName>> GetObjectiveNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var serviceRequest = new ObjectiveNameServiceRequest { Language = language };
            var t1 = this.RequestAsync<ObjectiveNameCollection>(serviceRequest, cancellationToken).ContinueWith(
                task =>
                    {
                        foreach (var objectiveName in task.Result)
                        {
                            // patch missing language information
                            objectiveName.Language = language;
                        }

                        return task.Result;
                    }, 
                cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<ObjectiveName>>(task => task.Result, cancellationToken);

            return t2;
        }
    }
}