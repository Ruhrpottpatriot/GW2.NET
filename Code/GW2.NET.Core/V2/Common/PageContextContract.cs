// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PageContextContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the PageContextContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Common
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    internal abstract class PageContextContract : IPageContext
    {
        public int FirstPageIndex { get; set; }

        public int LastPageIndex { get; set; }

        public int? NextPageIndex { get; set; }

        public int PageCount { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int? PreviousPageIndex { get; set; }

        public abstract int SubtotalCount { get; set; }

        public abstract int TotalCount { get; set; }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.PageSize >= 0);
            Contract.Invariant(this.PageCount >= 0);
            Contract.Invariant(this.PageIndex >= 0);
            Contract.Invariant(this.FirstPageIndex == 0);
            Contract.Invariant(this.LastPageIndex >= 0);
            Contract.Invariant(this.PreviousPageIndex == null || this.PreviousPageIndex == this.PageIndex - 1);
            Contract.Invariant(this.NextPageIndex == null || this.NextPageIndex == this.PageIndex + 1);
        }
    }
}