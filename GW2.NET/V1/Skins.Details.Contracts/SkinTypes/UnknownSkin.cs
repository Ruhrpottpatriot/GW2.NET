// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnknownSkin.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an unknown skin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins.Details.Contracts.SkinTypes
{
    /// <summary>Represents an unknown skin.</summary>
    public class UnknownSkin : Skin
    {
        /// <summary>Initializes a new instance of the <see cref="UnknownSkin" /> class.</summary>
        public UnknownSkin()
            : base(SkinType.Unknown)
        {
        }
    }
}