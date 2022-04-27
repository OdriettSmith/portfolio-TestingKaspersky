using Aquality.Selenium.Browsers;
using DataDrivenKsp.BusinessModels;
using DataDrivenKsp.PageObjects;
using DataDrivenKsp.Utils;
using DataDrivenKsp.Utils.ConfigUtils;
using DataDrivenKsp.Utils.GmailUtils;
using NUnit.Framework;
using System.Collections.Generic;

namespace DataDrivenKsp.Tests
{
    internal class EmailDownloadingTest : BaseTest
    {
        private static AuthorizationPage authorizationPage = new AuthorizationPage();
        private static MainPage mainPage = new MainPage();
        private static DownloadsPage downloadsPage = new DownloadsPage();
        private static DownloadModal downloadModal = downloadsPage.GetDownloadModal();
        private static SendByEmailModal sendByEmailModal = downloadsPage.GetSendByEmailModal();

        public static IEnumerable<TestCaseData> getTestData()
        {
            foreach (UsedData data in ConfigUtil.GetUsedData())
            {
                yield return new TestCaseData(data).SetName($"Choose OS: '{data.Os}', product: '{data.Product}'");
            }
        }

        [TestCaseSource("getTestData")]
        public void EmailDownloading(UsedData testData)
        {
            AqualityServices.Logger.Info("Step 1 - performing authorization");
            authorizationPage.PerformAuthorization(testData.UserName, testData.Password);
            mainPage.State.WaitForDisplayed();

            AqualityServices.Logger.Info("Step 2 - going to downloads page");
            mainPage.DownloadsButtonClick();

            AqualityServices.Logger.Info($"Step 3 - selecting OS: '{testData.Os}', opening download card for '{testData.Product}'");
            downloadsPage.SelectOS(testData.Os);
            downloadsPage.DownloadOnCard(testData.Product);
            Assert.True(downloadModal.State.IsDisplayed, "Download modal is not opened");

            AqualityServices.Logger.Info("Step 4 - opening Send by email modal");
            downloadModal.OtherDownloadsButtonClick();
            downloadModal.SendToMeButtonClick();
            Assert.True(sendByEmailModal.State.IsDisplayed, "Send by email modal is not opened");
            Assert.AreEqual(testData.UserName, sendByEmailModal.GetEmail(), "Email on site is not equal to expected email");

            AqualityServices.Logger.Info("Step 5 - sending by email link for download");
            sendByEmailModal.SendButtonClick();
            WaiterUtils.WaitGmailMessage();
            string message = GmailUtil.GetLastMessage();
            Assert.True(message.Contains(testData.Product), "Gmail message is not match the product");
            Assert.True(message.Contains("Download"), "Gmail message is not contain 'Download'");
            Assert.True(message.Contains("https"), "Gmail message is not contain link");
        }
    }
}
