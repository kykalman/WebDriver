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
            string siteURL = "https://pastebin.com";
            PastebinHomePage homePage = new PastebinHomePage(siteURL);
            string text =
            @"git config --global user.name  ""New Sheriff in Town""
            git reset $(git commit - tree HEAD ^{ tree} -m ""Legacy code"")
            git push origin master --force";
            string title = "how to gain dominance among developers";
            string expirationTime = "10 Minutes";
            string syntaxHihglight = "Bash";

            
                //Set prameters for New Paste
            homePage.SetNewPasteText(text);
            homePage.SetTitle(title);
            homePage.SetPasteExpiration(expirationTime);
            homePage.SetSyntaxHiglight(syntaxHihglight);
            homePage.CreateNewPasteSubmit();
           

            //Wait page to be loaded
            Thread.Sleep(5000);


            //Copy URL of Result Page
            string resultUrl = PastebinHomePage.driver.Url;

            
             PastebinHomePage.driver.Quit();                       


            //Open Resul tPage
            PastebinResultsPage resultPage = new PastebinResultsPage(resultUrl);
            
            string parseResultText = resultPage.GetPasteValue();
            string titleResilt = resultPage.GetTitleValue();
            string syntaxResult = resultPage.GetSyntaxHighlight();
            
            
           
            //Assert Result Page is created
            Assert.AreEqual(text.Replace(" ", ""), parseResultText.Replace(" ", ""));
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
  