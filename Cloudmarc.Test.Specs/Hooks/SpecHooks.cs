using Cloudmarc.Test.Framework.Selenium.DriverManagement;

namespace Cloudmarc.Test.Specs.Hooks
{
    [Binding]
    public sealed class SpecHooks
    {
        private readonly ScenarioContext _scenarioContext;
        
        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
           WebBrowser.Initialize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            WebBrowser.Close();
        }
    }
}