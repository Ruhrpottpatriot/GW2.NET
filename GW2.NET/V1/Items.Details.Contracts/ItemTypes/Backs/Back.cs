// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Back.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a back item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Backs
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    using Newtonsoft.Json;

    /// <summary>Represents a back item.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class Back : CombatItem, ISkinnable
    {
        /// <summary>Initializes a new instance of the <see cref="Back" /> class.</summary>
        public Back()
            : base(ItemType.Back, "back")
        {
        }

        /// <summary>Gets or sets the item's default skin identifier.</summary>
        [DataMember(Name = "default_skin")]
        public virtual int DefaultSkin { get; set; }
    }
}