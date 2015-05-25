// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForISubsetContext.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForISubsetContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    [ContractClassFor(typeof(ISubsetContext))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForISubsetContext : ISubsetContext
    {
        public int SubtotalCount { get; set; }

        public int TotalCount { get; set; }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.SubtotalCount >= 0);
            Contract.Invariant(this.TotalCount >= 0);
        }
    }
}