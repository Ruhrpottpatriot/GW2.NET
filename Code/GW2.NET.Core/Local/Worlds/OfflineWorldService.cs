// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OfflineWorldService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides an offline implementation of the world service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Local.Worlds
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Entities.Worlds;
    using GW2DotNET.V1.Worlds;

    /// <summary>Provides an offline implementation of the world service.</summary>
    public class OfflineWorldService : IWorldNameService
    {
        /// <summary>Infrastructure. Holds a reference to a service.</summary>
        private readonly IWorldNameService worldNameService;

        /// <summary>Initializes a new instance of the <see cref="OfflineWorldService"/> class.</summary>
        /// <param name="serializerFactory">The serializer factory.</param>
        public OfflineWorldService(ISerializerFactory serializerFactory)
        {
            Contract.Requires(serializerFactory != null);
            this.worldNameService = new WorldService(new OfflineWorldServiceClient(serializerFactory));
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public IDictionary<int, World> GetWorldNames()
        {
            return this.worldNameService.GetWorldNames(new CultureInfo("en"));
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public IDictionary<int, World> GetWorldNames(CultureInfo language)
        {
            return this.worldNameService.GetWorldNames(language);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, World>> GetWorldNamesAsync()
        {
            return this.worldNameService.GetWorldNamesAsync(new CultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, World>> GetWorldNamesAsync(CancellationToken cancellationToken)
        {
            return this.worldNameService.GetWorldNamesAsync(new CultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, World>> GetWorldNamesAsync(CultureInfo language)
        {
            return this.worldNameService.GetWorldNamesAsync(language, CancellationToken.None);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, World>> GetWorldNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            return this.worldNameService.GetWorldNamesAsync(language, cancellationToken);
        }

        /// <summary>The offline world service client.</summary>
        private class OfflineWorldServiceClient : IServiceClient
        {
            /// <summary>Infrastructure. Holds a reference to a serializer factory.</summary>
            private readonly ISerializerFactory serializerFactory;

            /// <summary>Initializes a new instance of the <see cref="OfflineWorldServiceClient"/> class.</summary>
            /// <param name="serializerFactory">The serializer factory.</param>
            public OfflineWorldServiceClient(ISerializerFactory serializerFactory)
            {
                Contract.Requires(serializerFactory != null);
                this.serializerFactory = serializerFactory;
            }

            /// <summary>Sends a request and returns the response.</summary>
            /// <param name="request">The service request.</param>
            /// <typeparam name="TResult">The type of the response content.</typeparam>
            /// <returns>An instance of the specified type.</returns>
            public IResponse<TResult> Send<TResult>(IRequest request)
            {
                var culture = new CultureInfo(request.GetParameters().FirstOrDefault(kvp => kvp.Key == "lang").Value ?? "en");

                // Create a new response object
                var response = new Response<TResult>();

                // Set the date
                response.Date = DateTimeOffset.UtcNow;

                // Set the culture
                response.Culture = culture;

                // Load the content file from this assembly
                var type = this.GetType();
                using (var stream = type.Assembly.GetManifestResourceStream(type.Namespace + string.Format(".{0}.json", culture.TwoLetterISOLanguageName)))
                {
                    // Ensure that there is content
                    if (stream == null)
                    {
                        throw new ServiceException("language not supported");
                    }

                    // Create a new serializer
                    var serializer = this.serializerFactory.GetSerializer<TResult>();

                    // Deserialize the content
                    response.Content = serializer.Deserialize(stream);
                }

                // Return the response object
                return response;
            }

            /// <summary>Sends a request and returns the response.</summary>
            /// <param name="request">The service request.</param>
            /// <typeparam name="TResult">The type of the response content.</typeparam>
            /// <returns>An instance of the specified type.</returns>
            public Task<IResponse<TResult>> SendAsync<TResult>(IRequest request)
            {
                var tcs = new TaskCompletionSource<IResponse<TResult>>();
                tcs.SetResult(this.Send<TResult>(request));
                return tcs.Task;
            }

            /// <summary>Sends a request and returns the response.</summary>
            /// <param name="request">The service request.</param>
            /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
            /// <typeparam name="TResult">The type of the response content.</typeparam>
            /// <returns>An instance of the specified type.</returns>
            public Task<IResponse<TResult>> SendAsync<TResult>(IRequest request, CancellationToken cancellationToken)
            {
                var tcs = new TaskCompletionSource<IResponse<TResult>>();
                tcs.SetResult(this.Send<TResult>(request));
                return tcs.Task;
            }
        }
    }
}