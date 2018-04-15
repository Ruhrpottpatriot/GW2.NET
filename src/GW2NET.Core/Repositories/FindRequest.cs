// <copyright file="FindRequest.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Repositories
{
    using System;
    using System.Linq;

    /// <summary>Represent single item request.</summary>
    public class FindRequest : Request
    {
        /// <summary>Gets or sets the item id to request.</summary>
        public string Id
        {
            get => this.Parameters.SingleOrDefault(p => p.Key.Equals("ids", StringComparison.OrdinalIgnoreCase)).Value;

            set
            {
                this.Parameters.RemoveAll(p => p.Key.Equals("ids", StringComparison.OrdinalIgnoreCase));
                this.Parameters.Add(new RequestParameter("ids", value, ParameterLocation.Url));
            }
        }
    }
}