using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Threading;

namespace HurtMePlenty.PageObjects
{
    class GoogleCloudHomePage
    {
        static public IWebDriver driver;

        public static IWebElement GetElementByID(string id)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(id)));
            return element;
        }
        public static IWebElement GetElementByXpath(string Xpatx)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Xpatx)));
            return element;
        }
        public static IWebElement GetElementByCssSelector(string selector)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(selector)));
            return element;
        }
        public GoogleCloudHomePage() {}
        public GoogleCloudHomePage(string url)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            options.AddArguments("--start-maximized");
            driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
        }
        //Set text to pasty
        public void SearchForContent(string text)
        {            
            IWebElement searchBox = GetElementByXpath("//input[@class='devsite-search-field devsite-search-query']");
            searchBox.Click();
            searchBox.SendKeys(text);
            searchBox.SendKeys(Keys.Return);
            Thread.Sleep(3000);
        }
        
        public void SelectSearchResult(string result)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(e => e.FindElement(By.XPath("//h1[@class='devsite-search-title']")));            
            IList<IWebElement> links = driver.FindElements(By.LinkText(result));
            links[0].Click();
            Thread.Sleep(2000);
        }
        public void SelectCalculatedComponent(string componemt)
        {
            IWebElement detailFrame = driver.FindElement(By.XPath("//iframe"));
            driver.SwitchTo().Frame(detailFrame);            
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[@id='myFrame']")));            
            IWebElement SelectCom = GetElementByXpath("//input[@id='input-0']");          
            SelectCom.Click();            
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(e => e.FindElement(By.XPath($"//*[@id='ul-0']/li[1]/md-autocomplete-parent-scope/span[text()[contains(.,'{componemt}')]]"))).Click();
        }
        public void SetNumberOfInstances(int instNumber)
        {            
            IWebElement numberOfInstances = GetElementByXpath("//input[@id='input_63']"); 
            numberOfInstances.SendKeys(instNumber.ToString());
        }
        public void SelectOS()
        {            
            IWebElement selOS = GetElementByID("select_76"); 

            if (!(selOS.Text.ToString() == "Free: Debian, CentOS, CoreOS, Ubuntu, or other User Provided OS"))
            {
                selOS.Click();
                IWebElement valueOfOS1 = GetElementByXpath("//md-option/div[text()[contains(.,'Free: Debian, CentOS, CoreOS, Ubuntu, or other User Provided OS')]]");
                valueOfOS1.Click();
            }
        }
        public void SelectMachineClass()
        {           
            IWebElement machineClass = GetElementByCssSelector("#select_value_label_57"); 
            machineClass.Click();
            IWebElement machineClassValue = GetElementByXpath("//md-option[@id='select_option_78']/div[text()[contains(.,'Regular')]]");
            machineClassValue.Click();
        }
        public void SelectMachineSeries()
        {            
            IWebElement machineSeries = GetElementByID("select_88"); 
            machineSeries.Click();
            IWebElement machineSeriesValue = GetElementByCssSelector("#select_option_188");
            machineSeriesValue.Click();
        }
        public void SelectMachineType()
        {            
            IWebElement machineType = GetElementByID("select_value_label_60"); 
            machineType.Click();
            IWebElement machineTypeValue = GetElementByCssSelector("#select_option_360"); 
            machineTypeValue.Click();
        }
        public void CheckAddCpuCheckbox(bool IsAcive)
        {
            if (IsAcive)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement checkbox = wait.Until(e => e.FindElement(By.XPath("//md-checkbox[@aria-label='Add GPUs']")));
                checkbox.Click();
            }

        }
        public void SelectNumberOfGPU()
        {
            IWebElement numberGPU = GetElementByXpath("//*[@id='select_value_label_392']/span[1]/div");
            numberGPU.Click();
            IWebElement GPUValue = GetElementByCssSelector("#select_option_399");
            GPUValue.Click();
        }
        public void SelectGPUType()
        {
            IWebElement GPUType = GetElementByXpath("//*[@id='select_value_label_393']/span[1]");
            GPUType.Click();
            IWebElement GPUTypeValue = GetElementByCssSelector("#select_option_406 > div.md-text.ng-binding");
            GPUTypeValue.Click();
        }
        public void SelectSSD()
        {
            IWebElement ssdSelect = GetElementByXpath("//*//*[@id='select_value_label_354']/span[1]");
            ssdSelect.Click();
            IWebElement ssdSelectType = GetElementByCssSelector("#select_option_381 > div.md-text.ng-binding");
            ssdSelectType.Click();
        }
        public void SelectDatacenterLocation()
        {
            IWebElement ssdDCL = GetElementByXpath("//*[@id='select_value_label_61']/span[1]");
            ssdDCL.Click();
            IWebElement ssdDCLType = GetElementByCssSelector("#select_option_199 > div.md-text.ng-binding");
            ssdDCLType.Click();
        }
        public void SelectCommitedUsage()
        {
            IWebElement comUse = GetElementByXpath("//*[@id='select_value_label_62']");
            comUse.Click();
            IWebElement comUseType= GetElementByCssSelector("#select_option_97 > div.md-text");
            comUseType.Click();
        }
        public void AddToEstimate()
        {
            IWebElement addToEst = GetElementByCssSelector("#mainForm > div:nth-child(3) > div > md-card > md-card-content > div > div:nth-child(1) > form > div.layout-align-end-start.layout-row > button");
            addToEst.Click();
        }
        


    }
}

