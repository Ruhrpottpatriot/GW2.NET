// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GwColour.RgbColour.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a colour in the game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Items.Models
{
    /// <summary>Represents a colour in the game.</summary>
    public partial class GwColour
    {
        /// <summary>The rgb colour.</summary>
        public class RgbColour
        {
            /// <summary>Initializes a new instance of the <see cref="RgbColour"/> class.</summary>
            /// <param name="colourValues">The colour values.</param>
            public RgbColour(IList<int> colourValues)
            {
                if (colourValues != null)
                {
                    this.Red = colourValues[0];
                    this.Green = colourValues[1];
                    this.Blue = colourValues[2];
                }
                else
                {
                    this.Red = 0;
                    this.Green = 0;
                    this.Blue = 0;
                }
            }

            /// <summary>Gets the red colour.</summary>
            public int Red { get; private set; }

            /// <summary>Gets the green colour.</summary>
            public int Green { get; private set; }

            /// <summary>Gets the blue colour.</summary>
            public int Blue { get; private set; }
        }
    }
}