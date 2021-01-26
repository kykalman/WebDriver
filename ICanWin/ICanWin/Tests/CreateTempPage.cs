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

                Debug.WriteLine(ex.StackTrace.ToString());
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
                Debug.WriteLine(ex.StackTrace.ToString());
            }


            //Open Resul tPage
            PastebinResultsPage resultPage = new PastebinResultsPage(resultUrl);
            string parseResultText="";
            try
            {
                parseResultText = resultPage.GetPasteValue();
            }catch(NoSuchElementException ex)
            {
                Debug.WriteLine(ex.StackTrace.ToString());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace.ToString());
            }
            finally
            {
                                PastebinResultsPage.driverRP.Quit();
            }
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
