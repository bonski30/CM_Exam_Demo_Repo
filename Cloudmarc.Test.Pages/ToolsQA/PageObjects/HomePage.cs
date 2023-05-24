using Cloudmarc.Test.Framework.Selenium.DriverManagement;
using OpenQA.Selenium;

namespace Cloudmarc.Test.Pages.ToolsQA.PageObjects
{
    public class HomePage
    {
        public void ClickOn(string elementName)
        {
            var locator = $"//div[@class='card-body'][h5[text()='{elementName}']]";
            var element = WebBrowser.FindElement(By.XPath(locator), $"{elementName} Card");
            
            element.Click();
        }
    }
}
