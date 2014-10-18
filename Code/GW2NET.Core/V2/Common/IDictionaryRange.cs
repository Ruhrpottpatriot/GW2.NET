// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDictionaryRange.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for <see cref="IDictionary{TKey,TValue}" /> types that represent a range.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Common
{
    using System.Collections.Generic;

    /// <summary>Provides the interface for <see cref="IDictionary{TKey,TValue}"/> types that represent a range.</summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    public interface IDictionaryRange<TKey, TValue> : IDictionary<TKey, TValue>, ISubsetContext
    {
    }
}