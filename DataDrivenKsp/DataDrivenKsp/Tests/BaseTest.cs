using Aquality.Selenium.Browsers;
using DataDrivenKsp.Utils;
using DataDrivenKsp.Utils.ConfigUtils;
using DataDrivenKsp.Utils.GmailUtils;
using NUnit.Framework;

namespace DataDrivenKsp.Tests
{
    internal abstract class BaseTest
    {
        private static Browser browser = AqualityServices.Browser;

        [SetUp]
        public void BeforeTest()
        {
            browser.Maximize();
            browser.GoTo(ConfigUtil.GetUrl());
            browser.WaitForPageToLoad();
        }

        [TearDown]
        public void AfterTest()
        {
            browser.Quit();
            GmailUtil.DeleteLastMessage();
        }
    }
}
