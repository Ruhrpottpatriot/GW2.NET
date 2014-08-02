// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BulkRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for bulk resource details requests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Common
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>Provides the base class for bulk resource details requests.</summary>
    public abstract class BulkRequest : IBulkRequest
    {
        /// <summary>Gets or sets the identifiers.</summary>
        public abstract ICollection<string> Identifiers { get; set; }

        /// <summary>Gets the resource path.</summary>
        public abstract string Resource { get; }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        public virtual IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            // Get the 'ids' parameter
            var identifiers = this.Identifiers;
            if (identifiers != null && identifiers.Any())
            {
                yield return new KeyValuePair<string, string>("ids", string.Join(",", identifiers));
            }
            else
            {
                yield return new KeyValuePair<string, string>("ids", "all");
            }
        }
    }
}