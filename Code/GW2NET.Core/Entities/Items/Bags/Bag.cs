// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bag.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a bag.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Entities.Items
{
    /// <summary>Represents a bag.</summary>
    public class Bag : Item
    {
        /// <summary>Gets or sets a value indicating whether this is an invisible bag.</summary>
        public virtual bool NoSellOrSort { get; set; }

        /// <summary>Gets or sets the bag's capacity.</summary>
        public virtual int Size { get; set; }
    }
}