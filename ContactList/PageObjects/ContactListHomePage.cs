using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.PageObjects
{
    internal class ContactListHomePage
    {
        IWebDriver? driver;
        public ContactListHomePage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "signup")]
        private IWebElement? SignUpBtn { get; set; }

        public SignupPage ClickSignUpBtn()
        {
            SignUpBtn?.Click();
            return new SignupPage(driver);
        }

    }
}

