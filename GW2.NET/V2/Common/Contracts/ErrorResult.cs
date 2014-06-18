// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorResult.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents the result that is returned when an error occurs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Common.Contracts
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>Represents the result that is returned when an error occurs.</summary>
    [Serializable]
    public class ErrorResult
    {
        /// <summary>Gets or sets the error message.</summary>
        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}