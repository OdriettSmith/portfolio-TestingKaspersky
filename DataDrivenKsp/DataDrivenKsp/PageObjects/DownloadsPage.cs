using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace DataDrivenKsp.PageObjects
{
    internal class DownloadsPage : Form
    {
        private static DownloadModal downloadModal = new DownloadModal();
        private static SendByEmailModal sendByEmailModal = new SendByEmailModal();
        private IButton osBtn(string osName) => ElementFactory.GetButton(By.XPath($"//div[contains(text(),'{osName}')]"), $"'OS: '{osName}' ");
        private IButton downloadBtn(string cardName) => ElementFactory.GetButton(By.XPath($"//div[contains(text(),'{cardName}')]//ancestor::download-application//button[@data-at-selector='appInfoDownload']"), $"Download '{cardName}' button");

        public DownloadsPage() : base(By.CssSelector("[data-at-selector='downloadPage']"), "Downloads Page")
        {
        }

        public void SelectOS(string osName)
        {
            osBtn(osName).Click();
        }

        public void DownloadOnCard(string cardName)
        {
            downloadBtn(cardName).Click();
        }

        public DownloadModal GetDownloadModal()
        {
            return downloadModal;
        }

        public SendByEmailModal GetSendByEmailModal()
        {
            return sendByEmailModal;
        }
    }
}
