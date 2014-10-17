// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DetailsRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for resource details requests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Common
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>Provides the base class for resource details requests.</summary>
    public abstract class DetailsRequest : IDetailsRequest
    {
        /// <summary>Gets or sets the resource identifier.</summary>
        public virtual string Identifier { get; set; }

        /// <summary>Gets the resource path.</summary>
        public abstract string Resource { get; }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        public virtual IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            return Enumerable.Empty<KeyValuePair<string, string>>();
        }
    }
}