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
        static public IWebDriver driver;

        public PastebinHomePage (string url)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));            
        }
       //Set text to pasty
        public void SetNewPasteText(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement textBox = wait.Until(e => e.FindElement(By.Id("postform-text")));            
            textBox.SendKeys(text);            
        }
        //Set title to pasty
        public void SetTitle(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement titleBox = wait.Until(e => e.FindElement(By.Id("postform-name")));
            titleBox.SendKeys(text);
        }
        //Set expiration time to pasty
        public void SetPasteExpiration(string expTime)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(e=>e.FindElement(By.Id("select2-postform-expiration-container"))).Click();
            wait.Until(e=>e.FindElement(By.XPath($"//li[@class='select2-results__option'and text()='{expTime}']"))).Click();

        }
        //Submit Paste
        public void CreateNewPasteSubmit()
        {
            driver.FindElement(By.XPath("//*[@id=\"w0\"]/div[5]/div[1]/div[8]/button[@class=\"btn -big\"]")).Click();
        }

    }
}
