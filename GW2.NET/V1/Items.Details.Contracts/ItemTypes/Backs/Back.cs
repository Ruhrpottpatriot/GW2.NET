// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Back.cs" company="GW2.Net Coding Team">
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
    public class Back : SkinnedItem
    {
        /// <summary>Initializes a new instance of the <see cref="Back" /> class.</summary>
        public Back()
            : base(ItemType.Back)
        {
        }

        /// <summary>Gets or sets the item details.</summary>
        [DataMember(Name = "back", Order = 1000)]
        public new BackDetails Details
        {
            get
            {
                return base.Details as BackDetails;
            }

            set
            {
                base.Details = value;
            }
        }
    }
}