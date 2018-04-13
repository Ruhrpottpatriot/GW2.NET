// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeFlags.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates known recipe flags.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Recipes
{
    using System;

    /// <summary>Enumerates known recipe flags.</summary>
    [Flags]
    public enum RecipeFlags
    {
        /// <summary>Indicates no recipe flags.</summary>
        None = 0,

        /// <summary>The 'Auto Learned' recipe flag.</summary>
        AutoLearned = 1 << 0,

        /// <summary>The 'Learned From Item' recipe flag.</summary>
        LearnedFromItem = 1 << 1
    }
}