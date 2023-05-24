using AngleSharp.Dom;
using Cloudmarc.Test.Framework.Selenium.DriverManagement;
using Cloudmarc.Test.Framework.TestLogger;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Threading;

namespace Cloudmarc.Test.Framework.Selenium.ElementsHelper
{
    public class PageElement : IWebElement, IWrapsElement
    {
        private readonly IWebElement _element;

        private readonly string name;

        public PageElement(IWebElement element, string elementName)
        {
            _element = element;
            name = elementName;
        }

        public IWebElement Element => _element ?? throw new NullReferenceException("_element is null");

        public WebDriverWait wait = new WebDriverWait(WebBrowser.Instance, WebBrowser.WaitTimeout);

        private Actions action = new Actions(WebBrowser.Instance);

        public string TagName => Element.TagName;

        public string Text => Element.Text;

        public bool Enabled => Element.Enabled;

        public bool Selected => Element.Selected;

        public Point Location => Element.Location;

        public Size Size => Element.Size;

        public bool Displayed => Element.Displayed;

        public IWebElement WrappedElement => Element;

        public void Clear()
        {

            Element.Clear();
            TestLog.WriteLine($"{name} is cleared");
        }

        public void Click()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .ElementToBeClickable(Element));

            ScrollIntoView();
            action.MoveToElement(Element);
            Element.Click();
            
            TestLog.WriteLine($"{name} is clicked");
        }

        public IWebElement FindElement(By by)
        {
            return Element.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {

            return Element.FindElements(by);
        }

        public string GetAttribute(string attributeName)
        {
            return Element.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {

            return Element.GetCssValue(propertyName);
        }

        public void SendKeys(string text)
        {
            Element.Clear();
            Element.SendKeys(text);
            TestLog.WriteLine($"\"{text}\" entered on {name}");
        }

        public void Submit()
        {
            Element.Submit();
        }

        public void SelectOnDropdownByText(string option)
        {

            if (Element.TagName == "select")
                new SelectElement(Element).SelectByText(option);
            else
                throw new Exception("Invalid Element.");
        }

        public void SelectOnDropdownByValue(string option)
        {
            if (Element.TagName == "select")
                new SelectElement(Element).SelectByValue(option);
            else
                throw new Exception("Invalid Element.");
        }

        public void SelectOnDropdownTextThatContains(string option)
        {

            if (Element.TagName == "select")
            {
                var selectElement = new SelectElement(Element);
                var options = selectElement.Options;

                selectElement.SelectByValue(options.Where(opt => opt.Text.Contains(option)).FirstOrDefault().GetAttribute("value"));

            }

            else
                throw new Exception("Invalid Element.");
        }

        public void HoverInto()
        {
            var action = new Actions(WebBrowser.Instance);
            action.MoveToElement(Element).Build().Perform();
            Thread.Sleep(2000);

        }

        public string GetDomAttribute(string attributeName)
        {
            return Element.GetAttribute(attributeName);
        }

        public string GetDomProperty(string propertyName)
        {
            return Element.GetDomProperty(propertyName);
        }

        public ISearchContext GetShadowRoot()
        {
            return Element.GetShadowRoot();
        }

        public void ScrollIntoView()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)WebBrowser.Instance;
            jsExecutor.ExecuteScript("window.scrollTo(" + Element.Location.X + ", " + (Element.Location.Y - 200) + ")", "");

            TestLog.WriteLine($"Scrolled into Element: {name}");
        }

        public void DoubleClick()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                .ElementToBeClickable(Element));
            
            ScrollIntoView();
            action.DoubleClick(Element).Perform();
            TestLog.WriteLine($"Double Click on element {name}");

        }

        public void RightClick()
        {
            ScrollIntoView();
            action.ContextClick(Element).Perform();
            TestLog.WriteLine($"Right Click on Element {name}");
        }

        public void DragAndDropInto(IWebElement targetElement)
        {
            action.DragAndDrop(Element, targetElement).Build().Perform();
        }

    }
}
