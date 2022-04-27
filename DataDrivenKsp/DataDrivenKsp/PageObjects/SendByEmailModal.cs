using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System;

namespace DataDrivenKsp.PageObjects
{
    internal class SendByEmailModal : Form
    {
        private IButton sendBtn => ElementFactory.GetButton(By.CssSelector("[data-at-selector='installerSendSelfBtn']"), "Send button"); 
        private ITextBox emailTextBox => ElementFactory.GetTextBox(By.CssSelector("[data-at-selector='emailInput']"), "Email textbox");


        public SendByEmailModal() : base(By.CssSelector("[data-at-selector='installerSendSelfDialog']"), "Send by email modal")
        {
        }

        public void SendButtonClick()
        {
            sendBtn.State.WaitForClickable(TimeSpan.FromMilliseconds(20000));
            sendBtn.Click();
        }

        public string GetEmail()
        {
            return emailTextBox.GetAttribute("value");
        }
    }
}
