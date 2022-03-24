using NUnit.Framework;
using MarsFramework.Pages;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test, Order(1)]
            [System.Obsolete]
            public void Test()
            {
                ShareSkill shareSkill = new ShareSkill();
                shareSkill.EnterShareSkill();

            }

            [Test, Order(2)]
            [System.Obsolete]
            public void ViewManageShareSkill()
            {
                ManageListings manageListing = new ManageListings();
                manageListing.viewListings();
                string firstskilltitle = manageListing.getfirsttitle();
                Assert.That(firstskilltitle == "Selenium", "title does not match");

            }

            [Test, Order(3)]
            [System.Obsolete]
            public void editManageShareskill()
            {
                ManageListings managelistings = new ManageListings();
                //managelistings.editListings();
                string expectedtitle = managelistings.editListings();
                string firstskilltitle = managelistings.getfirsttitle();
                Assert.That(firstskilltitle == expectedtitle, "title doest not match");
            }

            [Test, Order(4)]
            [System.Obsolete]
            public void deleteListings()
            {
                ManageListings managelistings = new ManageListings();
                string message = managelistings.deleteListings();
                string actualmessage = managelistings.getpopupmessage();
                Assert.AreEqual(message, actualmessage);

            }
        }
    }
}