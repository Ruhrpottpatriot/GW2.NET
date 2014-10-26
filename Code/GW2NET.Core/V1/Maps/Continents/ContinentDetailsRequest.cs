// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentDetailsRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for static information about the continents.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Maps
{
    using System.Collections.Generic;
    using System.Linq;

    using GW2NET.Common;

    /// <summary>Represents a request for static information about the continents.</summary>
    public class ContinentDetailsRequest : IRequest
    {
        /// <summary>Gets the resource path.</summary>
        public string Resource
        {
            get
            {
                return "v1/continents.json";
            }
        }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            yield break;
        }

        /// <summary>Gets additional path segments for the targeted resource.</summary>
        /// <returns>A collection of path segments.</returns>
        public IEnumerable<string> GetPathSegments()
        {
            yield break;
        }
    }
}