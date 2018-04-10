namespace GW2NET.V2.Achievements.Repositories
{
    using Foo;

    public class FindRequest : Request
    {
        /// <inheritdoc />
        public FindRequest()
            : base("v2/achivements")
        {
        }
    }
}