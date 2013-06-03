using System.Collections.Generic;

namespace GW2DotNET.V1.Items.Models.Items
{
    public struct InfusionSlot
    {
        public string Item { get; private set; }

        public IEnumerable<UpgradeFlag> Flags { get; private set; }
    }
}