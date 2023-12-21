using ContactList.Helpers;
using ContactList.PageObjects;
using ContactListTesting.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.TestScripts
{
    [TestFixture]
    internal class SignupandAddcontactTests : CoreCode
    {
        [Test]
        [Category("End-to-End Test")]
        [TestCase("1998-10-03")]
        public void AddContactAndRemoveContact(string dob)
        {
            test = extent.CreateTest("Adding Contact And Removing Contact Test");

            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
             .CreateLogger();

            ContactListHomePage contactList = new ContactListHomePage(driver);
            Log.Information("New user Signup and Login test started");
            test.Info("New user Signup and Login test Started");
            var contact =contactList.ClickSignUpBtn();
            Assert.True(driver.Title.Contains("Add User"));
            Log.Information("User entered Firstname,Lastname,Email,Password and Clicked on Submit Button");
            test.Info("User entered Firstname,Lastname,Email,Password and Clicked on Submit Button");
            TakeScreenShot();
            var addcontact = contact.ClickSubmitBtn();

            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(d => d.FindElement(By.XPath("(//div[@class='main-content'])/header/h1")));

            IWebElement ContactTitle = driver.FindElement(By.XPath("(//div[@class='main-content'])/header/h1"));
            Assert.That(ContactTitle.Text.Contains("Contact"));
            Log.Information("By Valid Credentials User Logged in Successfully");
            test.Info("By Valid Credentials User Logged in Successfully");
            var viewcontact = addcontact.ClickAddNewContact();
            IWebElement ContactHeader = driver.FindElement(By.XPath("(//div[@class='main-content'])/header/h1"));
            Assert.That(ContactHeader.Text.Contains("Contact"));
            Log.Information("User can add new contact details by taking values from Excel");
            test.Info("User can add new contact details by taking values from Excel");
            viewcontact.ClickDateofbirth(dob);

            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "AddContact";

            List<ExcelData> excelDataList = ExcelUtils.ReadExcelDataAddContact(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? firstName = excelData?.FirstName;
                string? lastName = excelData?.LastName;
                string? email = excelData?.Email;
                string? phone = excelData?.Phone;
                string? address1 = excelData?.Address1;
                string? address2 = excelData?.Address2;
                string? city = excelData?.City;
                string? state = excelData?.State;
                string? postalcode = excelData?.PostalCode;
                string? country = excelData?.Country;

                Log.Information("The details for adding account details selected");
                test.Info("The details for adding account details selected");
                viewcontact.ClickSubmit(firstName, lastName, email, phone, address1, address2,
                    city, state, postalcode, country);
                TakeScreenShot();

                

                //Assert.True(driver.Url.Contains("contactList"));
                Log.Information("Adding Contact Details Completed");
                test.Info("Adding Contact Details Completed");

            }
            wait.Until(d => d.FindElement(By.XPath("(//table[@id='myTable'])/tr/td[2]")));
            var deletecontact = addcontact.ClickViewContactDetails();
            TakeScreenShot();
            Assert.True(driver.Url.Contains("contactDetails"));
            Log.Information("User is able to view Contact Details");
            test.Info("User is able to view Contact Details");

            wait.Until(d => d.FindElement(By.XPath("//button[@id='delete']")));
            deletecontact.ClickDeleteContact();
            IAlert? alert = driver?.SwitchTo().Alert();
            alert?.Accept();
            TakeScreenShot();

            wait.Until(ExpectedConditions.UrlContains("contactList"));
            Assert.True(driver.Url.Contains("contactList"));
            Log.Information("Delete Contact Details Completed");
            test.Info("Delete Contact Details Completed");
            addcontact.ClickLogout();
            TakeScreenShot();
            try
            {
                Assert.True(driver.Title.Contains("Contact List App"));
                Log.Information("User Logged Out Successfully");
                test.Info("User Logged Out Successfully");

                TakeScreenShot();
                var ss = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                test.AddScreenCaptureFromBase64String(ss,"Screenshot After Deletion");
                
                Log.Information("Adding Contact And Removing Contact Test success");
                test.Info("Adding Contact And Removing Contact Test success");
                test.Pass("Adding Contact And Removing Contact Test success");
                

            }
            catch (AssertionException ex)
            {

                Log.Error($"Adding Contact And Removing Contact Test. \n Exception: {ex.Message}");
                TakeScreenShot();
                var ss = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                test.AddScreenCaptureFromBase64String(ss);

                test.Fail("Adding Contact And Removing Contact Test failed");
            }
            Log.CloseAndFlush();




        }
    }
}
