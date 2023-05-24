using Cloudmarc.Test.Framework.Selenium.DriverManagement;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Cloudmarc.Test.Framework.Common
{
    public class Keyboard
    {
        
        public static void PressEnter()
        {
            Actions action = new Actions(WebBrowser.Instance);
            action.SendKeys(Keys.Enter).Build().Perform();
        }
    }
}
