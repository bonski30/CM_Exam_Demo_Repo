using Cloudmarc.Test.Framework.Common;
using Cloudmarc.Test.Framework.Selenium.DriverManagement;
using Cloudmarc.Test.Framework.Selenium.ElementsHelper;
using OpenQA.Selenium;

namespace Cloudmarc.Test.Pages.ToolsQA.PageObjects
{
    public class BookStoreRegistrationPage
    {
        public PageElement FirstName => WebBrowser.FindElement(By.Id("firstname"), "Registration - First Name Field");
        public PageElement LastName => WebBrowser.FindElement(By.Id("lastname"), "Registration - Last Name Field");
        public PageElement Username => WebBrowser.FindElement(By.Id("userName"), "Registration - Username Field");
        public PageElement Password => WebBrowser.FindElement(By.Id("password"), "Registration - Password Field");
        public PageElement RegisterButton => WebBrowser.FindElement(By.Id("register"), "Regiser Button");
        public PageElement BacktoLoginButton => WebBrowser.FindElement(By.Id("gotologin"), "Back to Login Button");
        public PageElement Captcha => WebBrowser.FindElement(By.Id("recaptcha-anchor"), "Captcha");

        public void Register(string firstName, string lastName, string username, string password)
        {
            //Thread.Sleeps are added to add delay on registration for captch purposes
            Thread.Sleep(3000);
            ClickCaptcha();

            FirstName.SendKeys(firstName);
            LastName.SendKeys(lastName);
            Username.SendKeys(username);
            Password.SendKeys(password);

            RegisterButton.Click();
        }

        public bool IsRegistrationSuccessful()
        {
            string message = AlertWindow.GetMessage();
            return message.Contains("User Register Successfully");
        }

        public void ClickCaptcha()
        {
            Window.SwitchToFrame(By.XPath("//iframe[@title='reCAPTCHA']"));
            Captcha.Click();
            Window.SwitchToParentFrame();
        }

        public void BackToLogin()
        {
            BacktoLoginButton.Click();
        }
    }
}
