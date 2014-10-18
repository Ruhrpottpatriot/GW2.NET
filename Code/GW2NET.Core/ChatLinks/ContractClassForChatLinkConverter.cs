// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractClassForChatLinkConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ContractClassForChatLinkConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.ChatLinks
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    [ContractClassFor(typeof(ChatLinkConverter))]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", 
        Justification = "Only used by the Code Contracts for .NET extension.")]
    internal abstract class ContractClassForChatLinkConverter : ChatLinkConverter
    {
        protected override ChatLink ConvertFromBytes(byte[] bytes)
        {
            Contract.Requires(bytes != null);
            Contract.Ensures(Contract.Result<ChatLink>() != null);
            throw new NotImplementedException();
        }

        protected override byte[] ConvertToBytes(ChatLink value)
        {
            Contract.Requires(value != null);
            Contract.Ensures(Contract.Result<byte[]>() != null);
            throw new NotImplementedException();
        }
    }
}