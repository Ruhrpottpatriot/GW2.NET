// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorResult.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents the result that is returned when an error occurs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Common
{
    using System.Runtime.Serialization;

    /// <summary>Represents the result that is returned when an error occurs.</summary>
    /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1" /> for more information.</remarks>
    [DataContract]
    public sealed class ErrorResult
    {
        /// <summary>Gets or sets a number that indicates the error kind.</summary>
        [DataMember(Name = "error", Order = 0)]
        public int? Error { get; set; }

        /// <summary>Gets or sets the line number on which the error occurred.</summary>
        [DataMember(Name = "line", Order = 3)]
        public int? Line { get; set; }

        /// <summary>Gets or sets a number that represents the module in which the error occurred.</summary>
        [DataMember(Name = "module", Order = 2)]
        public int? Module { get; set; }

        /// <summary>Gets or sets a number that represents the product in which the error occurred.</summary>
        [DataMember(Name = "product", Order = 1)]
        public int? Product { get; set; }

        /// <summary>Gets or sets the error message.</summary>
        [DataMember(Name = "text", Order = 4)]
        public string Text { get; set; }
    }
}