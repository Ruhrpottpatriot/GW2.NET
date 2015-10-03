// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DetailsRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for resource details requests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Common
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>Provides the base class for resource details requests.</summary>
    public abstract class DetailsRequest : IDetailsRequest
    {
        /// <summary>Gets or sets the resource identifier.</summary>
        public virtual string Identifier { get; set; }

        /// <summary>Gets the resource path.</summary>
        public abstract string Resource { get; }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            var id = this.Identifier;
            foreach (var parameter in this.GetParameters(id))
            {
                Debug.Assert(!string.Equals(parameter.Key, "id", StringComparison.OrdinalIgnoreCase), "parameter.Key != id");
                yield return parameter;
            }

            yield return new KeyValuePair<string, string>("id", id);
        }

        protected virtual IEnumerable<KeyValuePair<string, string>> GetParameters(string id)
        {
            yield break;
        }
    }
}