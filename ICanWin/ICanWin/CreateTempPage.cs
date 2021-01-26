using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
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



            IWebElement textBox1 = PastebinHomePage.driver.FindElement(By.Id("postform-text"));
            string paste = textBox1.GetAttribute("value");            
            Assert.AreEqual(text, paste);
        }
        [TestCleanup]
        public void CloseBrowser()
        { 
        PastebinHomePage.driver.Quit();
        PastebinHomePage.driver = null;
        }

    }
}
