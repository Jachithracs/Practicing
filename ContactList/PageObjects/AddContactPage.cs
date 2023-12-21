using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.PageObjects
{
    internal class AddContactPage
    {
        IWebDriver? driver;
        public AddContactPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='firstName']")]
        private IWebElement? FirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='lastName']")]
        private IWebElement? LastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='email']")]
        private IWebElement? Email { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='phone']")]
        private IWebElement? Phone { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='birthdate']")]
        private IWebElement? Dateofbirth { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='street1']")]
        private IWebElement? Address1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='street2']")]
        private IWebElement? Address2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='city']")]
        private IWebElement? City { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='stateProvince']")]
        private IWebElement? State { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='postalCode']")]
        private IWebElement? Postalcode { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='country']")]
        private IWebElement? Country { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='submit']")]
        private IWebElement? Submitbutn { get; set; }


        public ContactListPage ClickSubmit(string firstname,string lastname,string email,
            string phone,string address1,string address2,string city,string state,
            string postalcode,string country)
        {
            FirstName?.SendKeys(firstname);
            LastName?.SendKeys(lastname);
            Email?.SendKeys(email);
            Phone?.SendKeys(phone);
            Address1?.SendKeys(address1);
            Address2?.SendKeys(address2);
            City?.SendKeys(city);
            State?.SendKeys(state);
            Postalcode?.SendKeys(postalcode);
            Country?.SendKeys(country);

            Submitbutn?.Click();
            return new ContactListPage(driver);
        }

        public ContactListPage ClickDateofbirth(string dob)
        {
            Dateofbirth?.SendKeys(dob);
            return new ContactListPage(driver);
        }




    }
}
