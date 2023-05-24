using Cloudmarc.Test.Framework.Selenium.DriverManagement;
using Cloudmarc.Test.Framework.Selenium.ElementsHelper;
using Cloudmarc.Test.Pages.ToolsQA.Models;
using OpenQA.Selenium;

namespace Cloudmarc.Test.Pages.ToolsQA.PageObjects
{
    public class WebTablesPage
    {
        public PageElements EmailAddresses => WebBrowser
            .FindElements(By.XPath("//div[@class='rt-td'][4]"));
        public PageElement FirstNameField => WebBrowser
            .FindElement(By.Id("firstName"),"First Name Field");
        public PageElement LastNameField => WebBrowser
            .FindElement(By.Id("lastName"), "Last Name Field");
        public PageElement EmailField => WebBrowser
            .FindElement(By.Id("userEmail"), "Email Field");
        public PageElement AgeField => WebBrowser
            .FindElement(By.Id("age"), "Age Field");
        public PageElement SalaryFields => WebBrowser
            .FindElement(By.Id("salary"), "Salary Field");
        public PageElement DeptField => WebBrowser
            .FindElement(By.XPath("//input[@id='department']"), "Department Field");
        public PageElement SubmitButton => WebBrowser
            .FindElement(By.Id("submit"), "Submit Button");
        public PageElements FirstRowRecord => WebBrowser
            .FindElements(By.XPath("//div[@class='rt-tr-group'][1]//div[@class='rt-td']"));

        public WebTableUser EditValues(string fName, string lName, string email, int age, double salary, string department)
        {

            if(!string.IsNullOrEmpty(fName.Trim())) 
            {
                FirstNameField.SendKeys(fName);
            }

            if (!string.IsNullOrEmpty(lName.Trim()))
            {

                LastNameField.SendKeys(lName);
            }

            if (!string.IsNullOrEmpty(email.Trim()))
            {
                EmailField.SendKeys(email);
            }

            if (!string.IsNullOrEmpty(age.ToString().Trim()))
            {
                AgeField.SendKeys(age.ToString());
            }

            if (!string.IsNullOrEmpty(salary.ToString().Trim()))
            {
                SalaryFields.SendKeys(salary.ToString());
            }

            if (!string.IsNullOrEmpty(department))
            {
                DeptField.SendKeys(department);
            }

            SubmitButton.Click();

            return new WebTableUser()
            {
                FirstName = fName,
                LastName = lName,
                Age = age,
                Email = email,
                Salary = salary,
                Department = department,
            };

            
        }

        public void ClickEdit(string emailAddress)
        {
            var editButtonLocator = By
                .Id($"edit-record{FindEmailAddressIndex(emailAddress)}");
            var editButton = WebBrowser.FindElement(editButtonLocator, $"Edit Button for record: {emailAddress}");
            editButton.Click();
        }

        private int FindEmailAddressIndex(string emailAddress)
        {
            var listOfEmailAdd = EmailAddresses.Select(e => e.Text).ToList();
            var index = listOfEmailAdd.IndexOf(emailAddress);

            return index - 1;
        }

        public WebTableUser GetRecordDetails()
        {
            var userRecord = FirstRowRecord.Select(r => r.Text).ToArray();
            
            WebTableUser user = new WebTableUser()
            {
                FirstName = userRecord[0],
                LastName = userRecord[1],
                Age = Convert.ToInt32(userRecord[2]),
                Email = userRecord[3],
                Salary = Convert.ToDouble(userRecord[4]),
                Department = userRecord[5]
            };

            return user;

        }

    }
}
