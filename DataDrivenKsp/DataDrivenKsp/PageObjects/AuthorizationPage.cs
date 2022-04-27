using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace DataDrivenKsp.PageObjects
{
    internal class AuthorizationPage : Form
    {
        private ITextBox emailTextBox => ElementFactory.GetTextBox(By.CssSelector("input[name = 'email']"), "Email");
        private ITextBox passwordTextBox => ElementFactory.GetTextBox(By.CssSelector("input[name = 'password']"), "Password");
        private IButton signInBtn => ElementFactory.GetButton(By.CssSelector("[data-at-selector = 'welcomeSignInBtn']"), "Sign In button");
        private IButton okCookieBtn => ElementFactory.GetButton(By.Id("CybotCookiebotDialogBodyLevelButtonAccept"), "Ok cookie button");

        public AuthorizationPage() : base(By.CssSelector(".welcome-main"), "Authorization Page")
        {
        }

        public void PerformAuthorization(string email, string password)
        {
            emailTextBox.Type(email);
            passwordTextBox.Type(password);
            okCookieBtn.Click();
            signInBtn.Click();
        }
    }
}
