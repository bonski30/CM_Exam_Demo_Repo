using Cloudmarc.Test.Framework.Common;
using Cloudmarc.Test.Framework.Selenium.DriverManagement;
using Cloudmarc.Test.Framework.Selenium.ElementsHelper;
using OpenQA.Selenium;

namespace Cloudmarc.Test.Pages.ToolsQA.PageObjects
{
    public class UploadAndDownloadPage
    {
        public PageElement DownloadButton => WebBrowser.FindElement(By.Id("downloadButton"), "Download Button");
        public PageElement UploadButton => WebBrowser.FindElement(By.Id("uploadFile"), "Upload Button");
        public PageElement UploadFilePath => WebBrowser.FindElement(By.Id("uploadedFilePath"), "Filepath");
        
        public bool DownloadFile()
        {
            var filePath = $"{DirHelper.GetSolutionRoot()}\\Cloudmarc.Test.Framework\\Files\\Downloads\\sampleFile.jpeg";           
            DownloadButton.Click();
            Thread.Sleep(2000);
            return File.Exists(filePath);
        }

        public void UploadFile(string filePath)
        {
            UploadButton.SendKeys(filePath);
        }

        public string GetFilePath()
        {
            return UploadFilePath.Text;
        }
    }
}
