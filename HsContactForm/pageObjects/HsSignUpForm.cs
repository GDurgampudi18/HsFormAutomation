using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace HsContactForm.pageObjects
{        public class HsSignUpForm
        {
            public HsSignUpForm(IWebDriver driver)
            {
                PageFactory.InitElements(driver, this);
            }

            [FindsBy(How = How.Id, Using = "firstname-input")]
            private IWebElement firstName;

            [FindsBy(How = How.Id, Using = "lastname-input")]
            private IWebElement lastName;

            [FindsBy(How = How.Id, Using = "email-input")]
            private IWebElement userEmail;

            [FindsBy(How = How.Id, Using = "international-country-code-select-input")]
            private IWebElement country;

            [FindsBy(How = How.Id, Using = "phone-input")]
            private IWebElement phoneNumber;

            [FindsBy(How = How.Id, Using = "company-input")]
            private IWebElement company;

            [FindsBy(How = How.Name, Using = "location")]
            private IWebElement location;

            [FindsBy(How = How.Id, Using = "message-input")]
            private IWebElement message;

            [FindsBy(How = How.Name, Using = "Submit")]
            private IWebElement btnSubmit;

            [FindsBy(How = How.XPath, Using = "//div[contains(@class,'thankyou-message')]//div")]
            private IWebElement submissionSuccessForm;

            public void enterFirstName(string frstName)
            {
                firstName.SendKeys(frstName);
            }

            public void enterLastName(string lstName)
            {
                lastName.SendKeys(lstName);
            }

            public void enterUserEmail(string email)
            {
                userEmail.SendKeys(email);
            }

            public void selectCountry(string countryName)
            {
                SelectElement selectElement = new SelectElement(country);
                selectElement.SelectByText(countryName);
            }

            public void enterUserNumber(string number)
            {
                phoneNumber.SendKeys(number);
            }

            public void enterCompany(string com)
            {
                company.SendKeys(com);
            }

            public void enterLocation(string loc)
            {
                location.SendKeys(loc);
            }

            public void enterMessage(string mes)
            {
                message.SendKeys(mes);
            }

            public void clickSubmit()
            {
                btnSubmit.Click();
            }

            public string checkSubmissionSuccessForm()
            {
                return submissionSuccessForm.Text;
            }

            public string getCurrentDate(string format)
            {
                DateTime dateTime = DateTime.UtcNow.Date;
                return dateTime.ToString(format);
            }
        }
}
