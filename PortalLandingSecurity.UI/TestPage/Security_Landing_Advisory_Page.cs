// ***********************************************************************
// Author           : AMERICAS\Chandudhar_S_B
// Created          : 3/15/2019 12:31:35 PM
//
// Last Modified By : AMERICAS\Chandudhar_S_B
// Last Modified On : 3/15/2019 12:31:35 PM
// ***********************************************************************
// <copyright file="Security_Landing_Advisory_Page.cs" company="Dell">
//     Copyright (c) Dell 2019. All rights reserved.
// </copyright>
// <summary>Provide a summary of the page class here.</summary>
// ***********************************************************************


using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Dell.Adept.Core;
using Dell.Adept.UI.Web.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using SecurityLandingPortal.Drivers;
using System.Text.RegularExpressions;
using System.Collections;
using System.Threading;
using System.IO;
using OpenQA.Selenium.Interactions;
using System.Linq;

namespace SecurityLandingPortal.TestPage
{
    /// <summary>
    /// This base class is the where all specific page classes will be derived.
    /// </summary>
    public class Security_Landing_Advisory_Page : PageBase

    {
        IWebDriver webDriver;

        /// <summary>
        /// Constructor to hand off webDriver
        /// </summary>
        /// <param name="webDriver"></param>
        public Security_Landing_Advisory_Page(IWebDriver webDriver) : base(ref webDriver)
        {
            this.webDriver = webDriver;

            //populate the following variables with the appropriate value
            //Name = "";
            //Url = "";
            //ProductUnit = "";
        }

        /// <summary>
        /// Treat this like a BVT of the page. If Validate does not pass, throw exception and console.writeline a return message into Test Class
        /// </summary>
        /// <returns>validated</returns>
        public override bool Validate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// determines whether or not the driver is active on this page. Must be overriden with each subclass.
        /// </summary>
        /// <returns>active</returns>
        public override bool IsActive()
        {
            throw new NotImplementedException();
        }

        #region Elements

        public IWebElement _pageTitle { get { return webDriver.FindElement(By.XPath("//*[@id='site-wrapper']/div/div[3]/div[2]/app-root/div/app-articles/div[1]/div[1]/div/h1")); } }

        public IWebElement _securityAdvisoryRbutton { get { return webDriver.FindElement(By.XPath("//*[@id='checks1']/label[1]")); } }

        public IWebElement _securityNoticesRbutton { get { return webDriver.FindElement(By.XPath("//*[@id='checks1']/label[2]")); } }

        public IWebElement _securityInformationalRbutton { get { return webDriver.FindElement(By.XPath("//*[@id='checks1']/label[3]")); } }

        public IWebElement _securityLandingSignInMasthead { get { return webDriver.FindElement(By.CssSelector(".masthead__utilities_user.dropdown.utility-button.auth-page")); } }
        public IWebElement _securityLandingSignInOnPage { get { return webDriver.FindElement(By.XPath("//*[@class='col-lg-12 alert']//span//a")); } }
        public IWebElement UsernameField { get { return webDriver.FindElement(By.Id("EmailAddress")); } }
        public IWebElement PasswordField { get { return webDriver.FindElement(By.Id("Password")); } }
        public IWebElement Siginbtn { get { return webDriver.FindElement(By.Id("sign-in-button")); } }

        public IWebElement _pageHeader { get { return WebDriver.FindElement(By.XPath("//*[@id='articlesDescription']/p")); } }

        public IWebElement _pageSubHeader1 { get { return webDriver.FindElement(By.XPath("//*[@id='articlesDescription']/ul/li[1]")); } }

        public IWebElement _pageSubHeader2 { get { return webDriver.FindElement(By.XPath("//*[@id='articlesDescription']/ul/li[2]")); } }

        public IWebElement _dateText { get { return webDriver.FindElement(By.XPath("//*[@id='site-wrapper']/div/div[3]/div[2]/app-root/div/app-articles/div[1]/div[1]/div/div[2]")); } }

        public IWebElement _securityIAlertInfoIcon { get { return webDriver.FindElement(By.Id("infoicon")); } }

        public IWebElement _pageGrid { get { return webDriver.FindElement(By.Id("grid")); } }

        public IWebElement _securityAdvisoryGridGoToLastPagination { get { return webDriver.FindElement(By.XPath("//*[@id='grid']//*[@title='Go to the last page']")); } }
        public IWebElement _securityAdvisoryGridGoToNextPagination { get { return webDriver.FindElement(By.XPath("//*[@id='grid']//*[@title='Go to the next page']")); } }
        public IWebElement _securityAdvisoryGridGoToPreviousPagination { get { return webDriver.FindElement(By.XPath("//*[@id='grid']//*[@title='Go to the previous page']")); } }

        public IWebElement _securityAdvisoryGridPageNumbersInfo { get { return webDriver.FindElement(By.CssSelector(".k-pager-info.k-label")); } }

        public IWebElement _securityAdvisoryGridGoToFirstPagination { get { return webDriver.FindElement(By.XPath("//*[@id='grid']//*[@title='Go to the first page']")); } }

