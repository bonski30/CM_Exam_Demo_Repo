using Cloudmarc.Test.Framework.Common;
using Cloudmarc.Test.Framework.Selenium.DriverManagement;
using Cloudmarc.Test.Framework.Selenium.ElementsHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Cloudmarc.Test.Pages.ToolsQA.PageObjects
{
    public class AutoCompletePage
    {
        public PageElement MultipleColorField => WebBrowser.FindElement(By.Id("autoCompleteMultipleInput"), "Multiple Color Field");
        public PageElement SingleColorField => WebBrowser.FindElement(By.Id("autoCompleteSingleInput"), "Multiple Color Field");
        
        public IList<IWebElement> AutoCompleteOptions = WebBrowser.FindElements(By.XPath("//div[contains(@class,'auto-complete__option')]"));
        public PageElements AddedColorsList => WebBrowser.FindElements(By.XPath("//div[contains(@class,'auto-complete__multi-value__labe')]"));
        public PageElement AddedColor => WebBrowser.FindElement(By.XPath("//div[contains(@class,'auto-complete__single-value')]"), "Added color input");
        
        public void EnterColors(params string [] colors)
        {
            foreach (var color in colors) 
            {
                MultipleColorField.SendKeys(color);
                SelectOptionFromAutoComplete(color);
            }
        }

        public void EnterColor(string color)
        {
            SingleColorField.SendKeys(color);
            SelectOptionFromAutoComplete(color);         
        }

        private void SelectOptionFromAutoComplete(string optn)
        {
            var options = WebBrowser.Wait
                .Until(SeleniumExtras.WaitHelpers
                .ExpectedConditions
                .VisibilityOfAllElementsLocatedBy(By.XPath("//div[contains(@class,'auto-complete__option')]")));
             
            var option = options
            .Where(opt => opt.Text.ToLower().Equals(optn.ToLower()))
            .FirstOrDefault();
            
            if(option != null)
            {
                Keyboard.PressEnter();
            }         
        }

        public string [] GetAddedColors()
        {
            string[] colors = AddedColorsList.Select(c=>c.Text).ToArray();
            return colors;
        }

        public string GetAddedColor()
        {
            return AddedColor.Text;
        }
    }
}
