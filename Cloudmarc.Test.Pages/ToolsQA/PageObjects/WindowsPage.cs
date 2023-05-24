using Cloudmarc.Test.Framework.Common;
using Cloudmarc.Test.Framework.Selenium.DriverManagement;
using Cloudmarc.Test.Framework.Selenium.ElementsHelper;
using OpenQA.Selenium;

namespace Cloudmarc.Test.Pages.ToolsQA.PageObjects
{
    public class WindowsPage
    {
        public PageElement NewTabButton => WebBrowser.FindElement(By.Id("tabButton"),"New Tab Button");
        public PageElement NewWindowButton => WebBrowser.FindElement(By.Id("windowButton"), "New Window Button");
        public PageElement NewWindowMessageButton => WebBrowser.FindElement(By.Id("messageWindowButton"), "New Window Message Button");
        public PageElement SampleHeading => WebBrowser.FindElement(By.Id("sampleHeading"), "Sample Heading");
        
        public void NewTab()
        {
            NewTabButton.Click();
            Window.SwitchToTab(2);
        }

        public void NewWindow()
        {
            NewWindowButton.Click();
            Window.SwitchToNewWindow();
        }

        public void NewWindowMessage()
        {
            NewWindowMessageButton.Click();
            Window.SwitchToNewWindow();
        }

        public void SwitchToParent()
        {
            Window.SwitchToParentWindow();
        }

        public void CloseWindow()
        {
            Window.Close();
        }
    }
}
