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
    internal class SignupPage
    {
        IWebDriver driver;
        DefaultWait<IWebDriver> wait;
        public SignupPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
            wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(6);
        }


        [FindsBy(How = How.Id, Using = "firstName")]
        private IWebElement? FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "lastName")]
        private IWebElement? LastName { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement? Email { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement? Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='submit']")]
        private IWebElement? SubmitBtn { get; set; }


        public ContactListPage ClickSubmitBtn()
        {
            FirstName?.SendKeys("Anju");
            LastName?.SendKeys("Mariya");
            Email?.SendKeys("anuz1@gmail.com");
            Password?.SendKeys("Anju@12345");

            wait.Until(d => SubmitBtn.Displayed);
            SubmitBtn?.Click();
            return new ContactListPage(driver);
        }

        


    }
}
