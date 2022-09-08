using HsContactForm.pageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace HsContactForm.tests
{
    public class SubmitHsSignUpForm
    {

        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            //setup chrome driver
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
        }

        [Test]
        public void checkHsForm()
        {
            //lauches url
            driver.Url = "https://share.hsforms.com/1-79TdZVpS9igd9mdtdea5w1khjs";
            driver.Manage().Window.Maximize();

            //set implicit wait for 10 secs
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //initiate practice form
            HsSignUpForm form = new HsSignUpForm(driver);
            string firstName = "TestFirstName";
            string lastName = "TestLastName";
            string message = firstName + " " + lastName + " " + form.getCurrentDate("dd/MM/yyyy");
            //fill in the details and submit
            form.enterFirstName(firstName);
            form.enterLastName(lastName);
            form.enterUserEmail("test@parall.ax");
            form.selectCountry("United Kingdom");
            form.enterUserNumber("07555555555");
            form.enterCompany("Parallax");
            form.enterLocation("Leeds");
            form.enterMessage(message);
            form.clickSubmit();
            string actualText = form.checkSubmissionSuccessForm();
            Console.WriteLine(actualText);
            //check if submission form appeared
            Assert.IsTrue(actualText.Contains("Thank you for contacting us!"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
