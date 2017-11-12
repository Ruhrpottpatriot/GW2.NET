// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileBulkRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the FileBulkRequest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Files
{
    using GW2NET.Common;

    /// <summary>Provides data for a bulk request against the v2/files endpoint.</summary>
    internal sealed class FileBulkRequest : BulkRequest
    {
        /// <summary>Gets the resource path.</summary>
        public override string Resource
        {
            get
            {
                return "/v2/files";
            }
        }
    }
}