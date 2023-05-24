using Cloudmarc.Test.Framework.Selenium.DriverManagement;
using Cloudmarc.Test.Framework.Selenium.ElementsHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Cloudmarc.Test.Pages.ToolsQA.PageObjects
{
    public class ButtonsPage
    {
        public PageElement DoubleClickMeButton => WebBrowser.FindElement(By.Id("doubleClickBtn"), "Double Click Me Button");
        public PageElement RightClickMeButton => WebBrowser.FindElement(By.Id("rightClickBtn"), "Right Click Me Button");
        public PageElement ClickMe => WebBrowser.FindElement(By.XPath("//button[text()='Click Me']"), "Click Me Button");
        public PageElement DoubleClickMeMessage => WebBrowser.FindElement(By.Id("doubleClickMessage"), "Double Click Me Message");
        public PageElement RightClickeMeMessage => WebBrowser.FindElement(By.Id("rightClickMessage"), "Right Clicke Me Message");
        public PageElement ClickMeMessage => WebBrowser.FindElement(By.Id("dynamicClickMessage"), "Click Me Message");

        Actions action = new Actions(WebBrowser.Instance);
        public string DoubleClick()
        {
            DoubleClickMeButton.DoubleClick();
            return DoubleClickMeMessage.Text;
        } 

        public string RightClick()
        {
            RightClickMeButton.RightClick();
            return RightClickeMeMessage.Text;
        }
        
        public string Click()
        {
            ClickMe.Click();
            return ClickMeMessage.Text;
        }
    }


}
