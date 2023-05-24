using Cloudmarc.Test.Framework.Selenium.DriverManagement;

namespace Cloudmarc.Test.Framework.Common
{
    public class AddressBar
    {
        public static void NavigateToUrl(string url) { 
        
            if (!string.IsNullOrEmpty(url)) {

                if(!url.StartsWith("https://")) { 
                    url = "https://" + url;
                }
                WebBrowser.Instance.Navigate().GoToUrl(url);            
            }
        }
    }
}
