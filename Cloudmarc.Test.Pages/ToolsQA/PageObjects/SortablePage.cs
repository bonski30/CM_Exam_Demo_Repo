using Cloudmarc.Test.Framework.Selenium.DriverManagement;
using Cloudmarc.Test.Framework.Selenium.ElementsHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Cloudmarc.Test.Pages.ToolsQA.PageObjects
{
    public class SortablePage
    {
        public PageElements Items => WebBrowser
            .FindElements(By.XPath("//div[@id='demo-tabpane-list']//div[contains(@class,'list-group-item ')]"));

        Actions action = new Actions(WebBrowser.Instance);
        
        public void ArrangeInDescending()
        {
            
            for (int i = 0; i < Items.Count; i++)
            {
                var items = WebBrowser
                    .FindElements(By.XPath("//div[@id='demo-tabpane-list']//div[contains(@class,'list-group-item ')]"));
                
                var sourceLoc = items.Last().Location.Y;
                var destinationLoc = items[i].Location.Y;

                var offset = (destinationLoc - sourceLoc);

                action.ClickAndHold(items.Last())
                    .MoveByOffset(0, offset)
                    .Release()
                    .Build()
                    .Perform();                               
            }                              
        }
 
    }
}
