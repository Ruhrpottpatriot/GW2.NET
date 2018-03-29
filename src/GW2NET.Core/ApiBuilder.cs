// <copyright file="ApiBuilder.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApiWrapperExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection serviceCollection, Action<HttpClientOptions> configure)
        {
            serviceCollection.AddSingleton(_ =>
            {
                if (configure == null)
                {
                    throw new ArgumentNullException(nameof(configure));
                }

                var options = new HttpClientOptions();
                configure(options);

                return new HttpClientFactory(options);
            });

            serviceCollection.AddSingleton(factory => factory.GetRequiredService<HttpClientFactory>().Build());

            return serviceCollection;
        }

        public static IServiceCollection AddCore(this IServiceCollection serviceCollection)
        {
            var con = new HttpClientOptions();

            return serviceCollection.AddCore(conf => con);
        }
    }

    internal sealed class HttpClientFactory
    {
        public HttpClientFactory(HttpClientOptions options)
        {
            this.Options = options;
        }

        public HttpClientOptions Options { get; }

        public HttpClient Build()
        {
            var client = new HttpClient(this.Options.MessageHandler, false)
            {
                BaseAddress = this.Options.BaseAddress,
                Timeout = this.Options.Timeout
            };

            return client;
        }
    }

    public sealed class HttpClientOptions
    {

        public HttpClientOptions()
        {
            this.MessageHandler = ;
            this.BaseAddress = ;
            this.Timeout = ;
        }

        public HttpMessageHandler MessageHandler { get; set; }

        public Uri BaseAddress { get; set; }

        public TimeSpan Timeout { get; set; }


    }
}
