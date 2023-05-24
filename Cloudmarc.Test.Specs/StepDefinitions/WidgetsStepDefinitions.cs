using Cloudmarc.Test.Pages;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using TechTalk.SpecFlow;

namespace Cloudmarc.Test.Specs.StepDefinitions
{
    [Binding]
    public class WidgetsStepDefinitions
    {
        private string[] _colorsList;
        private string _addedColor;
        
        [When(@"I enter the ff\. colors: (.*)")]
        public void WhenIEnterTheFf_ColorsRedGreenBlue(string colors)
        {
            _colorsList = colors.Split(',');
            ToolsQAPages.AutoCompletePage.EnterColors(_colorsList);
        }

        [Then(@"colors should be added in the field")]
        public void ThenColorsShouldBeAddedInTheField()
        {
            var actualAddedColors = ToolsQAPages.AutoCompletePage.GetAddedColors();
            Assert.IsTrue(_colorsList.SequenceEqual(actualAddedColors));
        }

        [When(@"I enter color: (.*)")]
        public void WhenIEnterColorRed(string color)
        {
            ToolsQAPages.AutoCompletePage.EnterColor(color);
            _addedColor = color;
        }

        [Then(@"color should be entered in the field")]
        public void ThenColorShouldBeEnteredInTheField()
        {
            var actualAddedColor = ToolsQAPages.AutoCompletePage.GetAddedColor();
            Assert.AreEqual(actualAddedColor, _addedColor);
        }

        [When(@"I select a date (.*) using (.*)")]
        public void WhenISelectADateMayUsingDatePicker(string date, string datePickerType)
        {
            string[] dateValues = date.Split(" ");
            
            if (datePickerType == "Date Picker")
            {
                ToolsQAPages.DatePickerPage.SelectDate(dateValues[0], dateValues[2], dateValues[1]);
            }
            else if (datePickerType == "Date Picker With Time")
            {
                ToolsQAPages.DatePickerPage.SelectDateAndTime(dateValues[0], dateValues[2], dateValues[1], dateValues[3]);
            }
            else
                throw new ArgumentException("Invalid Date Picker Type");
        }

        [When(@"I Hover To (.*)")]
        public void WhenIHoverToHoverMeButton(string elementToHover)
        {
            switch (elementToHover.ToLower())
            {
                case "hover me button":
                    ToolsQAPages.ToolTipsPage.HoverIntoButton();
                    break;
                case "hover me input":
                    ToolsQAPages.ToolTipsPage.HoverIntoInput();
                    break;
                case "contrary link":
                    ToolsQAPages.ToolTipsPage.HoverIntoContraryLink();
                    break;
                case "section link":
                    ToolsQAPages.ToolTipsPage.HoverIntoSectionLink();
                    break;
            }
        }

        [Then(@"Tooltip should display ""([^""]*)"" message")]
        public void ThenTooltipShouldDisplayMessage(string message)
        {
            Assert.IsTrue(ToolsQAPages.ToolTipsPage.ValidateToolTipMessage(message));
        }
    }
}
