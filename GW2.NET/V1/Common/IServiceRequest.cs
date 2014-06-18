// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for service requests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Common
{
    using System;

    /// <summary>Provides the interface for service requests.</summary>
    public interface IServiceRequest
    {
        /// <summary>Gets the form data.</summary>
        UrlEncodedForm FormData { get; }

        /// <summary>Gets the resource URI.</summary>
        Uri ResourceUri { get; }
    }
}