// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIResponse.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIResponse type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;

    [ContractClassFor(typeof(IResponse<>))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIResponse<T> : IResponse<T>
    {
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(ExtensionData != null);
        }

        public T Content { get; set; }

        public CultureInfo Culture { get; set; }

        public DateTimeOffset Date { get; set; }

        public IDictionary<string, string> ExtensionData
        {
            get
            {
                Contract.Ensures(Contract.Result<IDictionary<string, string>>() != null);
                throw new NotImplementedException();
            }
            set
            {
                Contract.Requires(value != null);
                throw new NotImplementedException();
            }
        }
    }
}