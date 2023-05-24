using Cloudmarc.Test.Framework.Selenium.DriverManagement;
using OpenQA.Selenium;

namespace Cloudmarc.Test.Pages.ToolsQA.ComponentObjects
{
    public class NavBar
    {
        public NavBar Expand(string elementName)
        {
            var locator = $"//div[text()='{elementName}']//ancestor::div[@class='element-group']";
            var elementAccordion = WebBrowser.FindElement(By.XPath(locator), $"{elementName} Accordion");
            
            elementAccordion.Click();
            
            return this;
        }

        public void GoTo(string itemName)
        {
            var itemLocator = By.XPath($"//ul[@class='menu-list']//li/span[text()='{itemName}']");
            var itemElement = WebBrowser.FindElement(itemLocator, itemName);
            
            itemElement.Click();
        }

    }
}
