using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Cloudmarc.Test.Framework.Selenium.ElementsHelper
{
    public class PageElements : ReadOnlyCollection<IWebElement>
    {

        private readonly IList<IWebElement> _elements;

        public PageElements(IList<IWebElement> list) : base(list)
        {
            _elements = list;
        }
    }
}
