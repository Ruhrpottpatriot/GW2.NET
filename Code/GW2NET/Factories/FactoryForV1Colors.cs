using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2NET.Factories
{
    using System.Globalization;
    using System.Runtime.CompilerServices;

    using GW2NET.Common;
    using GW2NET.Entities.Colors;
    using GW2NET.V1.Colors;

    public sealed class FactoryForV1Colors : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FactoryForV1Colors(IServiceClient serviceClient)
            : base(serviceClient)
        {
        }

        [IndexerName("Language")]
        public IRepository<int, ColorPalette> this[string language]
        {
            get
            {
                return new ColorRepository(this.ServiceClient) { Culture = new CultureInfo(language) };
            }
        }


        public IRepository<int, ColorPalette> Default
        {
            get
            {
                return new ColorRepository(this.ServiceClient);
            }
        }

        public IRepository<int, ColorPalette> ForCurrentCulture
        {
            get
            {
                return this[CultureInfo.CurrentCulture.TwoLetterISOLanguageName];
            }
        }

        public IRepository<int, ColorPalette> ForCurrentUICulture
        {
            get
            {
                return this[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName];
            }
        }
    }
}
