// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BagContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a bag.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Contracts
{
    using System.Runtime.Serialization;

    /// <summary>Represents a bag.</summary>
    [DataContract]
    public sealed class BagContract
    {
        /// <summary>Gets or sets a value indicating whether this is an invisible bag.</summary>
        [DataMember(Name = "no_sell_or_sort", Order = 0)]
        public string NoSellOrSort { get; set; }

        /// <summary>Gets or sets the bag's capacity.</summary>
        [DataMember(Name = "size", Order = 1)]
        public string Size { get; set; }
    }
}