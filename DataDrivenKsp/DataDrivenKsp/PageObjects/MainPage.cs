using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace DataDrivenKsp.PageObjects
{
    internal class MainPage : Form
    {
        private IButton downloadsBtn => ElementFactory.GetButton(By.CssSelector("[data-at-menu='Downloads']"), "Downloads button");

        public MainPage() : base(By.Id("id_top"), "Main Page")
        {
        }

        public void DownloadsButtonClick()
        {
            downloadsBtn.Click();
        }
    }
}
