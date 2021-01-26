using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ICanWin
{
    class PastebinHomePage
    {
        static public ChromeDriver driver;

        public PastebinHomePage ()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
            driver.Navigate().GoToUrl("https://pastebin.com");
            driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));            
        }
       
        public void SetNewPasteText(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement textBox = wait.Until(e => e.FindElement(By.Id("postform-text")));            
            textBox.SendKeys(text);            
        }
        public void SetTitle(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement titleBox = wait.Until(e => e.FindElement(By.Id("postform-name")));
            titleBox.SendKeys(text);
        }
        public void SetPasteExpiration(string expTime)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(e=>e.FindElement(By.Id("select2-postform-expiration-container"))).Click();
            wait.Until(e=>e.FindElement(By.XPath($"//li[@class='select2-results__option'and text()='{expTime}']"))).Click();

        }
        public void CreateNewPasteSubmit()
        {
            driver.FindElement(By.XPath("//*[@id=\"w0\"]/div[5]/div[1]/div[8]/button[@class=\"btn -big\"]")).Click();
        }

    }
}
