// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuagganService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the Quaggan service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Quaggans
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Quaggans;
    using GW2DotNET.V2.Common;
    using GW2DotNET.V2.Quaggans.Contracts;

    /// <summary>Provides the default implementation of the Quaggan service.</summary>
    public class QuagganService : IQuagganService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="QuagganService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public QuagganService(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a Quaggan.</summary>
        /// <param name="identifier">An identifier</param>
        /// <returns>A Quaggan</returns>
        public Quaggan GetQuaggan(string identifier)
        {
            var request = new QuagganDetailsRequest { Identifier = identifier };
            var response = this.serviceClient.Send(request, new JsonSerializer<QuagganContract>());
            if (response.Content == null)
            {
                return null;
            }

            return ConvertQuagganContract(response.Content);
        }

        /// <summary>Gets a collection of Quaggan identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        public ICollection<string> GetQuagganIdentifiers()
        {
            var request = new QuagganDiscoveryRequest();
            var response = this.serviceClient.Send(request, new JsonSerializer<ICollection<string>>());
            if (response.Content == null)
            {
                return new List<string>(0);
            }

            return response.Content;
        }

        /// <summary>Gets a collection of Quaggans</summary>
        /// <returns>A collection of Quaggans.</returns>
        public Subdictionary<string, Quaggan> GetQuaggans()
        {
            var request = new QuagganBulkRequest();
            var response = this.serviceClient.Send(request, new JsonSerializer<IEnumerable<QuagganContract>>());
            if (response.Content == null)
            {
                return new Subdictionary<string, Quaggan>(0);
            }

            // Get the number of return values
            var count = int.Parse(response.ExtensionData["X-Result-Count"]);

            // Get the total number of values
            var total = int.Parse(response.ExtensionData["X-Result-Total"]);

            // Convert the return values to entities
            return ConvertQuagganContracts(response.Content, count, total);
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Subdictionary<string, Quaggan> GetQuaggans(IEnumerable<string> identifiers)
        {
            var request = new QuagganBulkRequest { Identifiers = identifiers.ToList() };
            var response = this.serviceClient.Send(request, new JsonSerializer<IEnumerable<QuagganContract>>());
            if (response.Content == null)
            {
                return new Subdictionary<string, Quaggan>(0);
            }

            // Get the number of values in this subset
            var count = int.Parse(response.ExtensionData["X-Result-Count"]);

            // Get the number of values in the entire collection
            var total = int.Parse(response.ExtensionData["X-Result-Total"]);

            // Convert the return values to entities
            return ConvertQuagganContracts(response.Content, count, total);
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <returns>A collection of Quaggans.</returns>
        public PaginatedCollection<Quaggan> GetQuaggans(int page)
        {
            var request = new QuagganPageRequest { Page = page };
            var response = this.serviceClient.Send(request, new JsonSerializer<IEnumerable<QuagganContract>>());
            if (response.Content == null)
            {
                return new PaginatedCollection<Quaggan>(0);
            }

            // Get the number of values in this subset
            var count = int.Parse(response.ExtensionData["X-Result-Count"]);

            // Get the number of values in the entire collection
            var total = int.Parse(response.ExtensionData["X-Result-Total"]);

            // Get the maximum number of values in this subset
            var pageSize = int.Parse(response.ExtensionData["X-Page-Size"]);

            // Get the number of subsets in the entire collection
            var pageTotal = int.Parse(response.ExtensionData["X-Page-Total"]);

            // Convert the return values to entities
            return ConvertQuagganContracts(response.Content, count, total, page, pageSize, pageTotal);
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <returns>A collection of Quaggans.</returns>
        public PaginatedCollection<Quaggan> GetQuaggans(int page, int size)
        {
            var request = new QuagganPageRequest { Page = page, PageSize = size };
            var response = this.serviceClient.Send(request, new JsonSerializer<IEnumerable<QuagganContract>>());
            if (response.Content == null)
            {
                return new PaginatedCollection<Quaggan>(0);
            }

            // Get the number of values in this subset
            var count = int.Parse(response.ExtensionData["X-Result-Count"]);

            // Get the number of values in the entire collection
            var total = int.Parse(response.ExtensionData["X-Result-Total"]);

            // Get the maximum number of values in this subset
            var pageSize = int.Parse(response.ExtensionData["X-Page-Size"]);

            // Get the number of subsets in the entire collection
            var pageTotal = int.Parse(response.ExtensionData["X-Page-Total"]);

            // Convert the return values to entities
            return ConvertQuagganContracts(response.Content, count, total, page, pageSize, pageTotal);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Quaggan ConvertQuagganContract(QuagganContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Quaggan>() != null);

            // Create a new Quaggan object
            var value = new Quaggan();

            // Set the Quaggan identifier
            if (content.Id != null)
            {
                value.Id = content.Id;
            }

            // Set the resource location
            if (content.Url != null)
            {
                value.Url = new Uri(content.Url, UriKind.Absolute);
            }

            // Return the Quaggan object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <param name="subsetCount">The subset count.</param>
        /// <param name="totalCount">The total count.</param>
        /// <returns>A collection of entities.</returns>
        private static Subdictionary<string, Quaggan> ConvertQuagganContracts(IEnumerable<QuagganContract> content, int subsetCount, int totalCount)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<IDictionary<string, Quaggan>>() != null);
            var values = new Subdictionary<string, Quaggan>(subsetCount) { SubsetCount = subsetCount, TotalCount = totalCount };
            foreach (var value in content.Select(ConvertQuagganContract))
            {
                values.Add(value.Id, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <param name="subsetCount">The subset count.</param>
        /// <param name="totalCount">The total count.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="pageTotal">The page total.</param>
        /// <returns>A collection of entities.</returns>
        private static PaginatedCollection<Quaggan> ConvertQuagganContracts(
            IEnumerable<QuagganContract> content, 
            int subsetCount, 
            int totalCount, 
            int page, 
            int pageSize, 
            int pageTotal)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<IDictionary<string, Quaggan>>() != null);
            var values = new PaginatedCollection<Quaggan>(subsetCount)
                             {
                                 SubsetCount = subsetCount, 
                                 TotalCount = totalCount, 
                                 CurrentPage = page, 
                                 PageSize = pageSize, 
                                 PageTotal = pageTotal
                             };
            values.AddRange(content.Select(ConvertQuagganContract));
            return values;
        }
    }
}