// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceContractList.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for lists of service contracts.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Common.Contracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>Provides the base class for lists of service contracts.</summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    [CollectionDataContract]
    public abstract class ServiceContractList<T> : List<T>
        where T : ServiceContract
    {
        /// <summary>Initializes a new instance of the <see cref="ServiceContractList{T}" /> class.</summary>
        protected ServiceContractList()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceContractList{T}"/> class.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        protected ServiceContractList(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceContractList{T}"/> class.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        protected ServiceContractList(IEnumerable<T> collection)
            : base(collection)
        {
        }
    }
}