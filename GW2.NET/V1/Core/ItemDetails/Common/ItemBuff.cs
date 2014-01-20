// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemBuff.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Common
{
    /// <summary>
    /// Represents an item buff.
    /// </summary>
    public class ItemBuff
    {
        /// <summary>
        /// Gets or sets the buff's skill ID.
        /// </summary>
        [JsonProperty("skill_id", Order = 0)]
        public string SkillId { get; set; }

        /// <summary>
        /// Gets or sets the buff's description.
        /// </summary>
        [JsonProperty("description", Order = 1)]
        public string Description { get; set; }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <param name="indent">A value that indicates whether to indent the output.</param>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public string ToString(bool indent)
        {
            return JsonConvert.SerializeObject(this, indent ? Formatting.Indented : Formatting.None);
        }
    }
}
