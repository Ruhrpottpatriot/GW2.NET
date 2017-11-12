﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArmorSkinDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ArmorSkinDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GW2NET.V1.Skins.Json
{
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/skin_details")]
    internal sealed class ArmorSkinDataContract
    {
        [DataMember(Name = "type", Order = 0)]
        internal string Type { get; set; }

        [DataMember(Name = "weight_class", Order = 1)]
        internal string WeightClass { get; set; }
    }
}