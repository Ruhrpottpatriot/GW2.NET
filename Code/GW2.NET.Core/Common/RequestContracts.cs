// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequestContracts.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The request contracts.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    /// <summary>The request contracts.</summary>
    [ContractClassFor(typeof(IRequest))]
    internal abstract class RequestContracts : IRequest
    {
        /// <summary>Gets the resource path.</summary>
        public string Resource { get; private set; }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            Contract.Ensures(Contract.Result<IEnumerable<KeyValuePair<string, string>>>() != null);
            throw new System.NotImplementedException();
        }
    }
}