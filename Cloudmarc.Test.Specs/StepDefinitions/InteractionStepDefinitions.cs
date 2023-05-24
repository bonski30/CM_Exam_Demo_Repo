using Cloudmarc.Test.Framework.Selenium.DriverManagement;
using Cloudmarc.Test.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Cloudmarc.Test.Specs.StepDefinitions
{
    [Binding]
    public class InteractionStepDefinitions
    {
        private bool isDropped = false;

        [When(@"I arrange elements into descending order")]
        public void WhenIArrangeElementsIntoDescendingOrder()
        {
            Thread.Sleep(1000);
            ToolsQAPages.SortablePage.ArrangeInDescending();
        }

        [Then(@"sortable Elements should be displayed in descending")]
        public void ThenSortableElementsShouldBeDisplayedInDescending()
        {
            var elementsTextInDescending = 
                new string [] { "Six", "Five", "Four", "Three", "Two", "One" };
            var actualElementsText = ToolsQAPages.SortablePage.Items
                .Select(e => e.Text).ToArray();

            Assert.That(elementsTextInDescending.SequenceEqual(actualElementsText));
        }

        [When(@"I Drag and Drop source element into Target Element")]
        public void WhenIDragAndDropSourceElementIntoTargetElement()
        {
            isDropped = ToolsQAPages.DroppablePage.DragAndDropElement();
        }

        [Then(@"Target Element should display ""([^""]*)"" message")]
        public void ThenTargetElementShouldDisplayMessage(string dropped)
        {
            Assert.True(isDropped);
        }
    }
}
