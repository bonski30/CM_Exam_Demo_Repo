using Cloudmarc.Test.Framework.Selenium.DriverManagement;
using Cloudmarc.Test.Framework.Selenium.ElementsHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Cloudmarc.Test.Pages.ToolsQA.PageObjects
{
    public  class DroppablePage
    {
        public PageElement SourceElement => WebBrowser.FindElement(By.Id("draggable"), "Source Element");
        public PageElement DestinationElement => WebBrowser.FindElement(By.Id("droppable"), "Destination Element");

        Actions action = new Actions(WebBrowser.Instance);

        /// <summary>
        /// Drags Source Element to Destination Element
        /// </summary>
        /// <returns></returns>
        public bool DragAndDropElement()
        {
            SourceElement.Click();
            action.DragAndDrop(SourceElement, DestinationElement)
                .Build()
                .Perform();
            bool isDropped = DestinationElement.Text == "Dropped!";
            
            return isDropped;
        }
    }
}
