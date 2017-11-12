// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMapNameRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for repositories that provide localized map names.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Maps
{
    using GW2NET.Common;

    /// <summary>Provides the interface for repositories that provide localized map names.</summary>
    public interface IMapNameRepository : IRepository<int, MapName>, ILocalizable
    {
    }
}
