using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2NET
{
    using NUnit.Framework;

    [TestFixture]
    public class Foo
    {
        [Test]
        public void Bar()
        {
            var account = new GW2Bootstrapper("4BC5675A-F5B4-EF4A-A385-9480885E43DE4FACE73C-8A61-4AA1-8A40-6B9EDE7D6FDA ").V2Authorized.Accounts.ForDefaultCulture().GetInformation();

            Assert.IsNotNull(account);
        }
    }
}
