using Cloudmarc.Test.Framework.Selenium.DriverManagement;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Cloudmarc.Test.Framework.Common
{
    public class AlertWindow
    {        
        public static void SwitchToAlert()
        {
            WebDriverWait wait = new WebDriverWait(WebBrowser.Instance, WebBrowser.WaitTimeout);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());

            WebBrowser.Instance.SwitchTo().Alert();
        }

        public static bool IsVisible()
        {
            try
            {
                SwitchToAlert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public static void OK()
        {
            WebBrowser.Instance.SwitchTo().Alert().Accept();
        }

        public static void Cancel()
        {
            WebBrowser.Instance.SwitchTo().Alert().Dismiss();
        }

        public static void Input(string text)
        {
            WebBrowser.Instance.SwitchTo().Alert().SendKeys(text);
        }
        public static string GetMessage()
        {
            if (IsVisible())
            {
                string text = WebBrowser.Instance.SwitchTo().Alert().Text;
                return text;
            }
            else { throw new Exception("Confirmation Box did not appear"); }
        }
    }
}
