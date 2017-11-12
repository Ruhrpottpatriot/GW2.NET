// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Scoreboard.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a World versus World scoreboard.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.WorldVersusWorld
{
    /// <summary>Represents a World versus World scoreboard.</summary>
    public class Scoreboard
    {
        /// <summary>Gets or sets the blue team's score.</summary>
        public virtual int Blue { get; set; }

        /// <summary>Gets or sets the green team's score.</summary>
        public virtual int Green { get; set; }

        /// <summary>Gets or sets the red team's score.</summary>
        public virtual int Red { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return string.Format("Red: {0} Blue: {1} Green: {2}", this.Red, this.Blue, this.Green);
        }
    }
}