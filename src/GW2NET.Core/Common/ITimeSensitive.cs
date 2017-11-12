// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITimeSensitive.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for types whose value is time sensitive.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System;

    /// <summary>Provides the interface for types whose value is time sensitive.</summary>
    public interface ITimeSensitive
    {
        /// <summary>Gets or sets a timestamp.</summary>
        DateTimeOffset Timestamp { get; set; }
    }
}