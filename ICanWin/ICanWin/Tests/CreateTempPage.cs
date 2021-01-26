using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;
using ICanWin;

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

            homePage.SetNewPasteText(text);
            homePage.SetTitle(title);
            homePage.SetPasteExpiration(expirationTime);
            homePage.CreateNewPasteSubmit();

            new WebDriverWait(PastebinHomePage.driver, TimeSpan.FromSeconds(10)).Until(e => e.FindElement(By.XPath("//div[@class='content__title -no-border']")));

            string resultUrl = PastebinHomePage.driver.Url;

            PastebinResultsPage resultPage = new PastebinResultsPage(resultUrl);

            
            string parseResultText = resultPage.GetPasteValue();
            string titleResult = resultPage.GetTitleValue();
            string timeResult = resultPage.GetExpitationTime();
                                   
            Assert.AreEqual(text, parseResultText);
            Assert.AreEqual(title, titleResult);
            Assert.AreEqual(timeResult, "10 min");

        }

        //[TestCleanup]
        //public void CloseBrowser()
        //{ 
        //PastebinHomePage.driver.Quit();
        //PastebinHomePage.driver = null;
        //}

    }
}
