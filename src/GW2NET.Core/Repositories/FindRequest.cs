namespace GW2NET.Repositories
{
    public class FindRequest : Request
    {
        /// <inheritdoc />
        public FindRequest()
            : base("v2/achivements")
        {
        }
    }
}