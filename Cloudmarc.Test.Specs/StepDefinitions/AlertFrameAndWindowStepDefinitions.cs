using Cloudmarc.Test.Framework.Common;
using Cloudmarc.Test.Pages;
using NUnit.Framework;

namespace Cloudmarc.Test.Specs.StepDefinitions
{
    [Binding]
    public class AlertFrameAndWindowStepDefinitions
    {
        [When(@"I click the (.*) Button")]
        public void WhenIClickTheFirstButton(string button)
        {
            switch (button.ToLower())
            {
                case "first":
                    ToolsQAPages.AlertPage.ClickAlertButton();
                    break;
                case "second":
                    ToolsQAPages.AlertPage.ClickTimerAlertButton();
                    break;
                case "third":
                    ToolsQAPages.AlertPage.ClickConfirmAlertButton();
                    break;
                case "fourth":
                    ToolsQAPages.AlertPage.ClickAlertPromptButton();
                    break;
            }
        }

        [Then(@"Alert window should display")]
        public void ThenAlertWindowShouldDisplay()
        {
            Assert.That(AlertWindow.IsVisible());
        }
    }
}
