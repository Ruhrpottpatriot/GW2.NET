// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerConfiguration.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The container configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Entities.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Containers;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Containers.ContainerTypes;

    /// <summary>The container configuration.</summary>
    public class ContainerConfiguration : EntityTypeConfiguration<Container>
    {
        /// <summary>The table name.</summary>
        private const string TableName = "Containers";

        /// <summary>Initializes a new instance of the <see cref="ContainerConfiguration"/> class.</summary>
        public ContainerConfiguration()
        {
            var discriminator = typeof(ContainerType).Name;
            this.Map<DefaultContainer>(config => config.Requires(discriminator).HasValue((int)ContainerType.Default))
                .Map<GiftBox>(config => config.Requires(discriminator).HasValue((int)ContainerType.GiftBox))
                .Map<UnknownContainer>(config => config.Requires(discriminator).HasValue((int)ContainerType.Unknown))
                .ToTable(TableName);
        }
    }
}