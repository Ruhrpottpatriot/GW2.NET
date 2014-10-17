// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResponseContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ResponseContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Common
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;

    [ContractClassFor(typeof(IResponse<>))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    internal abstract class ResponseContract<T> : IResponse<T>
    {
        public T Content { get; set; }

        public CultureInfo Culture { get; set; }

        public DateTimeOffset Date { get; set; }

        public IDictionary<string, string> ExtensionData { get; set; }
    }
}