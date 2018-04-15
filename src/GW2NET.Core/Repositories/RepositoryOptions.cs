// <copyright file="RepositoryOptions.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Repositories
{
    using System;

    public class RepositoryOptions
    {
        /// <summary>Gets or sets how many parallel requests can be done.</summary>
        public int MaxDegreeOfParallelism { get; set; }

        /// <summary>Gets or sets how many items can be retrieved at once.</summary>
        public int MaxBatchSize { get; set; }

        /// <summary>Gets or sets the timeout duration in seconds.</summary>
        public TimeSpan Timeout { get; set; }
    }
}