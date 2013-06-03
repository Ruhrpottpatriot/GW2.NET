// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tool.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Tool type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Models.Items.SubType
{
    public struct Tool
    {
        public Tool(ToolType type, int charges)
            : this()
        {
            this.Charges = charges;
            this.Type = type;
        }

        public ToolType Type
        {
            get;
            private set;
        }

        public enum ToolType
        {
            Salvage,
            Logging,
            Foraging,
            Mining,
        }

        public int Charges
        {
            get;
            private set;
        }
    }
}
