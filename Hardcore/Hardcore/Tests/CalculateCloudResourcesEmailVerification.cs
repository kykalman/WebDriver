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
using Hardcore.PageObjects;

namespace Hardcore
{
    [TestClass]
    public class CalculateCloudResourcesEmailVerification
    {
        [TestMethod]
        public void CaculateVerifyEmail()
        {
            string siteURL = "https://cloud.google.com";
            string mailBoxURL = "https://10minutemail.com";
            string searchText = "Google Cloud Platform Pricing Calculator";
            string selectComponent = "Compute Engine";
            int numberOfInstances = 4;
            bool addCPU = true;
            string estimatedSumStartPage;
            string estimatedSummFromEmail;

            //Set parameters to calculate
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
            homePage.AddToEstimate();
            estimatedSumStartPage = homePage.GetEstimatedSumm();
            homePage.ClickSendEmailButton();
            Thread.Sleep(2000);



            EmailPage emailPage = new EmailPage(); 
            emailPage.GoToMailBox(mailBoxURL);
            emailPage.GetEmailAddress();
            emailPage.InsertEmailAdress();
            emailPage.SentEmail();
            emailPage.OpenEmailWithEstimatedSum();

            estimatedSummFromEmail = emailPage.GetEstimatedSumEmail();


            Assert.AreEqual(estimatedSumStartPage, estimatedSummFromEmail);          

        }
        [TestCleanup]
        public void CloseBrowser()
        {
            //Close Result Page Browser
            EmailPage.driverEM.Quit();
            EmailPage.driverEM = null;
        }
    }
}
