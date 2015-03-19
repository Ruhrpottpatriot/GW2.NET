namespace GW2NET.V2.Files
{
    using GW2NET.Common;

    internal sealed class FileBulkRequest : BulkRequest
    {
        public override string Resource
        {
            get
            {
                return "/v2/files";
            }
        }
    }
}