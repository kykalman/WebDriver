using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Threading;

namespace HurtMePlenty.PageObjects
{
    class CalculationResults:GoogleCloudHomePage
    {
        public static IWebDriver dricerRP;

        public CalculationResults()
        {
            dricerRP = driver;
        }
        public string GetVMClassValue()
        {

            //Get VM Class Value
            IWebElement vmClass = GetElementByXpath("//*[@id='compute']/md-list/md-list-item[2]/div");
            string vmClassValue = vmClass.GetAttribute("innerHTML");            
            
            int index = vmClassValue.IndexOf(':');
            vmClassValue = vmClassValue.Substring(index + 2);
            int indexOfSumbol = vmClassValue.IndexOf('\r');
            vmClassValue = vmClassValue.Substring(0, vmClassValue.Length - (vmClassValue.Length - indexOfSumbol));
            return vmClassValue;
        }
        public string GetInstanceType()
        {
            //Get Instance Type Value
            IWebElement instType = GetElementByXpath("//*[@id='compute']/md-list/md-list-item[3]/div");
            string instTypeValue = instType.GetAttribute("innerHTML");
            int index = instTypeValue.IndexOf(':');
            instTypeValue = instTypeValue.Substring(index + 2);
            int indexOfSumbol = instTypeValue.IndexOf('\r');
            instTypeValue = instTypeValue.Substring(0, instTypeValue.Length - (instTypeValue.Length - indexOfSumbol));
            return instTypeValue;

        }
        public string GetRegion()
        {
            //Get Region Value
            IWebElement region = GetElementByXpath("//*[@id='compute']/md-list/md-list-item[4]/div");
            string regionValue = region.GetAttribute("innerHTML");
            int index = regionValue.IndexOf(':');
            regionValue = regionValue.Substring(index+2);
            int indexOfSumbol = regionValue.IndexOf('\r');
            regionValue = regionValue.Substring(0, regionValue.Length - (regionValue.Length - indexOfSumbol));
            return regionValue;            
        }
        public string GetLocalSSD()
        {
            //Get Local SSD Value
            IWebElement localSSD = GetElementByXpath("//*[@id='compute']/md-list/md-list-item[8]/div");
            string localSSDValue = localSSD.GetAttribute("innerHTML");
            int index = localSSDValue.IndexOf('2');
            localSSDValue = localSSDValue.Substring(index);
            int indexOfSumbol = localSSDValue.IndexOf('5');
            localSSDValue = localSSDValue.Substring(0, localSSDValue.Length - (localSSDValue.Length - (indexOfSumbol+1)));
            return localSSDValue;
        }
        public string GetCommitmentTerm()
        {
            //Get Cimmitment term
            IWebElement commitTerm = GetElementByXpath("//*[@id='compute']/md-list/md-list-item[9]");
            string commitTermValue = commitTerm.GetAttribute("innerHTML");
            int index = commitTermValue.IndexOf('1');
            commitTermValue = commitTermValue.Substring(index);
            int indexOfSumbol = commitTermValue.IndexOf('\r');
            commitTermValue = commitTermValue.Substring(0, commitTermValue.Length - (commitTermValue.Length - (indexOfSumbol)));
            return commitTermValue;
        }
        public string GetCalculatedPrice()
        {
            //Get Expected Price
            string sumStartPage;
            IWebElement sumStartElement = GetElementByXpath("//*[@id='compute']/md-list/md-list-item[10]/div/b");
            sumStartPage = sumStartElement.GetAttribute("innerHTML");

            sumStartPage.Replace(" ", "");
            int indexOfU = sumStartPage.IndexOf('U');
            sumStartPage = sumStartPage.Substring(indexOfU);
            int indexOfSumbol = sumStartPage.IndexOf('\r');
            sumStartPage = sumStartPage.Substring(0, sumStartPage.Length - (sumStartPage.Length - indexOfSumbol));
            return sumStartPage;
        }
    }
}
