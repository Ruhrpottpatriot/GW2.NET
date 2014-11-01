// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForIConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForIConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    [ContractClassFor(typeof(IConverter<,>))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForIConverter<TInput, TOutput> : IConverter<TInput, TOutput>
    {
        TOutput IConverter<TInput, TOutput>.Convert(TInput value)
        {
            // TODO: figure out how to define contracts for null references in converters that do not support null references, without breaking converters that DO support null references
            throw new System.NotImplementedException();
        }
    }
}