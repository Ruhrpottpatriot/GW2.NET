// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIRequest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    [ContractClassFor(typeof(IRequest))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIRequest : IRequest
    {
        public string Resource { get; private set; }

        public IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            Contract.Ensures(Contract.Result<IEnumerable<KeyValuePair<string, string>>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets additional path segments for the targeted resource.</summary>
        /// <returns>A collection of path segments.</returns>
        public IEnumerable<string> GetPathSegments()
        {
            Contract.Ensures(Contract.Result<IEnumerable<string>>() != null);
            throw new System.NotImplementedException();
        }
    }
}