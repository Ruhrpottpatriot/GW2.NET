// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForISerializer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForISerializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common.Serializers
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.IO;

    [ContractClassFor(typeof(ISerializer<>))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForISerializer<T> : ISerializer<T>
    {
        public T Deserialize(Stream stream)
        {
            Contract.Requires(stream != null);
            Contract.Requires(stream.CanRead);
            throw new System.NotImplementedException();
        }

        public void Serialize(T value, Stream stream)
        {
            Contract.Requires(stream != null);
            Contract.Requires(stream.CanWrite);
            throw new System.NotImplementedException();
        }
    }
}