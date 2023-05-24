using Cloudmarc.Test.Framework.Selenium.DriverManagement;
using OpenQA.Selenium;

namespace Cloudmarc.Test.Framework.Common
{
    public class Window
    {
        public static string CurrentWindow => WebBrowser.Instance.CurrentWindowHandle;
        public static IList<string> WindowHandles => WebBrowser.Instance.WindowHandles;

        public static void SwitchToTab(int tabNumber)
        {
            WebBrowser.Instance.SwitchTo().Window(WindowHandles[tabNumber - 1]);
            WebBrowser.Instance.Navigate().Refresh();
        }

        public static void SwitchToNewWindow()
        {
            WebBrowser.Instance.SwitchTo().Window(WindowHandles.Last());
            WebBrowser.Instance.Navigate().Refresh();
        }     

        public static void SwitchToParentWindow()
        {
            WebBrowser.Instance.SwitchTo().Window(WindowHandles.FirstOrDefault());
            WebBrowser.Instance.Navigate().Refresh();
        }

        public static void Close()
        {
            WebBrowser.Instance.Close();
        }

        public static void SwitchToFrame(By by)
        {
            WebBrowser.Instance.SwitchTo()
                .Frame(WebBrowser.FindElement(by,"frame element"));
        }

        public static void SwitchToParentFrame()
        {
            WebBrowser.Instance.SwitchTo().ParentFrame();
        }
    }
}
