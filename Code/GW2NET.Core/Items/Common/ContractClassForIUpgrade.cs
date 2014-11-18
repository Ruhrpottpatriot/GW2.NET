// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIUpgrade.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIUpgrade type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Items
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    [ContractClassFor(typeof(IUpgrade))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIUpgrade : IUpgrade
    {
        public InfixUpgrade InfixUpgrade
        {
            get
            {
                Contract.Ensures(Contract.Result<InfixUpgrade>() != null);
                throw new System.NotImplementedException();
            }

            set
            {
                Contract.Requires(value != null);
                throw new System.NotImplementedException();
            }
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.InfixUpgrade != null);
        }
    }
}