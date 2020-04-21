// ***********************************************************************
// Author           : AMERICAS\Chandudhar_S_B
// Created          : 3/15/2019 12:35:09 PM
//
// Last Modified By : AMERICAS\Chandudhar_S_B
// Last Modified On : 3/15/2019 12:35:09 PM
// ***********************************************************************
// <copyright file="Security_Landing_Advisory_Test.cs" company="Dell">
//     Copyright (c) Dell 2019. All rights reserved.
// </copyright>
// <summary>Describe what is being tested in this test class here.</summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Dell.Adept.UI.Web.Testing.Framework;
using Dell.Adept.UI.Web.Testing.Framework.WebDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using SecurityLandingPortal.Drivers;
using SecurityLandingPortal.TestPage;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using PortalLandingSecurity.WorkFlow;

namespace Security_Landing_Details
{
    /// <summary>
    /// Summary description for Security_Landing_Advisory_Test
    /// </summary>
    [TestClass]
    [TestCategory("Security_Landing_Advisory_Test")]
    [SingleWebDriver(false)]
    public class Security_Landing_Details_Test : WebUIMsTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Security_Landing_Advisory_Test"/> class.
        /// </summary>
        public Security_Landing_Details_Test()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region variables
        Security_Landing_Advisory_Workflow _objSecurity_Landing_Advisory_Workflow;
        Security_Landing_Details_Smoke_Workflow _objSecurity_Landing_Details_Smoke_Workflow;
        public const string RepositoryName = @"\\Adepttest056.aus.amer.dell.com\AutomationSharedData\\Contents_TestData\\SecurityLandingPage\\PortalLandingSecurity.xml";
        //\\Adepttest056.aus.amer.dell.com\AutomationSharedData\\IPS_TestData\\PCFData.xml
        #endregion


        //SQLUtility sqlFunc = null;

        [TestInitialize]
        public void TestInitialize()
        {
           
            _objSecurity_Landing_Advisory_Workflow = new Security_Landing_Advisory_Workflow(TestWebDriver);
            _objSecurity_Landing_Details_Smoke_Workflow = new Security_Landing_Details_Smoke_Workflow(TestWebDriver);
           
        }

        //[TestCleanup]
        //public void Testleanup()
        //{
        //    if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed)
        //        WebDriverUtility.GetBrowserScreenshot(TestWebDriver, TestContext);

        //    base.BaseTestCleanup();
        //}
        /// <summary>
        /// Initializes a new instance of the <see cref="DellWebUITest"/> class.
        /// </summary>
        /// 


