// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnknownSkin.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an unknown skin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Skins
{
    using System.Globalization;

    /// <summary>Represents an unknown skin.</summary>
    public class UnknownSkin : Skin
    {
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var name = this.Name;
            if (!string.IsNullOrEmpty(name))
            {
                return name;
            }

            return this.SkinId.ToString(NumberFormatInfo.InvariantInfo);
        }
    }
}