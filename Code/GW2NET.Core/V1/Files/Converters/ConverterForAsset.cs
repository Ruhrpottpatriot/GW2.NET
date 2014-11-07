// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForAsset.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="FileDataContract" /> to objects of type <see cref="Asset" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Files.Converters
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Files;
    using GW2NET.V1.Files.Json;

    /// <summary>Converts objects of type <see cref="FileDataContract"/> to objects of type <see cref="Asset"/>.</summary>
    internal sealed class ConverterForAsset : IConverter<FileDataContract, Asset>
    {
        /// <summary>Converts the given object of type <see cref="FileDataContract"/> to an object of type <see cref="Asset"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Asset Convert(FileDataContract value)
        {
            Contract.Assume(value != null);
            return new Asset
            {
                FileId = value.FileId, 
                FileSignature = value.Signature
            };
        }
    }
}