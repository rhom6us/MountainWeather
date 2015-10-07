using System;
using NUnit.Framework;
using Silkweb.Mobile.Core.Services;
using Xamarin.Forms;
using Moq;
using System.Threading.Tasks;

namespace Silkweb.Mobile.Core.Tests.Services
{
    [TestFixture, RequiresSTA]
    public class DialogServiceFixture
    {
        [Test, Ignore] // Unable to return from await. Need to resolve.
        public async void DisplaysAlert()
        {
            bool alertDisplayed = false;
            var page = new Mock<Page>().Object;
            var navigationPage = new Mock<IPageContainer<Page>>();
            navigationPage.Setup(x => x.CurrentPage).Callback(() => alertDisplayed = true).Returns(page);

            var dialogService = new DialogService(navigationPage.Object);

            await dialogService.DisplayAlert("title", "this is a test");

            Assert.That(alertDisplayed, Is.True);
        }

    }
}

