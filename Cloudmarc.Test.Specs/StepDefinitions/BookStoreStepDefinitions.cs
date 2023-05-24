using Cloudmarc.Test.Pages;
using Cloudmarc.Test.Pages.ToolsQA.Models;
using Cloudmarc.Test.Pages.ToolsQA.TestData;
using NUnit.Framework;

namespace Cloudmarc.Test.Specs.StepDefinitions
{
    [Binding]
    public class BookStoreStepDefinitions
    {
        private UserAccount _userAccount;

        [When(@"I click on New user Button")]
        public void WhenIClickOnNewUserButton()
        {
            ToolsQAPages.BookStoreLoginpage.NewUserButton.Click();
        }

        [When(@"I registered using valid details")]
        public void WhenIRegisteredUsingValidDetails()
        {
            UserAccount acctInfo = TestDataFaker.GenerateNewAccountDetails();
            ToolsQAPages.BookStoreRegistrationPage
                .Register(acctInfo.FirstName,acctInfo.LastName,acctInfo.UserName,acctInfo.Password);
            Assert.IsTrue(ToolsQAPages.BookStoreRegistrationPage.IsRegistrationSuccessful());
            ToolsQAPages.BookStoreRegistrationPage.BackToLogin();
           
            _userAccount = acctInfo;
        }

        [When(@"I Login to Book Store")]
        public void WhenILoginToBookStore()
        {
            ToolsQAPages.BookStoreLoginpage
                .Login(_userAccount.UserName,_userAccount.Password);

        }

        [Then(@"I should be successfully logged in")]
        public void ThenIShouldBeSuccessfullyLoggedIn()
        {
            ToolsQAPages.BookStoreMainPage.IsLoggedIn(_userAccount.UserName);
        }

        [When(@"I Login to Book Store using invalid credentials")]
        public void WhenILoginToBookStoreUsingInvalidCredentials()
        {
            ToolsQAPages.BookStoreLoginpage.Login("invaliduser", "invalidpass");
        }

        [Then(@"a validation message should display")]
        public void ThenAValidationMessageShouldDisplay()
        {
            var error = ToolsQAPages.BookStoreLoginpage.GetErrorMessage();
            Assert.That(error, Is.EqualTo("Invalid username or password!"));
        }
    }
}
