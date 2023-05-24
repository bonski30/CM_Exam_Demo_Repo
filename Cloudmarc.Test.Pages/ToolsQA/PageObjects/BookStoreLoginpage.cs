using Cloudmarc.Test.Framework.Selenium.DriverManagement;
using Cloudmarc.Test.Framework.Selenium.ElementsHelper;
using OpenQA.Selenium;

namespace Cloudmarc.Test.Pages.ToolsQA.PageObjects
{
    public class BookStoreLoginpage
    {
        public PageElement Username => WebBrowser.FindElement(By.Id("userName"), "Bookstore - Username Field");
        public PageElement Password => WebBrowser.FindElement(By.Id("password"), "Bookstore - Username Field");
        public PageElement LoginButton => WebBrowser.FindElement(By.Id("login"), "Bookstore - Login Button");
        public PageElement NewUserButton => WebBrowser.FindElement(By.Id("newUser"), "Bookstore - New User Button");
        public PageElement ValidationMessage => WebBrowser.FindElement(By.Id("name"), "Bookstore - Validation Message");
        
        public void Login(string username, string password)
        {
            Username.SendKeys(username);
            Password.SendKeys(password);

            LoginButton.Click();
        }

        public string GetErrorMessage()
        {
            return ValidationMessage.Text;
        }
    }
}
