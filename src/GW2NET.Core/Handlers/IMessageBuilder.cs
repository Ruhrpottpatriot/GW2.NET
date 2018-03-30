// <copyright file="IMessageBuilder.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Handlers
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;

#pragma warning disable SA1615 // Element return value must be documented
    public interface IMessageBuilder
    {
        /// <summary>Builds all internal messages into appropriate <see cref="HttpRequestMessage"/>s.</summary>
        IEnumerable<HttpRequestMessage> Build();

        /// <summary>Prepares the <see cref="ApiQuerySelector"/> for an additional request message.</summary>
        IVersionSelector Also();
    }

    public interface IVersionSelector
    {
        /// <summary>Selects the version 2 api that is anonymusly queryable.</summary>
        IV2EndpointSelector V2();

        /// <summary>Selects the version 2 api that is authorized.</summary>
        /// <param name="apiKey">The authorization api key.</param>
        IV2AuthorizedEndpointSelector V2Authorized(string apiKey);
    }

    public interface IV2AuthorizedEndpointSelector
    {
    }

    public interface IV2EndpointSelector
    {
        /// <summary>Selects the /items endpoint.</summary>
        IRequestTypeSelector Items();

        /// <summary>Selects an arbitrary api endpoint.</summary>
        /// <param name="endpoint">The relative url to the enpoint.</param>
        IAbstractRequestBuilder OnEndpoint(string endpoint);
    }

    public interface IRequestTypeSelector
    {
        /// <summary>Sets the request to discover the endpoint.</summary>
        IMessageBuilder Discover();

        /// <summary>Sets the request to fetch details from the endpoint.</summary>
        IDetailsBuilder GetDetails();
    }

    public interface IDetailsBuilder
    {
        /// <summary>Selects a single item for query.</summary>
        /// <typeparam name="TKey">The type of the id parameter.</typeparam>
        /// <param name="id">The items id.</param>
        ILanguageSelector ForItem<TKey>(TKey id);

        /// <summary>Selects multiple items for query.</summary>
        /// <typeparam name="TKey">The type of the id parameter.</typeparam>
        /// <param name="ids">The items ids.</param>
        ILanguageSelector ForItems<TKey>(IEnumerable<TKey> ids);

        /// <summary>Selects a number of pages to query the api.</summary>
        /// <param name="start">The zero based starting page.</param>
        /// <param name="count">The amount of pages to query.</param>
        IPageSizeSelector ForPages(int start, int count);
    }

    public interface IPageSizeSelector
    {
        /// <summary>Sets the page size, which in conjuncture with page count specifies the overall query size.</summary>
        /// <param name="size">The page size</param>
        ILanguageSelector AtSize(int size);
    }

    public interface ILanguageSelector
    {
        /// <summary>Selects the request language.</summary>
        /// <param name="language">The language as <see cref="CultureInfo"/> object.</param>
        IMessageBuilder In(CultureInfo language);

        /// <summary>Selects the request language.</summary>
        /// <param name="language">The two letter language code.</param>
        IMessageBuilder In(string language);

        /// <summary>Requests content in the default language.</summary>
        IMessageBuilder InDefaltLanguage();
    }

    public interface IAbstractRequestBuilder
    {
        /// <summary>Sets a body parameter for the request.</summary>
        /// <typeparam name="TValue">The value's type.</typeparam>
        /// <param name="key">The parameter key.</param>
        /// <param name="value">The parameter value.</param>
        IAbstractRequestBuilder WithBodyParameter<TValue>(string key, TValue value);

        /// <summary>Sets a query string parameter for the request.</summary>
        /// <typeparam name="TValue">The value's type.</typeparam>
        /// <param name="key">The parameter key.</param>
        /// <param name="value">The parameter value.</param>
        IAbstractRequestBuilder WithQueryStringParameter<TValue>(string key, TValue value);

        /// <summary>Builds all internal messages into appropriate <see cref="HttpRequestMessage"/>s.</summary>
        IEnumerable<HttpRequestMessage> Build();

        /// <summary>Prepares the <see cref="ApiQuerySelector"/> for an additional request message.</summary>
        IVersionSelector Also();
    }
#pragma warning restore SA1615 // Element return value must be documented
}
