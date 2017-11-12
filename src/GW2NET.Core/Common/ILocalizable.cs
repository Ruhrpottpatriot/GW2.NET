// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILocalizable.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for locale-aware types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System.Globalization;

    /// <summary>Provides the interface for locale-aware types.</summary>
    public interface ILocalizable
    {
        /// <summary>Gets or sets the locale.</summary>
        CultureInfo Culture { get; set; }
    }
}