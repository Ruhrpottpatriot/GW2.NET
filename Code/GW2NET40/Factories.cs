using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2NET
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;

    public static partial class GW2
    {
        public partial class Factory1 : ServiceFactory
        {
            /// <summary>Initializes a new instance of the <see cref="ServiceFactory"/> class.</summary>
            /// <param name="serviceClient">The service client.</param>
            public Factory1(IServiceClient serviceClient)
                : base(serviceClient)
            {
                Contract.Requires(serviceClient != null);
            }

            public partial class WvWFactory1 : ServiceFactory
            {
                /// <summary>Initializes a new instance of the <see cref="ServiceFactory"/> class.</summary>
                /// <param name="serviceClient">The service client.</param>
                public WvWFactory1(IServiceClient serviceClient)
                    : base(serviceClient)
                {
                    Contract.Requires(serviceClient != null);
                }
            }
        }

        public partial class Factory2 : ServiceFactory
        {
            /// <summary>Initializes a new instance of the <see cref="ServiceFactory"/> class.</summary>
            /// <param name="serviceClient">The service client.</param>
            public Factory2(IServiceClient serviceClient)
                : base(serviceClient)
            {
                Contract.Requires(serviceClient != null);
            }

            public partial class CommerceFactory2 : ServiceFactory
            {
                /// <summary>Initializes a new instance of the <see cref="ServiceFactory"/> class.</summary>
                /// <param name="serviceClient">The service client.</param>
                public CommerceFactory2(IServiceClient serviceClient)
                    : base(serviceClient)
                {
                    Contract.Requires(serviceClient != null);
                }
            }
        }
    }
}
