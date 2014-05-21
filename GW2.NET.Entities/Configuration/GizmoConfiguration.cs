// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GizmoConfiguration.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The gizmo configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Entities.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Gizmos;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Gizmos.GizmoTypes;

    /// <summary>
    /// The gizmo configuration.
    /// </summary>
    public class GizmoConfiguration : EntityTypeConfiguration<Gizmo>
    {
        /// <summary>The table name.</summary>
        private const string TableName = "Gizmos";

        /// <summary>Initializes a new instance of the <see cref="GizmoConfiguration" /> class.</summary>
        public GizmoConfiguration()
        {
            var discriminator = typeof(GizmoType).Name;
            this.Map<UnknownGizmo>(config => config.Requires(discriminator).HasValue((int)GizmoType.Unknown))
                .Map<DefaultGizmo>(config => config.Requires(discriminator).HasValue((int)GizmoType.Default))
                .Map<RentableContractNpc>(config => config.Requires(discriminator).HasValue((int)GizmoType.RentableContractNpc))
                .Map<UnlimitedConsumable>(config => config.Requires(discriminator).HasValue((int)GizmoType.UnlimitedConsumable))
                .ToTable(TableName);
        }
    }
}