namespace GW2NET.V2.Files
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Files;

    internal sealed class FileDataContractConverter : IConverter<FileDataContract, AssetV2>
    {
        public AssetV2 Convert(FileDataContract value)
        {
            Contract.Assume(value != null);

            return new AssetV2 { FileId = value.Id, IconUrl = value.Icon };
        }
    }
}