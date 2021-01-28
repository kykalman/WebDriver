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
            string mailBoxURL = "https://10minutemail.com";
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

        }
    }
}