        private IList<IWebElement> _securityAdvisoryGridHeaderColumnsInfo;
        public IList<IWebElement> securityAdvisoryGridHeaderColumnsInfo
        {
            get
            {
                _securityAdvisoryGridHeaderColumnsInfo = webDriver.FindElements(By.CssSelector(".k-grid-header-wrap"));
                return _securityAdvisoryGridHeaderColumnsInfo;
            }
        }

        private IList<IWebElement> _securityLandingSortlinkclick;
        public IList<IWebElement> SecurityLandingSortlinkclick
        {
            get
            {
                _securityLandingSortlinkclick = webDriver.FindElements(By.CssSelector(".k-header.k-grid-draggable-header"));
                return _securityLandingSortlinkclick;
            }
        }

       
        public IWebElement _securityDownloadLink { get { return webDriver.FindElement(By.Id("dt-download-box")); } }

        public IWebElement _securityAdvisorySearchTextBox { get { return webDriver.FindElement(By.Id("searchtxt")); } }

        public IWebElement _securityAdvisorySearchIcon { get { return webDriver.FindElement(By.Id("dt-search")); } }


        private IList<IWebElement> _securityAdvisoryGridAllPageNumbersInfo;
        public IList<IWebElement> SecurityAdvisoryGridAllPageNumbersInfo
        {
            get
            {
                _securityAdvisoryGridAllPageNumbersInfo = webDriver.FindElements(By.XPath("//*[@class='k-pager-numbers k-reset']//li"));
                return _securityAdvisoryGridAllPageNumbersInfo;
            }
        }

        public IWebElement _securityAdvisoryDescriptionLink1 { get { return webDriver.FindElement(By.XPath("//div[@class='col-xs-12']//div//li[1]//a")); } }
        public IWebElement _securityAdvisoryDescriptionLink2 { get { return webDriver.FindElement(By.XPath("//div[@class='col-xs-12']//div//li[2]//a")); } }

        public IWebElement _SignInYellowBar { get { return webDriver.FindElement(By.XPath("//*[@id='site-wrapper']/div/div[3]/div[2]/app-root/div/app-articles/div[1]/div[3]/div")); } }


        public IWebElement _SignInIconYellowBar { get { return webDriver.FindElement(By.Id("infoicon")); } }

        public IWebElement _SignInTextYellowBar { get { return webDriver.FindElement(By.XPath("//*[@id='site-wrapper']/div/div[3]/div[2]/app-root/div/app-articles/div[1]/div[3]/div/span")); } }

        public IWebElement lblDetailsPageSeverity { get { return webDriver.FindElement(By.Id("statusType")); } }

        public IWebElement lblDetailsPageTitle { get { return webDriver.FindElement(By.Id("detailTitle")); } }

        public IWebElement lblDetailsPageFirstPublishedValue { get { return webDriver.FindElement(By.Id("firstPublishedValue")); } }

        public IWebElement lblDetailsPageLastUpdatedValue { get { return webDriver.FindElement(By.Id("lastUpdatedValue")); } }

        public IWebElement detailsPageOverviewTab { get { return webDriver.FindElement(By.XPath("//*[@id='tabs']/li[1]/a")); } }

        public IWebElement detailsPageRecommendationTab { get { return webDriver.FindElement(By.XPath("//*[@id='tabs']/li[2]/a")); } }

        public IWebElement detailsPageSeverityRating { get { return webDriver.FindElement(By.Id("severity-rating")); } }

        public IWebElement lblDetailsPageSummaryContent { get { return webDriver.FindElement(By.Id("summaryContent")); } }

        public IWebElement lblDetailsPageAdvisoryDetails { get { return webDriver.FindElement(By.Id("advisorydetails")); } }

        public IWebElement CountryName { get { return webDriver.FindElement(By.XPath("//div[@class='country-name']")); } }
        public IWebElement lblDetailsPageRecommendationContent { get { return webDriver.FindElement(By.Id("resolutionsContent")); } }

        public IWebElement FooterddIcon { get { return webDriver.FindElement(By.XPath("//*[@id='countryselector']/a")); } }
        public IWebElement KbCountryName { get { return webDriver.FindElement(By.XPath("//a[contains(text(),'China')]")); } }

        public IWebElement SupportBreadcrumb { get { return webDriver.FindElement(By.XPath("//*[@id='site-wrapper']/div/div[3]/div[1]/ul/li[3]/a")); } }

        public IWebElement SecurityBreadcrumbLandingPage { get { return webDriver.FindElement(By.XPath("//*[@id='site-wrapper']/div/div[3]/div[1]/ul/li[4]/span")); } }

        public IWebElement SecurityBreadcrumbDetailsPage { get { return webDriver.FindElement(By.XPath("//*[@id='site-wrapper']/div/div[3]/div[1]/ul/li[4]/a")); } }

        public IWebElement DetailsBreadCrumb { get { return webDriver.FindElement(By.XPath("//*[@id='site-wrapper']/div/div[3]/div[1]/ul/li[5]/span")); } }

        public IList<IWebElement> Knowledgebasedivcontent { get { return webDriver.FindElements(By.XPath("//*[@id='quickresourcetopdiv']/div/a")); } }

        public IWebElement _securityLandingSignInMastheadBtn { get { return webDriver.FindElement(By.CssSelector(".mt-2.btn.btn-block.btn-primary.signin")); } }

        #endregion

    }

}

