// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FactoryForLocal.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to specialty services that do not require a network connection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Factories
{
    using GW2NET.Local.DynamicEvents;

    /// <summary>Provides access to specialty services that do not require a network connection.</summary>
    public class FactoryForLocal
    {
        /// <summary>Gets access to event rotations data.</summary>
        public IDynamicEventRotationService EventRotations
        {
            get
            {
                return new DynamicEventRotationService();
            }
        }
    }
}