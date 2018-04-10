using GW2NET.V2.Achievements.Foo;
using Xunit;

namespace GW2NET.Achievements.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var request = new Request("v2/quaggans");
            request.Parameters.Add(new RequestParameter
            {
                Key = "test",
                Value = "test1",
                Location = ParameterLocation.Url
            });
            request.Parameters.Add(new RequestParameter
            {
                Key = "test",
                Value = "test2",
                Location = ParameterLocation.Url
            });

            var req = RequestBuilder.BuildRequest(request);

        }
    }
}
