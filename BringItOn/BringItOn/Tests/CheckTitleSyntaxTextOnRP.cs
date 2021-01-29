using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;
using ICanWin;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using Docker.DotNet.Models;


namespace BringItOn
{
    [TestClass]
    public class CheckTitleSyntaxTextOnRP
    {
        [TestMethod]
        public void CheckTitSynText()
        {
            //            string siteURL = "https://pastebin.com";
            //            PastebinHomePage homePage = new PastebinHomePage(siteURL);
            //            string text = @"git config --global user.name  ""New Sheriff in Town""
            //git reset $(git commit - tree HEAD ^{ tree} -m ""Legacy code"")
            //git push origin master --force";
            //            string title = "how to gain dominance among developers";
            //            string expirationTime = "10 Minutes";
            //            string syntaxHihglight = "Bash";

            //            try
            //            {
            //                //Set prameters for New Paste
            //                homePage.SetNewPasteText(text);
            //                homePage.SetTitle(title);
            //                homePage.SetPasteExpiration(expirationTime);
            //                homePage.SetSyntaxHiglight(syntaxHihglight);
            //                homePage.CreateNewPasteSubmit();
            //            }
            //            catch (Exception ex)
            //            {

            //                Debug.WriteLine(ex.StackTrace.ToString());
            //            }

            //            //Wait page to be loaded
            //            Thread.Sleep(5000);


            //            //Copy URL of Result Page
            //            string resultUrl = PastebinHomePage.driver.Url;

            //            try
            //            {
            //                //Close Home Page Browser
            //                PastebinHomePage.driver.Quit();
            //            }
            //            catch (Exception ex)
            //            {
            //                Debug.WriteLine(ex.StackTrace.ToString());
            //            }


            //            //Open Resul tPage
            //            PastebinResultsPage resultPage = new PastebinResultsPage(resultUrl);
            //            string parseResultText = "";
            //            string titleResilt = "";
            //            string syntaxResult = "";
            //            try
            //            {
            //                parseResultText = resultPage.GetPasteValue();
            //                titleResilt = resultPage.GetTitleValue();
            //                syntaxResult = resultPage.GetSyntaxHighlight();
            //            }
            //            catch (NoSuchElementException ex)
            //            {
            //                Debug.WriteLine(ex.StackTrace.ToString());
            //            }
            //            catch (Exception ex)
            //            {
            //                Debug.WriteLine(ex.StackTrace.ToString());
            //            }
            //            finally
            //            {
            //                PastebinResultsPage.driverRP.Quit();
            //            }
            //            //Assert Result Page is created
            //            Assert.AreEqual(text.Replace(" ",""), parseResultText.Replace(" ",""));
            //            Assert.AreEqual(title, titleResilt);
            //            Assert.AreEqual(syntaxHihglight, syntaxResult);

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");            
            PastebinHomePage.driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
            PastebinHomePage.driver.Navigate().GoToUrl("https://cloud.google.com/products/calculator");
            PastebinHomePage.driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
            Thread.Sleep(3000);
            PastebinHomePage.driver.SwitchTo().Frame(PastebinHomePage.driver.FindElement(By.XPath("//iframe")));
            new WebDriverWait(PastebinHomePage.driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[@id='myFrame']")));
            //PastebinHomePage.driver.SwitchTo().Frame(PastebinHomePage.driver.FindElement(By.XPath("//iframe[@id='myFrame']")));
            WebDriverWait wait = new WebDriverWait(PastebinHomePage.driver, TimeSpan.FromSeconds(10));
            IWebElement box = wait.Until(e => e.FindElement(By.XPath("//input[@id='input-0']")));
            box.Click();
            IWebElement text = PastebinHomePage.driver.FindElement(By.XPath("//md-autocomplete-parent-scope/span[text()[contains(.,'Compute Engine')]]"));
            text.Click();

            IWebElement numberOfInstances = wait.Until(e => e.FindElement(By.XPath("//input[@id='input_63']")));
            numberOfInstances.SendKeys("4");

            IWebElement selOS = wait.Until(e => e.FindElement(By.Id("select_76")));
            
            if (!(selOS.Text.ToString() == "Free: Debian, CentOS, CoreOS, Ubuntu, or other User Provided OS"))
            {             
             selOS.Click();        
             IWebElement valueOfOS1 =wait.Until(e=>e.FindElement(By.XPath("//md-option/div[text()[contains(.,'Free: Debian, CentOS, CoreOS, Ubuntu, or other User Provided OS')]]")));
            valueOfOS1.Click();
            }
            

            IWebElement machineClass = wait.Until(e => e.FindElement(By.Id("select_value_label_57")));
            machineClass.Click();
            IWebElement machineClassValue = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//md-option[@id='select_option_78']/div[text()[contains(.,'Regular')]]")));
            machineClassValue.Click();
            

            //IList<IWebElement> machineSeriesValue = PastebinHomePage.driver.FindElements(By.XPath("//md-option[@ng-repeat='item in listingCtrl.computeServerGenerationOptions[listingCtrl.computeServer.family]']"));
            IWebElement machineSeries = wait.Until(e => e.FindElement(By.Id("select_88")));
            machineSeries.Click();
            //foreach (IWebElement ele in machineSeriesValue) {

            //    PastebinHomePage.driver.FindElement(By.Id("select_88")).Click(); ;
            //    IJavaScriptExecutor executor = PastebinHomePage.driver as IJavaScriptExecutor;
            //    executor.ExecuteScript("arguments[3].click();", ele);
            IWebElement machineSeriesValue = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_option_188")));
            machineSeriesValue.Click();
            // }

            IWebElement machineType = wait.Until(e => e.FindElement(By.Id("select_value_label_60")));
            machineType.Click();
            IWebElement machineTypeValue = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_option_360")));
            machineTypeValue.Click();

            


        }

        //[TestCleanup]
        //public void CloseBrowser()
        //{
        //    //Close Result Page Browser
        //    PastebinResultsPage.driverRP.Quit();
        //    PastebinResultsPage.driverRP = null;
        //}

    }
}
  