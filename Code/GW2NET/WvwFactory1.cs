using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2NET
{
    using GW2NET.V1.WorldVersusWorld;

    public static partial class GW2
    {
        public partial class Factory1
        {
            public partial class WvWFactory1
            {
                public IMatchService Matches
                {
                    get
                    {
                        return new MatchService(this.ServiceClient);
                    }
                }

                public IObjectiveNameService Objectives
                {
                    get
                    {
                        return new MatchService(this.ServiceClient);
                    }
                }
            }
        }
    }
}
