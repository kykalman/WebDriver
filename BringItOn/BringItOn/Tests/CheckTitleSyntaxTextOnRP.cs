using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;
using ICanWin;
using System.Threading;
using System.Diagnostics;


namespace BringItOn
{
    [TestClass]
    public class CheckTitleSyntaxTextOnRP
    {
        [TestMethod]
        public void CheckTitSynText()
        {
            string siteURL = "https://pastebin.com";
            PastebinHomePage homePage = new PastebinHomePage(siteURL);
            string text = @"git config --global user.name  ""New Sheriff in Town""
git reset $(git commit - tree HEAD ^{ tree} -m ""Legacy code"")
git push origin master --force";
            string title = "how to gain dominance among developers";
            string expirationTime = "10 Minutes";
            string syntaxHihglight = "Bash";

            try
            {
                //Set prameters for New Paste
                homePage.SetNewPasteText(text);
                homePage.SetTitle(title);
                homePage.SetPasteExpiration(expirationTime);
                homePage.SetSyntaxHiglight(syntaxHihglight);
                homePage.CreateNewPasteSubmit();
            }
            catch (Exception ex)
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace.ToString());
            }


            //Open Resul tPage
            PastebinResultsPage resultPage = new PastebinResultsPage(resultUrl);
            string parseResultText = "";
            string titleResilt = "";
            string syntaxResult = "";
            try
            {
                parseResultText = resultPage.GetPasteValue();
                titleResilt = resultPage.GetTitleValue();
                syntaxResult = resultPage.GetSyntaxHighlight();
            }
            catch (NoSuchElementException ex)
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
            Assert.AreEqual(text.Replace(" ",""), parseResultText.Replace(" ",""));
            Assert.AreEqual(title, titleResilt);
            Assert.AreEqual(syntaxHihglight, syntaxResult);


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
  