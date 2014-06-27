// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GatheringTool.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a gathering tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.GatheringTools
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common;
    using GW2DotNET.V1.Common.Converters;
    using GW2DotNET.V1.Items.Details.Contracts.Common;
    using GW2DotNET.V1.Skins.Details.Contracts;

    using Newtonsoft.Json;

    /// <summary>Represents a gathering tool.</summary>
    [TypeDiscriminator(Value = "Gathering", BaseType = typeof(Item))]
    public abstract class GatheringTool : Item, ISkinnable
    {
        /// <summary>Gets or sets the item's default skin.</summary>
        [DataMember(Name = "default_skin")]
        [JsonConverter(typeof(UnknownSkinConverter))]
        public virtual Skin DefaultSkin { get; set; }
    }
}