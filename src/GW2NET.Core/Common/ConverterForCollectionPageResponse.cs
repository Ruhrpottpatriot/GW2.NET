// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForCollectionPageResponse.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="IResponse{T}" /> to objects of type <see cref="ICollectionPage{T}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>Converts objects of type <see cref="IResponse{T}"/> to objects of type <see cref="ICollectionPage{T}"/>.</summary>
    /// <typeparam name="TDataContract">The type of data contracts in the response content.</typeparam>
    /// <typeparam name="TValue">The type of the converted values.</typeparam>
    public sealed class ConverterForCollectionPageResponse<TDataContract, TValue> : IConverter<IResponse<ICollection<TDataContract>>, ICollectionPage<TValue>>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<TDataContract, TValue> converterForDataContract;

        /// <summary>Initializes a new instance of the <see cref="ConverterForCollectionPageResponse{TDataContract,TValue}"/> class.</summary>
        /// <param name="converterForDataContract">The converter for <typeparamref name="TDataContract"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForDataContract"/> is a null reference.</exception>
        public ConverterForCollectionPageResponse(IConverter<TDataContract, TValue> converterForDataContract)
        {
            if (converterForDataContract == null)
            {
                throw new ArgumentNullException("converterForDataContract", "Precondition: converterForDataContract != null");
            }

            this.converterForDataContract = converterForDataContract;
        }

        /// <inheritdoc />
        ICollectionPage<TValue> IConverter<IResponse<ICollection<TDataContract>>, ICollectionPage<TValue>>.Convert(IResponse<ICollection<TDataContract>> value, object state)
        {
            if (value == null)
            {
                return new CollectionPage<TValue>(0);
            }

            // MEMO: expect the page index as state argument, because we can't parse Link headers yet
            var pageIndex = state as int?;
            if (!pageIndex.HasValue)
            {
                throw new ArgumentException("Precondition: state is int", "state");
            }

            var dataContracts = value.Content;
            if (dataContracts == null)
            {
                return new CollectionPage<TValue>(0);
            }

            var page = new CollectionPage<TValue>(dataContracts.Count)
            {
                PageSize = value.GetPageSize(),
                PageCount = value.GetPageTotal(),
                SubtotalCount = value.GetResultCount(),
                TotalCount = value.GetResultTotal()
            };

            page.AddRange(dataContracts.Select(dataContract => this.converterForDataContract.Convert(dataContract, value)));

            // TODO: replace this code with an implementation of the Link header
            PageContextPatchUtility.Patch(page, pageIndex.Value);

            // TODO: Refactor data contract converters so that this code can be deleted
            foreach (var localizableItem in page.OfType<ILocalizable>())
            {
                localizableItem.Culture = value.Culture;
            }

            // TODO: Refactor data contract converters so that this code can be deleted
            foreach (var timeSensitiveItem in page.OfType<ITimeSensitive>())
            {
                timeSensitiveItem.Timestamp = value.Date;
            }

            return page;
        }
    }
}