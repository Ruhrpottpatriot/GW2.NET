﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultUpgradeComponent.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a default upgrade component.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.UpgradeComponents
{
    using GW2DotNET.Common;

    /// <summary>Represents a default upgrade component.</summary>
    [TypeDiscriminator(Value = "Default", BaseType = typeof(UpgradeComponent))]
    public class DefaultUpgradeComponent : UpgradeComponent
    {
    }
}