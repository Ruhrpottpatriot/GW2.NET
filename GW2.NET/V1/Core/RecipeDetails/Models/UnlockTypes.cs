// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnlockTypes.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.RecipeDetails.Models
{
    /// <summary>
    /// Enumerates all possible ways to unlock a recipe.
    /// </summary>
    [Flags]
    [JsonConverter(typeof(StringEnumFlagsConverter))]
    public enum UnlockTypes
    {
        /// <summary>The 'Auto Learned' recipes.</summary>
        [EnumMember(Value = "AutoLearned")]
        AutoLearned = 1 << 0,

        /// <summary>The 'Learned From Item' recipes.</summary>
        [EnumMember(Value = "LearnedFromItem")]
        LearnedFromItem = 1 << 1
    }
}