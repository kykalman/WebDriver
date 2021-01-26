using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ICanWin
{
    class PastebinResultsPage: PastebinHomePage
    {
        static public ChromeDriver driverRP;
        
        public PastebinResultsPage(string url)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
        }
        public static void GetHomePage()
        {
            driverRP = driver;
        } 
        
        public string GetPasteValue()
        {
            WebDriverWait wait = new WebDriverWait(driverRP, TimeSpan.FromSeconds(10));
            IWebElement pasteResult = wait.Until(e =>e.FindElement(By.XPath("//textarea[@class='textarea']")));
            string paste = pasteResult.GetAttribute("value");
            return paste;
        }
        public string GetTitleValue()
        {
            WebDriverWait wait = new WebDriverWait(driverRP, TimeSpan.FromSeconds(10));
            IWebElement titleResult = wait.Until(e => e.FindElement(By.XPath("/html/body/div[2]/div[2]/div[1]/div[2]/div[1]/div[3]/div[1]/h1")));
            string title = titleResult.GetAttribute("value");
            return title;

        }
        public string GetExpitationTime()
        {
            WebDriverWait wait = new WebDriverWait(driverRP, TimeSpan.FromSeconds(10));
            IWebElement titleResult = wait.Until(e => e.FindElement(By.XPath("//div[@class='expire']")));
            string expTimeRes = titleResult.GetAttribute("value");
            return expTimeRes;
        }

    }
}
