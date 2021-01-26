using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ICanWin
{
    class PastebinResultsPage
    {
        static public IWebDriver driverRP;
        
        public PastebinResultsPage(string url)
        {
            //Open Result Page
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            driverRP = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
            driverRP.Navigate().GoToUrl(url);
            driverRP.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
        }       
        //Get Pasted Value
        public string GetPasteValue()
        {
            WebDriverWait wait = new WebDriverWait(driverRP, TimeSpan.FromSeconds(10));
            IWebElement pasteResult = wait.Until(e =>e.FindElement(By.XPath("//textarea[@class='textarea']")));
            string paste = pasteResult.GetAttribute("value");
            return paste;
        }
 
    }
}
