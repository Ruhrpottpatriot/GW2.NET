// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GatheringTool.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a gathering tool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.GatheringTools
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    /// <summary>Represents a gathering tool.</summary>
    [TypeDiscriminator(Value = "Gathering", BaseType = typeof(Item))]
    public abstract class GatheringTool : Item, ISkinnable
    {
        /// <summary>Gets or sets the item's default skin identifier.</summary>
        [DataMember(Name = "default_skin")]
        public int DefaultSkin { get; set; }
    }
}