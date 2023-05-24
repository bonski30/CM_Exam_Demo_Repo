using Cloudmarc.Test.Framework.Selenium.DriverManagement;
using OpenQA.Selenium;

namespace Cloudmarc.Test.Pages.ToolsQA.PageObjects
{
    public class AlertPage
    {
        public IList<IWebElement> AlertButtons => WebBrowser.FindElements(By.XPath("//button[text()='Click me']"));

        public void ClickAlertButton()
        {
            AlertButtons.First().Click();
        }

        public void ClickTimerAlertButton()
        {
            AlertButtons[1].Click();
        }

        public void ClickConfirmAlertButton()
        {
            AlertButtons[2].Click();
        }

        public void ClickAlertPromptButton()
        {
            AlertButtons.Last().Click();
        }
    }
}
