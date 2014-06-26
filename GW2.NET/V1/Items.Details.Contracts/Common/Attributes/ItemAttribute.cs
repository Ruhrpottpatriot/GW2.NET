// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemAttribute.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for item attributes.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.Common.Attributes
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;

    /// <summary>Provides the base class for item attributes.</summary>
    public abstract class ItemAttribute : JsonObject
    {
        /// <summary>Gets or sets the attribute's modifier.</summary>
        [DataMember(Name = "modifier")]
        public virtual int Modifier { get; set; }
    }
}