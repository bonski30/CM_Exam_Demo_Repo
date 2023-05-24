using Cloudmarc.Test.Framework.Selenium.DriverManagement;
using Cloudmarc.Test.Framework.Selenium.ElementsHelper;
using Cloudmarc.Test.Pages.ToolsQA.ComponentObjects;
using Cloudmarc.Test.Pages.ToolsQA.Models;
using OpenQA.Selenium;

namespace Cloudmarc.Test.Pages.ToolsQA.PageObjects
{
    public class ElementsPage
    {
        private PageElement FullNameField => WebBrowser.FindElement(By.Id("userName"), "Full Name Field");
        private PageElement EmailField => WebBrowser.FindElement(By.Id("userEmail"), "Email Field");
        private PageElement CurrentAddressField => WebBrowser.FindElement(By.Id("currentAddress"), "Current Address Field");
        private PageElement PermanentAddressField => WebBrowser.FindElement(By.Id("permanentAddress"), "Permanent Address Field");
        private PageElement SubmitButton => WebBrowser.FindElement(By.Id("submit"), "Submit Button");
        private PageElement ResultOutput => WebBrowser.FindElement(By.Id("output"), "Result Output");
        public NavBar NavBar => new NavBar();

        /// <summary>
        /// Method to Fill Up specific fields
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="email"></param>
        /// <param name="currentAddr"></param>
        /// <param name="permanentAddr"></param>
        public ElementsPage FillUp(string fullName, string email, string currentAddr, string permanentAddr)
        {
            FullNameField.SendKeys(fullName);
            EmailField.SendKeys(email);
            CurrentAddressField.SendKeys(currentAddr);
            PermanentAddressField.SendKeys(permanentAddr);

            return this;
        }

        /// <summary>
        /// Clicks Submit Button
        /// </summary>
        /// <returns>
        /// Returns instance of ElementsPage (Used to chain method call)
        /// </returns>
        public void Submit()
        {
            SubmitButton.Click();
        }

        /// <summary>
        /// Get Results of the submitted Form
        /// </summary>
        /// <returns>
        /// Object Instance of User Info
        /// </returns>
        public UserInfo GetSubmittedResults()
        {
            IList<IWebElement> results = ResultOutput
                .FindElement(By.TagName("div"))
                .FindElements(By.TagName("p")).ToList();


            return new UserInfo()
            {
                FullName = results[0].Text.Split(':').LastOrDefault(),
                Email = results[1].Text.Split(':').LastOrDefault(),
                CurrentAddr = results[2].Text.Split(':').LastOrDefault(),
                PermanentAddr = results[3].Text.Split(':').LastOrDefault()
            };
        }

        public bool IsEmailvalid(string email)
        {
            if (!string.IsNullOrEmpty(EmailField.Text))
            {
                var elementClass = EmailField.GetAttribute("class");
                return !elementClass.Contains("field-error ");
            }

            return false;
        }

    }
}
