// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollectionPageResponseConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="IResponse{T}" /> to objects of type <see cref="ICollectionPage{T}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Common.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>Converts objects of type <see cref="IResponse{T}"/> to objects of type <see cref="ICollectionPage{T}"/>.</summary>
    /// <typeparam name="TDTO">The type of data contracts in the response content.</typeparam>
    /// <typeparam name="TValue">The type of the converted values.</typeparam>
    public sealed class CollectionPageResponseConverter<TDTO, TValue> : IConverter<IResponse<ICollection<TDTO>>, ICollectionPage<TValue>>
    {
        private readonly IConverter<TDTO, TValue> dataContractConverter;

        /// <summary>Initializes a new instance of the <see cref="CollectionPageResponseConverter{TDTO,TValue}"/> class.</summary>
        /// <param name="dataContractConverter">The converter for <typeparamref name="TDTO"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="dataContractConverter"/> is a null reference.</exception>
        public CollectionPageResponseConverter(IConverter<TDTO, TValue> dataContractConverter)
        {
            if (dataContractConverter == null)
            {
                throw new ArgumentNullException("dataContractConverter");
            }

            this.dataContractConverter = dataContractConverter;
        }

        /// <inheritdoc />
        ICollectionPage<TValue> IConverter<IResponse<ICollection<TDTO>>, ICollectionPage<TValue>>.Convert(IResponse<ICollection<TDTO>> value, object state)
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

            page.AddRange(dataContracts.Select(dataContract => this.dataContractConverter.Convert(dataContract, value)));

            // TODO: replace this code with an implementation of the Link header
            PageContextPatchUtility.Patch(page, pageIndex.Value);

            return page;
        }
    }
}