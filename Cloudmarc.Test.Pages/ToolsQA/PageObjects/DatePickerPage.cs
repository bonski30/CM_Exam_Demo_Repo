using Cloudmarc.Test.Framework.Selenium.DriverManagement;
using Cloudmarc.Test.Framework.Selenium.ElementsHelper;
using OpenQA.Selenium;

namespace Cloudmarc.Test.Pages.ToolsQA.PageObjects
{
    public class DatePickerPage
    {
        public PageElement DateField => WebBrowser.FindElement(By.Id("datePickerMonthYearInput"), "Date Picker");
        public PageElement DateAndTimeField => WebBrowser.FindElement(By.Id("dateAndTimePickerInput"), "Date And Time Picker");
        public PageElement MonthDropdown => WebBrowser.FindElement(By.ClassName("react-datepicker__month-select"), "Month dropdown");
        public PageElement YearDropdown => WebBrowser.FindElement(By.ClassName("react-datepicker__year-select"), "Year dropdown");
        public PageElement MonthDatePickerArrow => WebBrowser.FindElement(By.ClassName("react-datepicker__month-read-view--down-arrow"), "Month Arrow");
        public PageElement YearPickerArrow => WebBrowser.FindElement(By.ClassName("react-datepicker__year-read-view--down-arrow"), "Year Arrow");
        public PageElements MonthOptions => WebBrowser.FindElements(By.XPath("//div[contains(@class,'react-datepicker__month-option')]"));
        public PageElements YearOptions => WebBrowser.FindElements(By.XPath("//div[contains(@class,'react-datepicker__year-option')]"));
        public PageElements TimeOptions => WebBrowser.FindElements(By.XPath("//li[contains(@class,'react-datepicker__time-list-item ')]"));
        public PageElement SelectedMonth => WebBrowser.FindElement(By.ClassName("react-datepicker__month-read-view--selected-month"), "Selected Month");
        public PageElement SelectedYear => WebBrowser.FindElement(By.ClassName("react-datepicker__year-read-view--selected-year"), "Selected Year");
        
        public void SelectDate(string month, string year, string day)
        {           
            DateField.Click();
            MonthDropdown.SelectOnDropdownByText(month);
            YearDropdown.SelectOnDropdownByText(year);

            var dayElement = GetDayElement(month, day);

            dayElement.Click();

        }

        public void SelectDateAndTime(string month, string year, string day, string time)
        {
            DateAndTimeField.Click();

            if(SelectedMonth.Text.ToLower() != month.ToLower())
            {
                MonthDatePickerArrow.Click();
                var monthElement = MonthOptions
                    .Where(month => month.Text.Equals(month))
                    .FirstOrDefault();
                monthElement.Click();
            }

            if(SelectedYear.Text.ToLower() != year.ToLower())
            {
                YearPickerArrow.Click();
                var s = YearOptions.Select(y=>y.Text).ToList();
                var yearElement = YearOptions
                    .Where(y => y.Text.Contains(year))
                    .FirstOrDefault();
                yearElement.Click();
            }
       
            var dayElement = GetDayElement(month, day);
            dayElement.Click();
            var ss = TimeOptions;
            var timeElement = TimeOptions
                 .Where(t => t.Text.Equals(time))
                .FirstOrDefault();
            timeElement.Click();
        }

        private IWebElement GetDayElement(string month, string day)
        {
            var dayElement = WebBrowser
               .FindElement(By.XPath("//div[contains(@class,'react-datepicker__day--')]" +
               $"[contains(@aria-label,'{month}')]" +
               $"[text()='{day}']"), "Day Picker");
            
            return dayElement;
        }
    }
}
