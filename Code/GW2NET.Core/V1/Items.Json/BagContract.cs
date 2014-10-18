// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BagContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the BagContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items.Json
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    internal sealed class BagContract
    {
        [DataMember(Name = "no_sell_or_sort", Order = 0)]
        internal string NoSellOrSort { get; set; }

        [DataMember(Name = "size", Order = 1)]
        internal string Size { get; set; }
    }
}