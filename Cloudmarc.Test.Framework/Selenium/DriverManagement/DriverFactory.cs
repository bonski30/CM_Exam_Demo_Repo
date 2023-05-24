using Cloudmarc.Test.Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using static Cloudmarc.Test.Framework.Selenium.Enums.WebDriverEnum;

namespace Cloudmarc.Test.Framework.Selenium.DriverManagement
{
    public class DriverFactory
    {
        public static IWebDriver GetBrowserDriver(Browser browser)
        {
            IWebDriver? driver = null;

            if(browser == Browser.Chrome)
            {
                new DriverManager().SetUpDriver(new ChromeConfig());                              
                ChromeOptions options = new ChromeOptions();               
                options.AddUserProfilePreference("download.default_directory", $"{DirHelper.GetSolutionRoot()}\\Cloudmarc.Test.Framework\\Files\\Downloads");
                
                driver = new ChromeDriver(options);

            } else if(browser == Browser.Firefox) {
                new DriverManager().SetUpDriver(new FirefoxConfig());
                driver = new FirefoxDriver();

            }else if(browser == Browser.Edge){
                new DriverManager().SetUpDriver(new EdgeConfig());
                driver = new EdgeDriver();
            }
            else
            {
                throw new ArgumentException($"Invalid Browser: {browser}. Please check configuration");
            }

            return driver;
        }
    }
}
