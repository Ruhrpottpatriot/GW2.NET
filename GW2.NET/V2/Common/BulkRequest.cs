// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BulkRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a bulk resource details request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Common
{
    using System.Collections.Generic;

    /// <summary>Represents a bulk resource details request.</summary>
    public class BulkRequest : IBulkRequest
    {
        /// <summary>Initializes a new instance of the <see cref="BulkRequest"/> class.</summary>
        public BulkRequest()
        {
            this.Identifiers = new List<int>();
        }

        /// <summary>Gets the collection of resource identifiers.</summary>
        public ICollection<int> Identifiers { get; private set; }

        /// <summary>Gets or sets the resource path.</summary>
        public string Resource { get; set; }
    }
}