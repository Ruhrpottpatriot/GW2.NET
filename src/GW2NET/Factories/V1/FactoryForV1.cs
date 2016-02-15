// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FactoryForV1.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Factories.V1
{
    using System;

    using GW2NET.Common;
    using GW2NET.Guilds;
    using GW2NET.V1.Guilds;
    using GW2NET.V1.Guilds.Converters;

    /// <summary>Provides access to version 1 of the public API.</summary>
    public class FactoryForV1 : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryForV1"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public FactoryForV1(IServiceClient serviceClient)
            : base(serviceClient)
        {
        }

        /// <summary>Gets access to the guilds data source.</summary>
        public IGuildRepository Guilds
        {
            get
            {
                var emblemTransformationConverter = new EmblemTransformationConverter();
                var emblemTransformationsConverter = new EmblemTransformationCollectionConverter(emblemTransformationConverter);
                var emblemConverter = new EmblemConverter(emblemTransformationsConverter);
                return new GuildRepository(this.ServiceClient, new GuildConverter(emblemConverter));
            }
        }
    }
}