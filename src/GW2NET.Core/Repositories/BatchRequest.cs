// <copyright file="BatchRequest.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>Represents a batch request against the API.</summary>
    public class BatchRequest : Request
    {
        /// <summary>Gets or sets the ids to request.</summary>
        public IList<string> Ids
        {
            get => this.Parameters.Where(p => p.Key.Equals("ids", StringComparison.OrdinalIgnoreCase)).Select(p => p.Value).ToList();

            set
            {
                this.Parameters.RemoveAll(p => value.Any(v =>
                    p.Key.Equals("ids", StringComparison.OrdinalIgnoreCase) &&
                    p.Value.Equals(v, StringComparison.OrdinalIgnoreCase)));

                this.Parameters.AddRange(value.Select(v => new RequestParameter("ids", v, ParameterLocation.Url)));
            }
        }
    }
}