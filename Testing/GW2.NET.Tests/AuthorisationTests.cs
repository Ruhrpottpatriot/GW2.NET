// <copyright file="Foo.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET
{
    using NUnit.Framework;

    [TestFixture]
    public class AuthorisationTests
    {
        [Test]
        public void Authorisation()
        {
            var account = new GW2Bootstrapper("4BC5675A-F5B4-EF4A-A385-9480885E43DE4FACE73C-8A61-4AA1-8A40-6B9EDE7D6FDA ").AuthorizedServices.Accounts.ForDefaultCulture().GetInformation();

            Assert.IsNotNull(account);
        }
    }
}
