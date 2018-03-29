// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeightClass.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates the known armor weight classes.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Items.Armors
{
    /// <summary>Enumerates the known armor weight classes.</summary>
    public enum WeightClass
    {
        /// <summary>The 'Unknown' weight class.</summary>
        Unknown = 0,

        /// <summary>The 'Clothing' weight class.</summary>
        Clothing = 1 << 0,

        /// <summary>The 'Light' weight class.</summary>
        Light = 1 << 1,

        /// <summary>The 'Medium' weight class.</summary>
        Medium = 1 << 2,

        /// <summary>The 'Heavy' weight class.</summary>
        Heavy = 1 << 3
    }
}