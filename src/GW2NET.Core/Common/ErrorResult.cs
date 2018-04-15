// <copyright file="ErrorResult.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Common
{
    /// <summary>Represents the result that is returned when an error occurs.</summary>
    /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1" /> for more information.</remarks>
    /// ToDo: This is currently for V1 and not for V2
    public sealed class ErrorResult
    {
        /// <summary>Gets or sets a number that indicates the error kind.</summary>
        public int? Error { get; set; }

        /// <summary>Gets or sets a number that indicates the error code.</summary>
        public int? Code { get; set; }

        /// <summary>Gets or sets the line number on which the error occurred.</summary>
        public int? Line { get; set; }

        /// <summary>Gets or sets a number that represents the module in which the error occurred.</summary>
        public int? Module { get; set; }

        /// <summary>Gets or sets a number that represents the product in which the error occurred.</summary>
        public int? Product { get; set; }

        /// <summary>Gets or sets the error message.</summary>
        public string Text { get; set; }
    }
}