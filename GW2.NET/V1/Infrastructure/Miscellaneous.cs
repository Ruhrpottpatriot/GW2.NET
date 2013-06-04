// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Miscellaneous.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Miscellaneous type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace GW2DotNET.V1.Infrastructure
{
    /// <summary>
    /// Contains miscellaneous properties to help the user.
    /// </summary>
    public static class Miscellaneous
    {
        /// <summary>
        /// The build number of the game.
        /// </summary>
        private static int build;

        /// <summary>
        /// Gets the build number of the game.
        /// </summary>
        public static int Build
        {
            get
            {
                if (build == 0)
                {
                    build = ApiCall.GetContent<Dictionary<string, int>>("build.json", null, ApiCall.Categories.Miscellaneous).Values.Single();
                }

                return build;
            }
        }
    }
}
