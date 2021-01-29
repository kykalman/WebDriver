using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using static HurtMePlenty.PageObjects.GoogleCloudHomePage;
using HurtMePlenty.PageObjects;
using System.Linq;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace HurtMePlenty
{
    [TestClass]
    public class CalculateCluodResources
    {
        [TestMethod]
        public void CalculateComputeEngine()
        {
            string siteURL = "https://cloud.google.com";            
            string searchText = "Google Cloud Platform Pricing Calculator";
            string selectComponent="Compute Engine";
            int numberOfInstances = 4;
            bool addCPU = true;
                                               
            GoogleCloudHomePage homePage = new GoogleCloudHomePage(siteURL);
            homePage.SearchForContent(searchText);
            homePage.SelectSearchResult(searchText);
            homePage.SelectCalculatedComponent(selectComponent);
            homePage.SetNumberOfInstances(numberOfInstances);
            homePage.SelectOS();
            homePage.SelectMachineClass();
            homePage.SelectMachineSeries();
            homePage.SelectMachineType();
            homePage.CheckAddCpuCheckbox(addCPU);
            homePage.SelectNumberOfGPU();
            homePage.SelectGPUType();
            homePage.SelectSSD();
            homePage.SelectDatacenterLocation();
            homePage.SelectCommitedUsage();
            Thread.Sleep(10000);
            homePage.AddToEstimate();

            CalculationResults results = new CalculationResults();
            string vmClassExp = "regular";
            string instTypeExp = "n1-standard-8";
            string regoinExp = "Oregon";
            string ssdExp = "2x375";
            string commitTermExp = "1 Year";
            string priceExp = "USD 5,413.06";


            string vmClassRes = results.GetVMClassValue();
            string instTypeRes = results.GetInstanceType();
            string regoinRes = results.GetRegion();
            string ssdRes = results.GetLocalSSD();
            string commitTermRes = results.GetCommitmentTerm();
            string priceRes = results.GetCalculatedPrice();


            Assert.AreEqual(vmClassExp, vmClassRes);
            Assert.AreEqual(instTypeExp, instTypeRes);
            Assert.AreEqual(regoinExp, regoinRes);
            Assert.AreEqual(ssdExp, ssdRes);
            Assert.AreEqual(commitTermExp, commitTermRes);
            Assert.AreEqual(priceExp, priceRes);

            Thread.Sleep(10000);
            
        }
        [TestCleanup]
        public void CloseBrowser()
        {
            //Close Result Page Browser
            CalculationResults.dricerRP.Quit();
            CalculationResults.dricerRP = null;
        }
    }
}
