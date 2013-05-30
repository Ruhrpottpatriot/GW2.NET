// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WvWManager.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the WvWManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.WvW.DataProviders;

namespace GW2DotNET.V1.WvW
{
    public class WvWManager
    {
        private MatchData matchData;

        public MatchData Matches
        {
            get
            {
                return this.matchData ?? (this.matchData = new MatchData());
            }
        }
    }
}
