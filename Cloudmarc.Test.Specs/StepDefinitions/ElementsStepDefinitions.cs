using Cloudmarc.Test.Framework.Common;
using Cloudmarc.Test.Pages;
using Cloudmarc.Test.Pages.ToolsQA.Models;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;

namespace Cloudmarc.Test.Specs.StepDefinitions
{
    [Binding]
    public class ElementsStepDefinitions
    {       
        private UserInfo? _userInfo;
        private WebTableUser? _updatedUserValues;
        private string? _buttonClicked;
        private bool _isFileDownloaded;
 
        [Given(@"I'm navigated to (.*) - (.*) Page")]
        public void GivenImNavigatedToElements_TextBoxPage(string component, string page)
        {
            AddressBar.NavigateToUrl("https://demoqa.com/");
            ToolsQAPages.HomePage.ClickOn(component);
            ToolsQAPages.ElementsPage.NavBar.Expand(component).GoTo(page);
        }

        [When(@"I submit the ff\. valid Infomation")]
        public void WhenISubmitTheFf_ValidInfomation(Table table)
        {

            _userInfo = table.CreateSet<UserInfo>()
                .Select(t=> new UserInfo()
                {
                    FullName = t.FullName,
                    Email = t.Email,
                    CurrentAddr = t.CurrentAddr,
                    PermanentAddr = t.PermanentAddr
                }).FirstOrDefault();

            ToolsQAPages.ElementsPage
                .FillUp(_userInfo.FullName, _userInfo.Email,
                _userInfo.CurrentAddr, _userInfo.PermanentAddr);

            ToolsQAPages.ElementsPage.Submit();
        }

        [Then(@"Output result should be correct")]
        public void ThenOutputResultShouldBeCorrect()
        {
            UserInfo actualInfoResult = ToolsQAPages.ElementsPage.GetSubmittedResults();
            UserInfo expectedInfoResult = _userInfo;

            actualInfoResult.Should().BeEquivalentTo(expectedInfoResult);
           
        }

        [When(@"I click Edit on record with email: (.*)")]
        public void WhenIClickEditOnRecordWithEmailDdasda_Tset_Com(string email)
        {
            ToolsQAPages.WebTablesPage.ClickEdit(email);
        }

        [When(@"I Edit the values with the ff\.")]
        public void WhenIEditTheValuesWithTheFf_(Table table)
        {
           
            _updatedUserValues = table.CreateSet<WebTableUser>()
                .Select(t => new WebTableUser()
                {
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    Age = t.Age,
                    Email = t.Email,
                    Salary = t.Salary,
                    Department = t.Department
                }).FirstOrDefault();

            ToolsQAPages.WebTablesPage
                .EditValues(_updatedUserValues.FirstName, _updatedUserValues.LastName, _updatedUserValues.Email,
                _updatedUserValues.Age, _updatedUserValues.Salary, _updatedUserValues.Department);

        }

        [Then(@"Changes should reflect on the table")]
        public void ThenChangesShouldReflectOnTheTable()
        {
            var actualUpdatedvalues = ToolsQAPages.WebTablesPage.GetRecordDetails();
            _updatedUserValues.Should().BeEquivalentTo(actualUpdatedvalues);
        }

        [When(@"I click (.*) Button")]
        public void WhenIClickDoubleClickButton(string button)
        {          
            switch(button.ToLower())
            {
                case "double click me":
                    _buttonClicked = ToolsQAPages.ButtonsPage.DoubleClick();
                    break;
                case "right click me":
                    _buttonClicked = ToolsQAPages.ButtonsPage.RightClick();
                    break;
                case "click me":
                    _buttonClicked = ToolsQAPages.ButtonsPage.Click();
                    break;
            }
        }

        [Then(@"""([^""]*)"" message should appear")]
        public void ThenMessageShouldAppear(string message)
        {
            var actualMessage = _buttonClicked;
            Assert.AreEqual(message,actualMessage);       
        }

        [Then(@"Email Field should display error")]
        public void ThenEmailFieldShouldDisplayError()
        {
           
        }

        [Then(@"the file should be downloaded")]
        public void ThenTheFileShouldBeDownloaded()
        {
            Assert.IsTrue(_isFileDownloaded);
            File.Delete($"{DirHelper.GetSolutionRoot()}\\Cloudmarc.Test.Framework\\Files\\Downloads\\sampleFile.jpeg");            
        }

        [When(@"I want to upload a file by click Choose File and entering its path")]
        public void WhenIWantToUploadAFileByClickChooseFileAndEnteringItsPath()
        {
            ToolsQAPages.uploadAndDownloadPage
                .UploadFile($"{DirHelper.GetSolutionRoot()}\\Cloudmarc.Test.Framework\\Files\\Uploads\\Upload.txt");
        }

        [Then(@"Filepath should display (.*)")]
        public void ThenFilepathShouldBeDisplayed(string fileName)
        {
            Assert.AreEqual(ToolsQAPages.uploadAndDownloadPage.GetFilePath(), $"C:\\fakepath\\{fileName}");
        }

        [When(@"I Click on Download Button")]
        public void WhenIClickOnDownloadButton()
        {
           _isFileDownloaded =  ToolsQAPages.uploadAndDownloadPage.DownloadFile();
        }
        
        [When(@"I Tick the ff. checkboxes: (.*)")]
        public void WhenITickTheFFCheckboxes(string checkbox)
        {
            ToolsQAPages.CheckboxPage.ExpandAll();

            string[] checkboxes = checkbox.Split(',');

            foreach (var cb in checkboxes)
            {
                ToolsQAPages.CheckboxPage.TickCheckbox(cb);
            }
            
        }

        [Then(@"Result should display You have selected: (.*)")]
        public void ThenAllCheckedTextboxesShouldBeEnumeratedInTheResult_(string results)
        {
            var expectedOutput = results.Split(' ');
            var actualOutput = ToolsQAPages.CheckboxPage.GetOuputResult();

            CollectionAssert.AreEqual(actualOutput, expectedOutput);

        }

    }
}
