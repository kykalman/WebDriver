using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;
using ICanWin;
using System.Threading;

namespace ICanWin
{
    [TestClass]
    public class CreateTempPage
    {
              

        [TestMethod]
        public void CreatePasteSetTextTimeTitle()
        {
            PastebinHomePage homePage = new PastebinHomePage();
            string text = "Hello";
            string title = "Hello Title";
            string expirationTime = "10 Minutes";

            try
            {
                //Set prameters for New Paste
                homePage.SetNewPasteText(text);
                homePage.SetTitle(title);
                homePage.SetPasteExpiration(expirationTime);
                homePage.CreateNewPasteSubmit();
            }catch(Exception ex)
            {
                
                Console.WriteLine(ex.Message);
                Console.WriteLine("Unable to create New Paste");
            }

            //Wait page to be loaded
            Thread.Sleep(5000);
            

            //Copy URL of Result Page
            string resultUrl = PastebinHomePage.driver.Url;

            try
            {
                //Close Home Page Browser
                PastebinHomePage.driver.Quit();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Unable to Close Browser");
            }


            //Open Resul tPage
            PastebinResultsPage resultPage = new PastebinResultsPage(resultUrl);
            
            string parseResultText = resultPage.GetPasteValue();
              
            //Assert Result Page is created
            Assert.AreEqual(text, parseResultText);
            

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
