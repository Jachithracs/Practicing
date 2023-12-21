using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.PageObjects
{
    internal class DeleteContactPage
    {
        IWebDriver? driver;
        public DeleteContactPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[@id='delete']")]
        private IWebElement? DeleteContact { get; set; }

        public ContactListPage ClickDeleteContact()
        {
            DeleteContact?.Click();
            return new ContactListPage(driver);
        }

    }
}
