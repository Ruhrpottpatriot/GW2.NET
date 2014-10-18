// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for commonly requested in-game assets. The returned information can be used with the render service to retrieve assets.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Files
{
    using System.Collections.Generic;
    using System.Linq;

    using GW2NET.Common;

    /// <summary>Represents a request for commonly requested in-game assets. The returned information can be used with the render service to retrieve assets.</summary>
    public class FileRequest : IRequest
    {
        /// <summary>Gets the resource path.</summary>
        public string Resource
        {
            get
            {
                return "v1/files.json";
            }
        }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            yield break;
        }
    }
}