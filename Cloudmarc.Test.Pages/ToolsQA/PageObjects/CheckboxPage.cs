using Cloudmarc.Test.Framework.Selenium.DriverManagement;
using Cloudmarc.Test.Framework.Selenium.ElementsHelper;
using OpenQA.Selenium;

namespace Cloudmarc.Test.Pages.ToolsQA.PageObjects
{
    public class CheckboxPage
    {
        public PageElements Checkboxes => WebBrowser.FindElements(By.XPath($"//label[contains(@for,'tree-node')]/span[@class='rct-checkbox']"));
        public PageElement ParentNode => WebBrowser.FindElement(By.XPath("//li[contains(@class,'rct-node-parent')]"), "Parent Node");
        public PageElement ExpandAllButton => WebBrowser.FindElement(By.XPath("//button[contains(@title, 'Expand all')]"), "Expand All Button");     
        public PageElements CheckboxLabels => WebBrowser.FindElements(By.ClassName("rct-title"));
        public PageElements ResultOutput => WebBrowser.FindElements(By.XPath("//div[@id='result']//span[@class='text-success']"));

        public string GetText()
        {
            var element = WebBrowser.FindElement(By.ClassName("rct-text"),"");
            return element.Text;
        }

        public void ExpandAll()
        {
            bool isCollapsed = ParentNode.GetAttribute("class")
                .Contains("rct-node-collapsed");

           if(isCollapsed)
           {
                ExpandAllButton.Click();
           }
        }

        public void TickCheckbox(string label)
        {
            if (!IsCheckboxTicked(label))
            {   
                var checkboxSpanLocator = By.XPath($"//label[@for='{GetCheckboxID(label)}']//span[1]");
                var checkboxSpan = WebBrowser.FindElement(checkboxSpanLocator, $"{label} checkbox");
                checkboxSpan.Click();
            }
        }

        public bool IsCheckboxTicked(string label)
        {
            var checkbox = GetCheckboxInputElement(label);
            var isTicked = checkbox.Selected;

            return isTicked;
        }

        private IWebElement GetCheckBoxSpanElement(string label)
        {
            var elementLocator = By.XPath($"//label[contains(@for,'tree-node-{label.ToLower()}')]/span[@class='rct-checkbox']");
            var element = WebBrowser.FindElement(elementLocator, $"{label} - Checkbox");

            return element;
        }

        private IWebElement GetCheckboxInputElement(string label)
        {
            var locator = By.Id(GetCheckboxID(label));
            var element = WebBrowser.FindElement(locator, $"Checkbox: {label} Input Element");

            return element;
        }

        private string GetCheckboxID(string label) 
        {
            label = ToCamelCase(label);
            
            if (label.Contains("."))
            {
                label = label.Split('.').FirstOrDefault();
            }
            var elementID = $"tree-node-{label}";
            return elementID;
        }

        private string ToCamelCase(string value)
        {
            string[] valueArray = value.Split(" ");

            if (!string.IsNullOrEmpty(value) || !string.IsNullOrWhiteSpace(value))
            {                              
                if(valueArray.Length > 1)
                {
                    valueArray[0] = valueArray[0].ToLower();
                    value = string.Join("", valueArray);

                    return value;
                }
                else
                {
                    return value.ToLower();
                }
            }

            return string.Empty;
        }
      
        public string [] GetOuputResult()
        {
            var result = ResultOutput.Select(e => e.Text)
                .Skip(0).ToArray();
            return result; 
        } 
      
    } 
}