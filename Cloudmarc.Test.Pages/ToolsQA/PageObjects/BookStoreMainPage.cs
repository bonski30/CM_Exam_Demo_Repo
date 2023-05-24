using Cloudmarc.Test.Framework.Selenium.DriverManagement;
using Cloudmarc.Test.Framework.Selenium.ElementsHelper;
using OpenQA.Selenium;

namespace Cloudmarc.Test.Pages.ToolsQA.PageObjects
{
    public class BookStoreMainPage
    {
        public PageElement Username => WebBrowser
            .FindElement(By.Id("userName-value"), "Username Info");

        public bool IsLoggedIn(string username)
        {
            return Username.Text.ToLower().Equals(username.ToLower());
        }
    }
}
