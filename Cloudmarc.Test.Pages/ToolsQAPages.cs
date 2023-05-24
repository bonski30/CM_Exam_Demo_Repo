using Cloudmarc.Test.Pages.ToolsQA.PageObjects;

namespace Cloudmarc.Test.Pages
{
    public static class ToolsQAPages
    {
        public static HomePage HomePage => new HomePage();
        public static ElementsPage ElementsPage => new ElementsPage();
        public static CheckboxPage CheckboxPage => new CheckboxPage(); 
        public static ButtonsPage ButtonsPage => new ButtonsPage();
        public static UploadAndDownloadPage uploadAndDownloadPage => new UploadAndDownloadPage();
        public static WindowsPage WindowsPage => new WindowsPage();
        public static AlertPage AlertPage => new AlertPage();
        public static AutoCompletePage AutoCompletePage => new AutoCompletePage();
        public static DatePickerPage DatePickerPage => new DatePickerPage();
        public static ToolTipsPage ToolTipsPage => new ToolTipsPage();
        public static SortablePage SortablePage => new SortablePage();
        public static DroppablePage DroppablePage => new DroppablePage();
        public static WebTablesPage WebTablesPage => new WebTablesPage();
        public static BookStoreRegistrationPage BookStoreRegistrationPage => new BookStoreRegistrationPage();
        public static BookStoreLoginpage BookStoreLoginpage => new BookStoreLoginpage();
        public static BookStoreMainPage BookStoreMainPage => new BookStoreMainPage();
    }
}
