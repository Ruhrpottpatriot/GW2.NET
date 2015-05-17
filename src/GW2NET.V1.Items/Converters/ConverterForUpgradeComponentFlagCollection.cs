// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForUpgradeComponentFlagCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="UpgradeComponentFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.Items;

namespace GW2NET.V1.Items.Converters
{
    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="UpgradeComponentFlags"/>.</summary>
    internal sealed class ConverterForUpgradeComponentFlagCollection : IConverter<ICollection<string>, UpgradeComponentFlags>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, UpgradeComponentFlags> converterForUpgradeComponentFlag;

        /// <summary>Initializes a new instance of the <see cref="ConverterForUpgradeComponentFlagCollection"/> class.</summary>
        public ConverterForUpgradeComponentFlagCollection()
            : this(new ConverterForUpgradeComponentFlag())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForUpgradeComponentFlagCollection"/> class.</summary>
        /// <param name="converterForUpgradeComponentFlag">The converter for <see cref="UpgradeComponentFlags"/>.</param>
        public ConverterForUpgradeComponentFlagCollection(IConverter<string, UpgradeComponentFlags> converterForUpgradeComponentFlag)
        {
            Contract.Requires(converterForUpgradeComponentFlag != null);
            this.converterForUpgradeComponentFlag = converterForUpgradeComponentFlag;
        }

        /// <inheritdoc />
        public UpgradeComponentFlags Convert(ICollection<string> value)
        {
            Contract.Assume(value != null);
            var result = default(UpgradeComponentFlags);
            foreach (var s in value)
            {
                result |= this.converterForUpgradeComponentFlag.Convert(s);
            }

            return result;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForUpgradeComponentFlag != null);
        }
    }
}