// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DyeUnlocker.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a dye.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.Consumables
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common;

    /// <summary>Represents a dye.</summary>
    [TypeDiscriminator(Value = "Dye", BaseType = typeof(Unlocker))]
    public class DyeUnlocker : Unlocker
    {
        /// <summary>Gets or sets the dye's color ID.</summary>
        [DataMember(Name = "color_id"0000)]
        public virtual int ColorId { get; set; }
    }
}