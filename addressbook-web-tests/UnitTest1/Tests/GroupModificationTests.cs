using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {


        [Test]
        public void GroupModification()
        {
            app.Groups.GroupModification();
             
        }

    }
}
