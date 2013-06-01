using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2DotNET.V1.WvW.Models
{
    /// <summary>
    /// Represents a world vs world match.
    /// </summary>
    public partial struct WvWMatch
    {
        /// <summary>
        /// Represents a world vs world map.
        /// </summary>
        public partial struct WvWMap
        {
            /// <summary>
            /// Enumerates the objective type.
            /// </summary>
            public enum Type
            {
                /// <summary>
                /// The red home.
                /// </summary>
                RedHome,

                /// <summary>
                /// The blue home.
                /// </summary>
                BlueHome,

                /// <summary>
                /// The green home.
                /// </summary>
                GreenHome,

                /// <summary>
                /// The center.
                /// </summary>
                Center
            }

        }
    }
}