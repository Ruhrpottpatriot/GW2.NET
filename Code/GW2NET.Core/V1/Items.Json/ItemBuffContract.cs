// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemBuffContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ItemBuffContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items.Json
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    internal sealed class ItemBuffContract
    {
        [DataMember(Name = "description", Order = 1)]
        internal string Description { get; set; }

        [DataMember(Name = "skill_id", Order = 0)]
        internal string SkillId { get; set; }
    }
}