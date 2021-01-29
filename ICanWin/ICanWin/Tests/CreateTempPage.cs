using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;
using ICanWin;
using System.Threading;
using System.Diagnostics;

namespace ICanWin
{
    [TestClass]
    public class CreateTempPage
    {
              

        [TestMethod]
        public void CreatePasteSetTextTimeTitle()
        {

            string siteURL = "https://pastebin.com";

            PastebinHomePage homePage = new PastebinHomePage(siteURL);
            string text = "Hello from WebDriver";
            string title = "helloweb";
            string expirationTime = "10 Minutes";

            
                //Set prameters for New Paste
            homePage.SetNewPasteText(text);
            homePage.SetTitle(title);
            homePage.SetPasteExpiration(expirationTime);
            homePage.CreateNewPasteSubmit();
            

            //Wait page to be loaded
            Thread.Sleep(5000);


            //Copy URL of Result Page
            string resultUrl = PastebinHomePage.driver.Url;

            
            PastebinHomePage.driver.Quit();
            

            
            //Open Resul tPage
            PastebinResultsPage resultPage = new PastebinResultsPage(resultUrl);        
            
            string parseResultText = resultPage.GetPasteValue();
            
            //Assert Result Page is created
            Assert.AreEqual(parseResultText, text);
            

        }

        [TestCleanup]
        public void CloseBrowser()
        {
            //Close Result Page Browser
            PastebinResultsPage.driverRP.Quit();
            PastebinResultsPage.driverRP = null;
        }

    }
}
