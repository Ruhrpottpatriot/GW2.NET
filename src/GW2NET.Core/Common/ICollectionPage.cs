// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICollectionPage.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for collections that represent a page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System.Collections.Generic;

    /// <summary>Provides the interface for collections that represent a page.</summary>
    /// <typeparam name="T">The type of values in the collection.</typeparam>
    public interface ICollectionPage<T> : ICollection<T>, IPageContext
    {
    }
}