        [TestMethod]
        [Owner("Jagadish_Padala")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [TestCategory("")]
        [Description("TC_6462373_Security_Landing_Smoke_Test_Scripts_Test_WithOutLogin")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", RepositoryName, "TestData", DataAccessMethod.Sequential)]
        public void TC_6462373_Security_Landing_Smoke_Test_Scripts_Test_WithOutLogin()
        {
            WebDriverUtility.NavigateUrl(TestWebDriver, TestContext.DataRow["URL"].ToString());
            WebDriverUtility.WaitForPageToLoad(TestWebDriver);
            System.Threading.Thread.Sleep(10000);
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifyPageTitle(TestContext.DataRow["PageTitle"].ToString()), "Page title is missing");
            _objSecurity_Landing_Advisory_Workflow.ValidatePageContent(TestContext.DataRow["PageDate"].ToString(), TestContext.DataRow["PageMainHeader"].ToString(), TestContext.DataRow["PageSubHeader1"].ToString(), TestContext.DataRow["PageSubHeader2"].ToString());
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifySubHeaderHyperLinkClick(), "Hyper link click in sub header is not working as expected.");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_DisplayOfSearchBoxIcon(TestContext.DataRow["SearchBoxPlaceHolder"].ToString()), "Search text box is not loaded properly");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateSignInLinkDisplayed(), "Sign in link is missing in yellow bar above grid");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateDownloadLinkDisplayed(), "Download link is missing");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateInformationicondisplayed(), "Information icon is missing above grid");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifyRbuttonsDisplayedBeforeLogin(), "Radio buttons are not loaded as expected before login");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateRbuttonCount(false), "Radio buttons total count is missing");

            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SecurityAdvisoryRButtonFunc(TestContext.DataRow["AdvisoryColumnsHeader"].ToString()), "Security Advisory radio button click is not working as expected");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_DisplayColumnsInTheGrid(TestContext.DataRow["AdvisoryColumnsHeader"].ToString()), "Columns header is missing in grid");

            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SecurityNoticesRButtonFunc(TestContext.DataRow["NoticesColumnsHeader"].ToString()), "Security Notices radio button click is not working as expected");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_DisplayColumnsInTheGrid(TestContext.DataRow["NoticesColumnsHeader"].ToString()), "Columns header is missing in grid");
        }

        [TestMethod]
        [Owner("Jagadish_Padala")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [TestCategory("")]
        [Description("TC_6462382_Validate_Security_Landing_page_authenticated_view")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", RepositoryName, "TestData", DataAccessMethod.Sequential)]
        public void TC_6462382_Validate_Security_Landing_page_authenticated_view()
        {
            WebDriverUtility.NavigateUrl(TestWebDriver, TestContext.DataRow["URL"].ToString());
            WebDriverUtility.WaitForPageToLoad(TestWebDriver);
            System.Threading.Thread.Sleep(10000);
            _objSecurity_Landing_Advisory_Workflow.LoginToApplication(TestContext.DataRow["EmailId"].ToString(), TestContext.DataRow["Password"].ToString());
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifyPageTitle(TestContext.DataRow["PageTitle"].ToString()), "Page title is missing");
            _objSecurity_Landing_Advisory_Workflow.ValidatePageContent(TestContext.DataRow["PageDate"].ToString(), TestContext.DataRow["PageMainHeader"].ToString(), TestContext.DataRow["PageSubHeader1"].ToString(), TestContext.DataRow["PageSubHeader2"].ToString());
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifySubHeaderHyperLinkClick(), "Hyper link click in sub header is not working as expected.");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_DisplayOfSearchBoxIcon(TestContext.DataRow["SearchBoxPlaceHolder"].ToString()), "Search text box is not loaded properly");
            //Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateSignInLinkDisplayed(), "Sign in link is missing in yellow bar above grid");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateDownloadLinkDisplayed(), "Download link is missing");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateInformationicondisplayed(), "Information icon is missing above grid");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifyRbuttonsDisplayedAfterLogin(), "Radio buttons are not loaded as expected after login");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateRbuttonCount(true), "Radio buttons total count is missing");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SecurityAdvisoryRButtonFunc(TestContext.DataRow["AdvisoryColumnsHeader"].ToString()), "Security Advisory radio button click is not working as expected");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_DisplayColumnsInTheGrid(TestContext.DataRow["AdvisoryColumnsHeader"].ToString()), "Columns header is missing in grid");

            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SecurityNoticesRButtonFunc(TestContext.DataRow["NoticesColumnsHeader"].ToString()), "Security Notices radio button click is not working as expected");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_DisplayColumnsInTheGrid(TestContext.DataRow["NoticesColumnsHeader"].ToString()), "Columns header is missing in grid");

            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SecurityInformationalRButtonFunc(TestContext.DataRow["InformationColumnsHeader"].ToString()), "Security Notices radio button click is not working as expected");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_DisplayColumnsInTheGrid(TestContext.DataRow["InformationColumnsHeader"].ToString()), "Columns header is missing in grid");

        }


        [TestMethod]
        [Owner("Chandudhar_S_B")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [TestCategory("Smoke_Details_Page")]
        [Description("TC_6462545_Dell_SecurityLanding_Details_Advisory_Option_Smoke_Test")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", RepositoryName, "TestData", DataAccessMethod.Sequential)]
        public void TC_6462545_Dell_SecurityLanding_Details_Advisory_Option_Smoke_Test()
        {
           
            WebDriverUtility.NavigateUrl(TestWebDriver, TestContext.DataRow["URL"].ToString());
            WebDriverUtility.WaitForPageToLoad(TestWebDriver);
            System.Threading.Thread.Sleep(10000);
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SecurityAdvisoryRButtonFunc(TestContext.DataRow["AdvisoryColumnsHeader"].ToString()), "Security Advisory radio button click is not working as expected");
            _objSecurity_Landing_Advisory_Workflow.gridTitleColumnClick();
            //Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateTitleClickFunctionality(), "Title click is not opening details page");
            Assert.IsTrue(_objSecurity_Landing_Details_Smoke_Workflow.Verify_DisplayOfBreadCrumbsOnPage(TestContext.DataRow["SupportBreadCrumb"].ToString(), TestContext.DataRow["SecurityBreadCrumb"].ToString(), TestContext.DataRow["DetailsBreadCrumb"].ToString()), "Breadcrumb is not loaded properly");

            
        }

        [TestMethod]
        [Owner("Chandudhar_S_B")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [TestCategory("Smoke_Details_Page")]
        [Description("TC_6474452_Dell_SecurityLanding_Details_Notices_Option_Smoke_Test")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", RepositoryName, "TestData", DataAccessMethod.Sequential)]
        public void TC_6474452_Dell_SecurityLanding_Details_Notices_Option_Smoke_Test()
        {
            WebDriverUtility.NavigateUrl(TestWebDriver, TestContext.DataRow["URL"].ToString());
            WebDriverUtility.WaitForPageToLoad(TestWebDriver);
            System.Threading.Thread.Sleep(10000);
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SecurityNoticesRButtonFunc(TestContext.DataRow["NoticesColumnsHeader"].ToString()), "Security Notices radio button click is not working as expected");
            //Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateTitleClickFunctionality(), "Title click is not opening details page");
            _objSecurity_Landing_Advisory_Workflow.gridTitleColumnClick();
            Assert.IsTrue(_objSecurity_Landing_Details_Smoke_Workflow.Verify_DisplayOfBreadCrumbsOnPage(TestContext.DataRow["SupportBreadCrumb"].ToString(), TestContext.DataRow["SecurityBreadCrumb"].ToString(), TestContext.DataRow["DetailsBreadCrumb"].ToString()), "Breadcrumb is not loaded properly");
        }


      
        [TestMethod]
        [Owner("Chandudhar_S_B")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [TestCategory("TC_6474456_Dell_SecurityLanding_Details_Informational_Option_Smoke_Test")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", RepositoryName, "TestData", DataAccessMethod.Sequential)]
        public void TC_6474456_Dell_SecurityLanding_Details_Informational_Option_Smoke_Test()
        {
            WebDriverUtility.NavigateUrl(TestWebDriver, TestContext.DataRow["URL"].ToString());
            WebDriverUtility.WaitForPageToLoad(TestWebDriver);
            System.Threading.Thread.Sleep(10000);
            _objSecurity_Landing_Advisory_Workflow.LoginToApplication(TestContext.DataRow["EmailId"].ToString(), TestContext.DataRow["Password"].ToString());
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SecurityInformationalRButtonFunc(TestContext.DataRow["InformationColumnsHeader"].ToString()), "Security Notices radio button click is not working as expected");
            //Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateTitleClickFunctionality(), "Title click is not opening details page");
            _objSecurity_Landing_Advisory_Workflow.gridTitleColumnClick();
            Assert.IsTrue(_objSecurity_Landing_Details_Smoke_Workflow.Verify_DisplayOfBreadCrumbsOnPage(TestContext.DataRow["SupportBreadCrumb"].ToString(), TestContext.DataRow["SecurityBreadCrumb"].ToString(), TestContext.DataRow["DetailsBreadCrumb"].ToString()), "Breadcrumb is not loaded properly");
        }
    }
}

