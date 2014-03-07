// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Assets.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Core.FilesInformation.Catalogs
{
    /// <summary>
    /// Represents a collection of named assets.
    /// </summary>
    public class Assets : JsonDictionary<string, Asset>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Assets"/> class.
        /// </summary>
        public Assets()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Assets"/> class.
        /// </summary>
        /// <param name="capacity">The initial number of elements that the new dictionary can contain.</param>
        public Assets(int capacity)
            : base(capacity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Assets"/> class.
        /// </summary>
        /// <param name="dictionary">The dictionary whose values are copied to the new dictionary.</param>
        public Assets(IDictionary<string, Asset> dictionary)
            : base(dictionary)
        {
        }
    }
}