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

        public CalculationResults(GoogleCloudHomePage obj)
        {
            dricerRP = driver;
        }
        public string GetVMClassValue()
        {
            //VM Class, Instance type, Region, local SSD, commitment term
            return ;
        }
        public string GetInstanceType()
        {

        }
        public string GetRegion()
        {

        }
        public string GetLocalSSD()
        {

        }
        public string GetCommitmentTerm()
        {

        }
    }
}
