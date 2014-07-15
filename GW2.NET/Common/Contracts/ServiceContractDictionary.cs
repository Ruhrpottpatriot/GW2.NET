// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceContractDictionary.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for dictionaries of service contracts.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Common.Contracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>Provides the base class for dictionaries of service contracts.</summary>
    /// <typeparam name="TKey">The type of the keys.</typeparam>
    /// <typeparam name="TValue">The type of the values.</typeparam>
    [CollectionDataContract]
    public abstract class ServiceContractDictionary<TKey, TValue> : Dictionary<TKey, TValue>
        where TValue : ServiceContract
    {
        /// <summary>Initializes a new instance of the <see cref="ServiceContractDictionary{TKey,TValue}" /> class.</summary>
        protected ServiceContractDictionary()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceContractDictionary{TKey,TValue}"/> class.</summary>
        /// <param name="capacity">The initial number of elements that the new dictionary can contain.</param>
        protected ServiceContractDictionary(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ServiceContractDictionary{TKey,TValue}"/> class.</summary>
        /// <param name="dictionary">The dictionary whose values are copied to the new dictionary.</param>
        protected ServiceContractDictionary(IDictionary<TKey, TValue> dictionary)
            : base(dictionary)
        {
        }
    }
}