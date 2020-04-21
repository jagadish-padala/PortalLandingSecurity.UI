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
using OpenQA.Selenium;

namespace Security_Landing_Advisory
{
    /// <summary>
    /// Summary description for Security_Landing_Advisory_Test
    /// </summary>
    [TestClass]
    [TestCategory("Security_Landing_Advisory_Test")]
    [SingleWebDriver(false)]
    public class Security_Landing_Advisory_Test : WebUIMsTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Security_Landing_Advisory_Test"/> class.
        /// </summary>
        public Security_Landing_Advisory_Test()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region variables
        IWebDriver webDriver;
        Security_Landing_Advisory_Workflow _objSecurity_Landing_Advisory_Workflow;
        public const string RepositoryName = @"\\Adepttest056.aus.amer.dell.com\AutomationSharedData\\Contents_TestData\\SecurityLandingPage\\PortalLandingSecurity.xml";
       
        //@"\\Adepttest056.aus.amer.dell.com\AutomationSharedData\\IPS_TestData\\PCFData.xml"

        #endregion

        [TestInitialize]
        public void TestInitialize()
        {
            webDriver = TestWebDriver;
            _objSecurity_Landing_Advisory_Workflow = new Security_Landing_Advisory_Workflow(TestWebDriver);

        }

        [TestCleanup]
        public void Testleanup()
        {
            //if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed)
            //    WebDriverUtility.GetBrowserScreenshot(TestWebDriver, TestContext);

            base.BaseTestCleanup();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DellWebUITest"/> class.
        /// </summary>
        /// 

        [TestMethod]
        [Owner("Jagadish_Padala")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [TestCategory("Security_Landing_Advisory_Test")]
        [Description("TC_7801156_Validate Security Landing Page: Unauthenticated view")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", RepositoryName, "TestData", DataAccessMethod.Sequential)]
        
        public void TC_7801156_Validate_Security_Landing_page_unauthenticated_view()
        {
            WebDriverUtility.NavigateUrl(webDriver, TestContext.DataRow["URL"].ToString());
            WebDriverUtility.WaitForPageToLoad(webDriver);
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
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SortTypeOnClick(), "Sorting in grid is not working as expected");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_DisplayOfGridPagination(), "Pagination is not loaded properly");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SecurityNoticesRButtonFunc(TestContext.DataRow["NoticesColumnsHeader"].ToString()), "Security Notices radio button click is not working as expected");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_DisplayColumnsInTheGrid(TestContext.DataRow["NoticesColumnsHeader"].ToString()), "Columns header is missing in grid");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SortTypeOnClick(), "Sorting in grid is not working as expected");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_DisplayOfGridPagination(), "Pagination is not loaded properly");



        }


        [TestMethod]
        [Owner("Jagadish_Padala")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [TestCategory("")]
        [Description("TC_7801238_Validate_Security_Landing_page_authenticated_view")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", RepositoryName, "TestData", DataAccessMethod.Sequential)]
        public void TC_7801238_Validate_Security_Landing_page_authenticated_view()
        {
            WebDriverUtility.NavigateUrl(webDriver, TestContext.DataRow["URL"].ToString());
            WebDriverUtility.WaitForPageToLoad(webDriver);
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
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SortTypeOnClick(), "Sorting in grid is not working as expected");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_DisplayOfGridPagination(), "Pagination is not loaded properly");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifyTitleColumnisClickable(), "All the values in title column are not hyperlink");

            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SecurityNoticesRButtonFunc(TestContext.DataRow["NoticesColumnsHeader"].ToString()), "Security Notices radio button click is not working as expected");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_DisplayColumnsInTheGrid(TestContext.DataRow["NoticesColumnsHeader"].ToString()), "Columns header is missing in grid");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SortTypeOnClick(), "Sorting in grid is not working as expected");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_DisplayOfGridPagination(), "Pagination is not loaded properly");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifyTitleColumnisClickable(), "All the values in title column are not hyperlink");

            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SecurityInformationalRButtonFunc(TestContext.DataRow["InformationColumnsHeader"].ToString()), "Security Notices radio button click is not working as expected");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_DisplayColumnsInTheGrid(TestContext.DataRow["InformationColumnsHeader"].ToString()), "Columns header is missing in grid");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SortTypeOnClick(), "Sorting in grid is not working as expected");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_DisplayOfGridPagination(), "Pagination is not loaded properly");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifyTitleColumnisClickable(), "All the values in title column are not hyperlink");

            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_Downloadbuttonfunctionality(TestContext.DataRow["SecurityAdvisoryDownloadText"].ToString(), "Advisories"), "Security Advisory download is not functioning properly");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_Downloadbuttonfunctionality(TestContext.DataRow["SecurityNoticesDownloadText"].ToString(), "Noticies"), "Security Notices download is not functioning properly");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_Downloadbuttonfunctionality(TestContext.DataRow["SecurityInformationalDownloadText"].ToString(), "Informational"), "Informational download is not functioning properly");
        }

        [TestMethod]
        [Owner("Jagadish_Padala")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [TestCategory("")]
        [Description("TC_7804272_Validate_Security_Landing_page_details_page: Unauthenticated view")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", RepositoryName, "TestData", DataAccessMethod.Sequential)]
        public void TC_7804272_Validate_Security_Landing_page_details_page()
        {
            WebDriverUtility.NavigateUrl(TestWebDriver, TestContext.DataRow["URL"].ToString());
            WebDriverUtility.WaitForPageToLoad(TestWebDriver);
            System.Threading.Thread.Sleep(10000);
            _objSecurity_Landing_Advisory_Workflow.LoginToApplication(TestContext.DataRow["EmailId"].ToString(), TestContext.DataRow["Password"].ToString());
            _objSecurity_Landing_Advisory_Workflow.gridTitleColumnClick();
            //Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateTitleClickFunctionality(), "Title click is not opening details page");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateDetailsPageOverviewTab(), "Overview tab content is not loaded properly in details page");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateDetailsPageRecommendationTab(), "Recommendation tab content is not loaded properly in details page");
            _objSecurity_Landing_Advisory_Workflow.NavigateBackToLandingPage();
            System.Threading.Thread.Sleep(5000);

            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SecurityNoticesRButtonFunc(TestContext.DataRow["NoticesColumnsHeader"].ToString()), "Security Notices radio button click is not working as expected");
            _objSecurity_Landing_Advisory_Workflow.gridTitleColumnClick();
            //Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateTitleClickFunctionality(), "Title click is not opening details page");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateDetailsPageOverviewTab(), "Overview tab content is not loaded properly in details page");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateDetailsPageRecommendationTab(), "Recommendation tab content is not loaded properly in details page");
            _objSecurity_Landing_Advisory_Workflow.NavigateBackToLandingPage();

            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SecurityInformationalRButtonFunc(TestContext.DataRow["InformationColumnsHeader"].ToString()), "Security Notices radio button click is not working as expected");
            _objSecurity_Landing_Advisory_Workflow.gridTitleColumnClick();
            //Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateTitleClickFunctionality(), "Title click is not opening details page");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateDetailsPageOverviewTab(), "Overview tab content is not loaded properly in details page");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateDetailsPageRecommendationTab(), "Recommendation tab content is not loaded properly in details page");
            _objSecurity_Landing_Advisory_Workflow.NavigateBackToLandingPage();
        }


        [TestMethod]
        [Owner("Jagadish_Padala")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [TestCategory("")]
        [Description("TC_7804358_Validate_Security_Landing_page_sort_filter")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", RepositoryName, "TestData", DataAccessMethod.Sequential)]
        public void TC_7804358_Validate_Security_Landing_page_sort_filter()
        {
            WebDriverUtility.NavigateUrl(TestWebDriver, TestContext.DataRow["URL"].ToString());
            WebDriverUtility.WaitForPageToLoad(TestWebDriver);
            System.Threading.Thread.Sleep(10000);
            _objSecurity_Landing_Advisory_Workflow.LoginToApplication(TestContext.DataRow["EmailId"].ToString(), TestContext.DataRow["Password"].ToString());
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_DisplayOfSearchBoxIcon(TestContext.DataRow["SearchBoxPlaceHolder"].ToString()), "Search text box is not loaded properly");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.SearchDataGeneral(TestContext.DataRow["SearchTextAdvisory"].ToString()), "Search is not working proplery");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SortTypeOnClick(), "Sorting of data in grid is not working as expected");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ClearSearchCriteria(), "Search text box clear functionality is not working as expected");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.SearchDataGeneral(TestContext.DataRow["SearchTextAdvisory"].ToString()), "Search is not working proplery");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_NextPaginationScenarios(), "Grid Pagination is not working");

            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SecurityNoticesRButtonFunc(TestContext.DataRow["NoticesColumnsHeader"].ToString()), "Security Notices radio button click is not working as expected");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.SearchDataGeneral(TestContext.DataRow["SearchTextNotices"].ToString()), "Search is not working proplery");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SortTypeOnClick(), "Sorting of data in grid is not working as expected");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ClearSearchCriteria(), "Search text box clear functionality is not working as expected");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.SearchDataGeneral(TestContext.DataRow["SearchTextNotices"].ToString()), "Search is not working proplery");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_NextPaginationScenarios(), "Grid Pagination is not working");

            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SecurityInformationalRButtonFunc(TestContext.DataRow["InformationColumnsHeader"].ToString()), "Security Notices radio button click is not working as expected");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.SearchDataGeneral(TestContext.DataRow["SearchTextInformation"].ToString()), "Search is not working proplery");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SortTypeOnClick(), "Sorting of data in grid is not working as expected");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ClearSearchCriteria(), "Search text box clear functionality is not working as expected");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.SearchDataGeneral(TestContext.DataRow["SearchTextInformation"].ToString()), "Search is not working proplery");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_NextPaginationScenarios(), "Grid Pagination is not working");
        }


        [TestMethod]
        [Owner("Jagadish_Padala")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [TestCategory("")]
        [Description("TC_7804405_Validate_Security_Landing_page_translation")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", RepositoryName, "TestData", DataAccessMethod.Sequential)]
        public void TC_7804405_Validate_Security_Landing_page_translation()
        {
            WebDriverUtility.NavigateUrl(TestWebDriver, TestContext.DataRow["URL"].ToString());
            WebDriverUtility.WaitForPageToLoad(TestWebDriver);
            System.Threading.Thread.Sleep(10000);
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifyCountryChange(TestContext.DataRow["CountryName"].ToString()), "");
            System.Threading.Thread.Sleep(5000);
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifyPageTitle(TestContext.DataRow["PageTitleNonUS"].ToString()), "Page title is missing");
            _objSecurity_Landing_Advisory_Workflow.ValidatePageContent(TestContext.DataRow["PageDateNonUS"].ToString(), TestContext.DataRow["PageMainHeaderNonUS"].ToString(), TestContext.DataRow["PageSubHeader1NonUS"].ToString(), TestContext.DataRow["PageSubHeader2NonUS"].ToString());
            _objSecurity_Landing_Advisory_Workflow.LoginToApplication(TestContext.DataRow["EmailId"].ToString(), TestContext.DataRow["Password"].ToString());
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifyPageTitle(TestContext.DataRow["PageTitleNonUS"].ToString()), "Page title is missing");
            _objSecurity_Landing_Advisory_Workflow.ValidatePageContent(TestContext.DataRow["PageDateNonUS"].ToString(), TestContext.DataRow["PageMainHeaderNonUS"].ToString(), TestContext.DataRow["PageSubHeader1NonUS"].ToString(), TestContext.DataRow["PageSubHeader2NonUS"].ToString());
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateTitleClickFunctionality(), "Title click is not opening details page");
            //_objSecurity_Landing_Advisory_Workflow.NavigateBackToLandingPage();

            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SecurityNoticesRButtonFunc(TestContext.DataRow["NoticesColumnsHeader"].ToString()), "Security Notices radio button click is not working as expected");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateTitleClickFunctionality(), "Title click is not opening details page");
            //_objSecurity_Landing_Advisory_Workflow.NavigateBackToLandingPage();

            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SecurityInformationalRButtonFunc(TestContext.DataRow["InformationColumnsHeader"].ToString()), "Security Notices radio button click is not working as expected");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateTitleClickFunctionality(), "Title click is not opening details page");
            //_objSecurity_Landing_Advisory_Workflow.NavigateBackToLandingPage();
        }


        [TestMethod]
        [Owner("Jagadish_Padala")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [TestCategory("")]
        [Description("TC_7804559_Validate_Security_Landing_page_differnetAccesslevel")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", RepositoryName, "TestData", DataAccessMethod.Sequential)]
        public void TC_7804559_Validate_Security_Landing_page_differnetAccesslevel()
        {
            WebDriverUtility.NavigateUrl(TestWebDriver, TestContext.DataRow["URL"].ToString());
            WebDriverUtility.WaitForPageToLoad(TestWebDriver);
            System.Threading.Thread.Sleep(10000);
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.LoginwithDifferentAccessTopSol(TestContext.DataRow["AccesslevelUserName"].ToString(), 
                TestContext.DataRow["AccesslevelPassword"].ToString(), TestContext.DataRow["AdvisoryColumnsHeader"].ToString(), TestContext.DataRow["NoticesColumnsHeader"].ToString(), TestContext.DataRow["InformationColumnsHeader"].ToString()), 
                "Differnt access level login is not working as expected");
        }

        [TestMethod]
        [Owner("Jagadish_Padala")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [TestCategory("")]
        [Description("TC_6464888_Validate_Security_Landing_page_metadata")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", RepositoryName, "TestData", DataAccessMethod.Sequential)]
        public void TC_6464888_Validate_Security_Landing_page_metadata()
        {
            WebDriverUtility.NavigateUrl(TestWebDriver, TestContext.DataRow["URL"].ToString());
            WebDriverUtility.WaitForPageToLoad(TestWebDriver);
            System.Threading.Thread.Sleep(10000);
            _objSecurity_Landing_Advisory_Workflow.LoginToApplication(TestContext.DataRow["EmailId"].ToString(), TestContext.DataRow["Password"].ToString());

            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifyMetaValue("DESCRIPTION", TestContext.DataRow["DescriptionMetaValue"].ToString()), "Meta value for key Description in landing page");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifyMetaValue("KEYWORDS", TestContext.DataRow["AdvisoryKeywordsMetaValue"].ToString()), "Meta value for key Keywords in landing page");

            _objSecurity_Landing_Advisory_Workflow.gridTitleColumnClick();
            //Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateTitleClickFunctionality(), "Title click is not opening details page");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifyMetaValue("DESCRIPTION", TestContext.DataRow["AdvisoryDetailsPageDescriptionMetaValue"].ToString()), "Meta value for key Description in details page for Advisory");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifyMetaValue("KEYWORDS", TestContext.DataRow["AdvisoryDetailsPageKeywordMetaValue"].ToString()), "Meta value for key Keywords in details page for Advisory");

            _objSecurity_Landing_Advisory_Workflow.NavigateBackToLandingPage();
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SecurityNoticesRButtonFunc(TestContext.DataRow["NoticesColumnsHeader"].ToString()), "Security Notices radio button click is not working as expected");

            _objSecurity_Landing_Advisory_Workflow.gridTitleColumnClick();
            //Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateTitleClickFunctionality(), "Title click is not opening details page");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifyMetaValue("DESCRIPTION", TestContext.DataRow["NoticesDetailsPageDescriptionMetaValue"].ToString()), "Meta value for key Description in details page for Notices");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifyMetaValue("KEYWORDS", TestContext.DataRow["NoticesDetailsPageKeywordMetaValue"].ToString()), "Meta value for key Keywords in details page for Notices");

            _objSecurity_Landing_Advisory_Workflow.NavigateBackToLandingPage();
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.Validate_SecurityInformationalRButtonFunc(TestContext.DataRow["InformationColumnsHeader"].ToString()), "Security Notices radio button click is not working as expected");
            //Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.ValidateTitleClickFunctionality(), "Title click is not opening details page");
            _objSecurity_Landing_Advisory_Workflow.gridTitleColumnClick();
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifyMetaValue("DESCRIPTION", TestContext.DataRow["InformationDetailsPageDescriptionMetaValue"].ToString()), "Meta value for key Description in details page for Informational");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifyMetaValue("KEYWORDS", TestContext.DataRow["InformationDetailsPageKeywordMetaValue"].ToString()), "Meta value for key Keywords in details page for Informational");
        }

        [TestMethod]
        [Owner("Jagadish_Padala")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [TestCategory("")]
        [Description("TC_6368089_Validate_breadcrumb")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", RepositoryName, "TestData", DataAccessMethod.Sequential)]
        public void TC_6368089_Validate_breadcrumb()
        {
            WebDriverUtility.NavigateUrl(TestWebDriver, TestContext.DataRow["URL"].ToString());
            WebDriverUtility.WaitForPageToLoad(TestWebDriver);
            System.Threading.Thread.Sleep(10000);
            _objSecurity_Landing_Advisory_Workflow.LoginToApplication(TestContext.DataRow["EmailId"].ToString(), TestContext.DataRow["Password"].ToString());
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifyLandingPageBreadcrumb(TestContext.DataRow["SupportBreadCrumb"].ToString(), TestContext.DataRow["SecurityBreadCrumb"].ToString()), "Breadcrumb is not loaded in Landing page");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifySupportBreadcrumbClick(), "Support breadcrumb is not navigating to home page");
            _objSecurity_Landing_Advisory_Workflow.NavigateBackToLandingPage();
            _objSecurity_Landing_Advisory_Workflow.gridTitleColumnClick();
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifyDetailsPageBreadcrumb(TestContext.DataRow["SupportBreadCrumb"].ToString(), TestContext.DataRow["SecurityBreadCrumb"].ToString(), TestContext.DataRow["DetailsBreadCrumb"].ToString()), "Breadcrumb is not loaded in details page");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifySupportBreadcrumbClick(), "Support breadcrumb is not navigating to home page");
            _objSecurity_Landing_Advisory_Workflow.NavigateBackToLandingPage();
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifySecurityBreadcrumbClick(TestContext.DataRow["URL"].ToString()), "Security breadcrumb is not navigating to security page");

        }

        [TestMethod]
        [Owner("Jagadish_Padala")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [TestCategory("")]
        [Description("TC_6458224_Validate_slplink_knowledgebase")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", RepositoryName, "TestData", DataAccessMethod.Sequential)]
        public void TC_6458224_Validate_slplink_knowledgebase()
        {
            WebDriverUtility.NavigateUrl(TestWebDriver, TestContext.DataRow["KnowledgebaseURL"].ToString());
            WebDriverUtility.WaitForPageToLoad(TestWebDriver);
            System.Threading.Thread.Sleep(10000);
            WebDriverUtility.ClickAcceptCookieBtn(TestWebDriver);
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.validateSecurityNoticesClick(TestContext.DataRow["KnowledgebaseSecurityURL"].ToString(), TestContext.DataRow["URL"].ToString()), "");
            Assert.IsTrue(_objSecurity_Landing_Advisory_Workflow.VerifyPageTitle(TestContext.DataRow["PageTitle"].ToString()), "Page title is missing");
            _objSecurity_Landing_Advisory_Workflow.ValidatePageContent(TestContext.DataRow["PageDate"].ToString(), TestContext.DataRow["PageMainHeader"].ToString(), TestContext.DataRow["PageSubHeader1"].ToString(), TestContext.DataRow["PageSubHeader2"].ToString());
        }
    }
}

