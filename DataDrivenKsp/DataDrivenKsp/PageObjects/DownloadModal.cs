using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace DataDrivenKsp.PageObjects
{
    internal class DownloadModal : Form
    {
        private IButton otherDownloadsBtn => ElementFactory.GetButton(By.CssSelector("[data-at-selector='otherDownloads']"), "Other downloads button");
        private IButton sendToMeBtn => ElementFactory.GetButton(By.CssSelector("[data-at-selector='sendToMe']"), "Send to me button");

        public DownloadModal() : base(By.CssSelector("[data-at-selector='downloadDialog']"), "Download modal")
        {
        }

        public void OtherDownloadsButtonClick()
        {
            otherDownloadsBtn.Click();
        }

        public void SendToMeButtonClick()
        {
            sendToMeBtn.Click();
        }
    }
}
