// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Back.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a back piece.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Types.ItemTypes.Backs
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents a back item.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class Back : Item
    {
        /// <summary>Infrastructure. Stores the item details.</summary>
        private BackDetails details;

        /// <summary>Initializes a new instance of the <see cref="Back" /> class.</summary>
        public Back()
            : base(ItemType.Back)
        {
        }

        /// <summary>Gets or sets the item's default skin identifier.</summary>
        [DataMember(Name = "default_skin", Order = 100)]
        public int DefaultSkin { get; set; }

        /// <summary>Gets or sets the item details.</summary>
        [DataMember(Name = "back", Order = 101)]
        public BackDetails Details
        {
            get
            {
                return this.details;
            }

            set
            {
                this.details = value;
                value.Back = this;
            }
        }
    }
}