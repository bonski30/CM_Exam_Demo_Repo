using Cloudmarc.Test.Framework.Common;
using Cloudmarc.Test.Framework.Configs;
using Cloudmarc.Test.Framework.Selenium.ElementsHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static Cloudmarc.Test.Framework.Selenium.Enums.WebDriverEnum;

namespace Cloudmarc.Test.Framework.Selenium.DriverManagement
{
    public class WebBrowser
    {
        private static IWebDriver? _webDriver;

        public static IWebDriver Instance => _webDriver ?? throw new NullReferenceException("_webdriver is null.");

        public static TimeSpan WaitTimeout { get; set; }

        public static WebDriverWait Wait {get;set;}

        public static void Initialize()
        {

            var browserConfiguration = GetBrowserConfiguration();
            
            _webDriver = DriverFactory.GetBrowserDriver(browserConfiguration);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(30000);
            _webDriver.Manage().Window.Maximize();
            
            InitializeWait();

        }

        private static void InitializeWait()
        {
            var time = ConfigHelper.GetConfig<Config>("appconfig.json").WaitTimeout;
            WaitTimeout = TimeSpan.FromMilliseconds(Convert.ToDouble(time));

            Wait = new WebDriverWait(Instance, WaitTimeout);
        }

        public static void Close()
        {

            if (_webDriver != null)
            {
                _webDriver.Close();
                _webDriver.Quit();
            }

        }

        private static Browser GetBrowserConfiguration()
        {

            var browserConfig = ConfigHelper.GetConfig<Config>("appconfig.json").Browser;
            var browserEnum = Enum.GetValues(typeof(Browser)).Cast<Browser>();

            if (browserConfig != null)
            {
                return browserEnum.Where(e => e.ToString().ToUpper() == browserConfig.ToUpper()).FirstOrDefault();
            }
            else
                throw new InvalidOperationException("App Setting: BROWSER.NAME not found");

        }

        public static PageElement FindElement(By by, string elementName)
        {
            var element = new PageElement(Instance.FindElement(by), elementName);
            return element;
        }

        public static PageElements FindElements(By by)
        {
            var elements = new PageElements(Instance.FindElements(by));
            return elements;
        }

    }
}
