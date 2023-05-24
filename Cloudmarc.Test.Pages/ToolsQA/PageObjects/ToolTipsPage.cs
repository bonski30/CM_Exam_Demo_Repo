using Cloudmarc.Test.Framework.Selenium.DriverManagement;
using Cloudmarc.Test.Framework.Selenium.ElementsHelper;
using OpenQA.Selenium;

namespace Cloudmarc.Test.Pages.ToolsQA.PageObjects
{
    public class ToolTipsPage
    {
        public PageElement HoverMeToSeeButton => WebBrowser
            .FindElement(By.Id("toolTipButton"), "Hover Me to See Button");
        public PageElement HoverMeToSeeInput => WebBrowser
            .FindElement(By.Id("toolTipTextField"), "Hover Me to See Input");
        public PageElement ContraryLink => WebBrowser
            .FindElement(By.LinkText("Contrary"), "Contrary Link");
        public PageElement SectionLink => WebBrowser
            .FindElement(By.LinkText("1.10.32"), "Contrary Link");
        public PageElement Tooltip => WebBrowser
            .FindElement(By.XPath("//div[@class='tooltip-inner']"), "Tooltip");

        
        public void HoverIntoButton()
        {
            HoverMeToSeeButton.HoverInto();

        }

        public void HoverIntoInput()
        {
            HoverMeToSeeInput.HoverInto();
        }

        public void HoverIntoContraryLink()
        {
            ContraryLink.HoverInto();
        }

        public void HoverIntoSectionLink()
        {
            SectionLink.HoverInto();
        }

        public bool ValidateToolTipMessage(string message)
        {
            var tooltip = WebBrowser.Wait.Until(SeleniumExtras.WaitHelpers
                .ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='tooltip-inner']")));
            
            return tooltip.Text.ToLower().Equals(message.ToLower());
        }

    }
}
