// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IResponse.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for service responses.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    /// <summary>Provides the interface for service responses.</summary>
    /// <typeparam name="T">The type of the response content.</typeparam>
    public interface IResponse<T> : IResponse
    {
        /// <summary>Gets or sets the response content.</summary>
        T Content { get; set; }
    }
}