using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.PageObjects
{
    internal class ContactListPage
    {
        IWebDriver? driver;
        public ContactListPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
           
        }

        [FindsBy(How = How.Id, Using = "add-contact")]
        private IWebElement? AddNewContact { get; set; }

        [FindsBy(How = How.XPath, Using = "(//table[@id='myTable'])/tr/td[2]")]
        private IWebElement? ViewContactDetails { get; set; }

        [FindsBy(How = How.ClassName, Using = "logout")]
        private IWebElement? Logout { get; set; }

        public AddContactPage ClickAddNewContact()
        {
           
            AddNewContact?.Click();
            return new AddContactPage(driver);
        }

        public DeleteContactPage ClickViewContactDetails()
        {
            

            ViewContactDetails?.Click();
            return new DeleteContactPage(driver);
        }

        public ContactListHomePage ClickLogout()
        {
            Logout?.Click();
            return new ContactListHomePage(driver);
        }

    }
}
