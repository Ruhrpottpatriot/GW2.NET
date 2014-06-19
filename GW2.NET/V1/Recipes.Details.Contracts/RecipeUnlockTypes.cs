// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeUnlockTypes.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates all possible ways to unlock a recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes.Details.Contracts
{
    using System;
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Enumerates all possible ways to unlock a recipe.</summary>
    [Flags]
    [JsonConverter(typeof(StringEnumFlagsConverter))]
    public enum RecipeUnlockTypes
    {
        /// <summary>The 'Auto Learned' recipes.</summary>
        [EnumMember(Value = "AutoLearned")]
        AutoLearned = 1 << 0, 

        /// <summary>The 'Learned From Item' recipes.</summary>
        [EnumMember(Value = "LearnedFromItem")]
        LearnedFromItem = 1 << 1
    }
}