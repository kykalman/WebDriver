using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Threading;
using HurtMePlenty.PageObjects;


namespace Hardcore.PageObjects
{
    class EmailPage:GoogleCloudHomePage
    {
        public static IWebDriver driverEM;

        public EmailPage()
        {
            driverEM = driver;
        }
        public new static IWebElement GetElementByID(string id)
        {
            WebDriverWait wait = new WebDriverWait(driverEM, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(id)));
            return element;
        }
        public new static IWebElement GetElementByXpath(string Xpatx)
        {
            WebDriverWait wait = new WebDriverWait(driverEM, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpatx)));
            return element;
        }
        public new static IWebElement GetElementByCssSelector(string selector)
        {
            WebDriverWait wait = new WebDriverWait(driverEM, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(selector)));
            return element;
        }





        public void GoToMailBox(string emailURL)
        {
            try
            {
                ((IJavaScriptExecutor)driverEM).ExecuteScript("window.open();");
                
                if (driverEM.WindowHandles.Count > 1)
                {
                    driverEM.SwitchTo().Window(driverEM.WindowHandles[1]);
                    driverEM.Navigate().GoToUrl(emailURL);
                }
                else
                {
                    throw new NoSuchWindowException();
                }
            }
            catch (NoSuchWindowException) { }
        }
        public void GetEmailAddress()
        {
            new WebDriverWait(driverEM, TimeSpan.FromSeconds(10)).Until(e=>e.FindElement(By.Id("copy_address"))).Click();
        }
        public void InsertEmailAdress()
        {
            EmailPage.driverEM.SwitchTo().Window(EmailPage.driverEM.WindowHandles[0]);
            WebDriverWait wait = new WebDriverWait(driverEM, TimeSpan.FromSeconds(10)); 

            IWebElement detailFrame = wait.Until(e=>e.FindElement(By.XPath("//iframe")));
            driver.SwitchTo().Frame(detailFrame);
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[@id='myFrame']")));
            IWebElement inputField = wait.Until(e => e.FindElement(By.XPath("//*[@id='input_459']")));
            inputField.Click();
            inputField.SendKeys(Keys.Control + "v");
        }
        public void SentEmail()
        {
            string buttonToSend = "//*[@id='dialogContent_465']/form/md-dialog-actions/button[2]";
            IWebElement buttonS = GetElementByXpath(buttonToSend);
            buttonS.Click();
        }
        public void OpenEmailWithEstimatedSum()
        {
            EmailPage.driverEM.SwitchTo().Window(EmailPage.driverEM.WindowHandles[1]);


            IWebElement receivedEmail = GetElementByXpath("//*[@id='inbox_count_number']");  
            int numberOfEmails;
            bool end = true;
            do
            {
                string numOfEm = receivedEmail.GetAttribute("innerHTML");
                numberOfEmails = Int32.Parse(numOfEm);
                end = numberOfEmails == 0;
            } while (end);

            IWebElement reseivedEmalOpen = GetElementByXpath("//*[@id='mail_messages_content']/div/div[1]/div[2]/span");
            reseivedEmalOpen.Click();
        }
        public string GetEstimatedSumEmail()
        {
            string summOfEstimation;
            IWebElement summOfRentEmail = GetElementByCssSelector("#mobilepadding > td > table > tbody > tr:nth-child(2) > td:nth-child(2) > h3");
            summOfEstimation = summOfRentEmail.GetAttribute("innerHTML");
            return summOfEstimation;
        }

    }
}
