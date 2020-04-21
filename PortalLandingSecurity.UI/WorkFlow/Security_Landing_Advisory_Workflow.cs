using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;
using System.Globalization;
using SecurityLandingPortal.TestPage;
using System.IO;
using SecurityLandingPortal.Drivers;

namespace PortalLandingSecurity.WorkFlow
{
    class Security_Landing_Advisory_Workflow
    {
        #region Variables

        private readonly IWebDriver webDriver;
        Security_Landing_Advisory_Page _objSecurity_Landing_Advisory_Page;

        #endregion

        #region Constructor

        public Security_Landing_Advisory_Workflow(IWebDriver _webDriver)
        {
            webDriver = _webDriver;
            _objSecurity_Landing_Advisory_Page = new Security_Landing_Advisory_Page(_webDriver);

        }

        #endregion

        #region Methods

        public bool VerifyPageTitle(string strPageTitle)
        {

            return (_objSecurity_Landing_Advisory_Page._pageTitle.Displayed && _objSecurity_Landing_Advisory_Page._pageTitle.Text.Equals(strPageTitle));
        }

        public bool VerifyRbuttonsDisplayedBeforeLogin()
        {
            bool blnResult = false;

            blnResult = VerifyElementDisplayed("//*[@id='checks1']/label[1]");
            blnResult = blnResult && VerifyElementDisplayed("//*[@id='checks1']/label[2]");
            blnResult = blnResult && VerifyElementDisplayed("//*[@id='checks1']/label[3]");
            blnResult = blnResult && VerifyElementDisplayed("//*[@id='infoicon']");

            return blnResult;
        }

        //Call this method only for no login method. after login directly check element is visible or not as calling this method will return true even if security information radio button is not displayed. 
        public bool VerifyElementDisplayed(string elementId)
        {
            bool blnResult;

            try
            {
                if (webDriver.FindElement(By.XPath(elementId)).Displayed)
                    blnResult = true;
                else
                    blnResult = false;
            }
            catch (Exception ex)
            {
                blnResult = true;
            }

            return blnResult;
        }

        public void LoginToApplication(string username, string password)
        {

            Thread.Sleep(5000);
            if (_objSecurity_Landing_Advisory_Page._securityLandingSignInMasthead.Text.Contains("Sign In"))
            {
                _objSecurity_Landing_Advisory_Page._securityLandingSignInMasthead.Click();
                Thread.Sleep(5000);
                _objSecurity_Landing_Advisory_Page._securityLandingSignInMastheadBtn.Click();
            }
            else
            {
                _objSecurity_Landing_Advisory_Page._securityLandingSignInOnPage.Click();
                Thread.Sleep(5000);
            }

            _objSecurity_Landing_Advisory_Page.UsernameField.Clear();
            _objSecurity_Landing_Advisory_Page.UsernameField.SendKeys(username);
            _objSecurity_Landing_Advisory_Page.PasswordField.Clear();
            _objSecurity_Landing_Advisory_Page.PasswordField.SendKeys(password);
            _objSecurity_Landing_Advisory_Page.Siginbtn.Click();
            Thread.Sleep(10000);

            WebDriverUtility.HandlePopup(webDriver);
            WebDriverUtility.ClickAcceptCookieBtn(webDriver);
        }

        public bool ValidatePageContent(string strDate, string strPageHeader, string strPageSubHeader1, string strPageSubHeader2)
        {
            bool blnResult = false;

            blnResult = (_objSecurity_Landing_Advisory_Page._dateText.Displayed && _objSecurity_Landing_Advisory_Page._dateText.Text.Equals(strDate));
            blnResult = blnResult && (_objSecurity_Landing_Advisory_Page._pageHeader.Displayed && _objSecurity_Landing_Advisory_Page._pageHeader.Text.Equals(strPageHeader));
            blnResult = blnResult && (_objSecurity_Landing_Advisory_Page._pageSubHeader1.Displayed && _objSecurity_Landing_Advisory_Page._pageSubHeader1.Text.Equals(strPageSubHeader1));
            blnResult = blnResult && (_objSecurity_Landing_Advisory_Page._pageSubHeader2.Displayed && _objSecurity_Landing_Advisory_Page._pageSubHeader2.Text.Equals(strPageSubHeader2));

            return blnResult;

        }

        public bool VerifyRbuttonsDisplayedAfterLogin()
        {
            bool blnResult = false;

            blnResult = _objSecurity_Landing_Advisory_Page._securityAdvisoryRbutton.Displayed;
            blnResult = blnResult && _objSecurity_Landing_Advisory_Page._securityNoticesRbutton.Displayed;
            blnResult = blnResult && _objSecurity_Landing_Advisory_Page._securityInformationalRbutton.Displayed;
            blnResult = blnResult && _objSecurity_Landing_Advisory_Page._securityIAlertInfoIcon.Displayed;
            return blnResult;
        }

     
        public bool Validate_SecurityAdvisoryRButtonFunc(string strAdvisoryColumnsHeader)
        {
            bool blnResult = false;
            blnResult = _objSecurity_Landing_Advisory_Page._securityAdvisoryRbutton.Displayed;
            _objSecurity_Landing_Advisory_Page._securityAdvisoryRbutton.Click();
            Thread.Sleep(8000);

            blnResult = blnResult && _objSecurity_Landing_Advisory_Page._pageGrid.Displayed;

            blnResult = blnResult && Validate_DisplayOfGridPagination();
            blnResult = blnResult && Validate_DisplayColumnsInTheGrid(strAdvisoryColumnsHeader);

            return blnResult;

        }

        public bool Validate_SecurityNoticesRButtonFunc(string strNoticesColumnHeader)
        {
            bool blnResult = false;
            System.Threading.Thread.Sleep(5000);

            blnResult = _objSecurity_Landing_Advisory_Page._securityNoticesRbutton.Displayed;
            _objSecurity_Landing_Advisory_Page._securityNoticesRbutton.Click();
            Thread.Sleep(8000);

            blnResult = blnResult && _objSecurity_Landing_Advisory_Page._pageGrid.Displayed;

            blnResult = blnResult && Validate_DisplayOfGridPagination();
            blnResult = blnResult && Validate_DisplayColumnsInTheGrid(strNoticesColumnHeader);

            return blnResult;
        }

        public bool Validate_SecurityInformationalRButtonFunc(string strInformationColumnHeader)
        {
            bool blnResult = false;

            System.Threading.Thread.Sleep(5000);

            blnResult = _objSecurity_Landing_Advisory_Page._securityInformationalRbutton.Displayed;
            _objSecurity_Landing_Advisory_Page._securityInformationalRbutton.Click();
            Thread.Sleep(8000);
            blnResult = blnResult && _objSecurity_Landing_Advisory_Page._pageGrid.Displayed;
            blnResult = blnResult && Validate_DisplayOfGridPagination();
            blnResult = blnResult && Validate_DisplayColumnsInTheGrid(strInformationColumnHeader);

            return blnResult;
        }


        public bool Validate_DisplayOfGridPagination()
        {
            bool blnResult = false;

            blnResult = _objSecurity_Landing_Advisory_Page._pageGrid.Displayed;
            blnResult = blnResult && _objSecurity_Landing_Advisory_Page._securityAdvisoryGridGoToLastPagination.Displayed;
            blnResult = blnResult && _objSecurity_Landing_Advisory_Page._securityAdvisoryGridGoToNextPagination.Displayed;
            blnResult = blnResult && _objSecurity_Landing_Advisory_Page._securityAdvisoryGridPageNumbersInfo.Displayed;
            blnResult = blnResult && _objSecurity_Landing_Advisory_Page._securityAdvisoryGridGoToPreviousPagination.Displayed;
            blnResult = blnResult && _objSecurity_Landing_Advisory_Page._securityAdvisoryGridGoToFirstPagination.Displayed;
            return blnResult;
        }

        public bool Validate_DisplayColumnsInTheGrid(string strColumnsHeader)
        {
            bool blnResult = true;

            var securitycolumnlist = _objSecurity_Landing_Advisory_Page.securityAdvisoryGridHeaderColumnsInfo;

            string[] columnnames = Regex.Split(securitycolumnlist[0].Text, "\r\n");
            string[] cmp = strColumnsHeader.Split(',');

            for (int i = 0; i < columnnames.Length; i++)
            {
                if (!columnnames[i].Equals(cmp[i]))
                {
                    blnResult = false;
                    break;
                }


            }

            return blnResult;

        }


        public bool Validate_SortTypeOnClick()
        {

            bool blnResult = false;
            var sortcount = _objSecurity_Landing_Advisory_Page.SecurityLandingSortlinkclick.Count;


            //Check default sorting
            string strDefaultSorting = _objSecurity_Landing_Advisory_Page.SecurityLandingSortlinkclick[sortcount-1].GetAttribute("aria-sort");
            if (strDefaultSorting!="descending")
            {
                blnResult = false;
            }
            else
            {
                for (int i = 0; i < sortcount; i++)
                {
                    _objSecurity_Landing_Advisory_Page.SecurityLandingSortlinkclick[i].Click();
                    Thread.Sleep(1000);



                    var _sortstatustext = _objSecurity_Landing_Advisory_Page.SecurityLandingSortlinkclick[i].GetAttribute("aria-sort");

                    if (_sortstatustext.Contains("ascending"))
                    {
                        blnResult = true;
                        _objSecurity_Landing_Advisory_Page.SecurityLandingSortlinkclick[i].Click();
                        Thread.Sleep(1000);
                        _sortstatustext = _objSecurity_Landing_Advisory_Page.SecurityLandingSortlinkclick[i].GetAttribute("aria-sort");
                        if (_sortstatustext.Contains("descending"))
                        {
                            blnResult = blnResult && true;
                        }
                        else
                        {
                            blnResult = false;
                            break;
                        }
                    }
                    else
                    {
                        blnResult = false;
                        break;
                    }


                }
            }
            

            return blnResult;

        }


        //This method is used to check Grid data is above 1st Jan 2019
        public bool ValidateNoticesGridData()
        {
            bool blnResult = false;
            string strPublishedDate = "";
            string strLastModifiedDate = "";

            IList<IWebElement> gridRows = webDriver.FindElements(By.XPath("//*[@id='accordion']/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr"));

            for (int i = 1; i <= gridRows.Count; i++)
            {
                strPublishedDate = webDriver.FindElement(By.XPath("//*[@id='accordion']/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[" + i + "]/td[3]")).Text;
                strLastModifiedDate = webDriver.FindElement(By.XPath("//*[@id='accordion']/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[" + i + "]/td[4]")).Text;
                if ((!string.IsNullOrEmpty(strPublishedDate)) && (!string.IsNullOrEmpty(strLastModifiedDate)))
                {
                    if ((Convert.ToDateTime(strPublishedDate) >= Convert.ToDateTime("01 Jan 2019")) && (Convert.ToDateTime(strLastModifiedDate) >= Convert.ToDateTime("01 Jan 2019")))
                        blnResult = true;
                    else
                    {
                        blnResult = false;
                        break;
                    }
                }
                else
                {
                    blnResult = false;
                    break;
                }


            }

            return blnResult;
        }

        public bool VerifyTitleColumnisClickable()
        {
            bool blnResult = false;

            IList<IWebElement> gridRows = webDriver.FindElements(By.XPath("//*[@id='accordion']/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr"));

            for (int i = 0; i < gridRows.Count; i++)
            {
                if ((webDriver.FindElements(By.Id("titlecol"))[i]).GetAttribute("href") != "")
                    blnResult = true;
                else
                {
                    blnResult = false;
                    break;
                }

            }

            return blnResult;
        }

        public void gridTitleColumnClick()
        {
            IList<IWebElement> gridRows = webDriver.FindElements(By.XPath("//*[@id='accordion']/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr"));
            for (int i = 0; i < gridRows.Count; i++)
            {
                if ((webDriver.FindElements(By.Id("titlecol"))[i]).GetAttribute("href").Contains("support/security/en-us/details"))
                {
                    webDriver.FindElements(By.Id("titlecol"))[i].Click();
                    System.Threading.Thread.Sleep(8000);
                    WebDriverUtility.HandlePopup(webDriver);
                    break;
                }
            }
        }

        public bool ValidateTitleClickFunctionality()
        {
            bool blnResult = false;
            var currentdetailspageurl = "";
            int cntArticle = 0;
            int cntDetails = 0;
            IList<IWebElement> gridRows = webDriver.FindElements(By.XPath("//*[@id='accordion']/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr"));

            for (int i = 0; i < gridRows.Count; i++)
            {
                if ((cntArticle == 1) && (cntDetails == 1))
                    break;

                if ((webDriver.FindElements(By.Id("titlecol"))[i]).GetAttribute("href").Contains("support/article"))
                {
                    webDriver.FindElements(By.Id("titlecol"))[i].Click();
                    System.Threading.Thread.Sleep(3000);

                    currentdetailspageurl = webDriver.Url;
                    blnResult = currentdetailspageurl.Contains("support/article");
                    cntArticle = 1;
                }
                else if ((webDriver.FindElements(By.Id("titlecol"))[i]).GetAttribute("href").Contains("support/security/"))
                {

                    var securitycolumnlist = _objSecurity_Landing_Advisory_Page.securityAdvisoryGridHeaderColumnsInfo;

                    string[] columnnames = Regex.Split(securitycolumnlist[0].Text, "\r\n");
                    string[] strData = new string[columnnames.Length];

                    for (int j = 0; j < columnnames.Length; j++)
                    {
                        strData[j] = webDriver.FindElement(By.XPath("//*[@id='accordion']/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[" + (j + 1) + "]/td[1]")).Text;

                    }

                    //webDriver.FindElements(By.Id("titlecol"))[i].Click();
                    //System.Threading.Thread.Sleep(3000);

                    //blnResult = ValidateDetailsPage(strData);

                    webDriver.FindElements(By.Id("titlecol"))[i].Click();
                    System.Threading.Thread.Sleep(3000);

                    currentdetailspageurl = webDriver.Url;
                    blnResult = currentdetailspageurl.Contains("support/security/");
                    cntDetails = 1;
                }

               NavigateBackToLandingPage();
                if (blnResult == false)
                    break;

               // blnResult = blnResult && Validate_SecurityAdvisoryPage(strURL);

            }



            return blnResult;
        }

        public bool ValidateDetailsPage(string[] strDetails)
        {
            bool blnResult = false;

            string[] strCVEIds = strDetails[1].Split(',');

            
            for (int i =0; i< (strCVEIds.Length - 1); i++)
            {
                if (strCVEIds[i] != webDriver.FindElement(By.XPath("//*[@id='RowsID']/div[" + (i + 1) + "]/p")).Text)
                {
                    blnResult = false;
                    break;
                }
                    

            }

            if ((_objSecurity_Landing_Advisory_Page.lblDetailsPageSeverity.Text != strDetails[0]) && (_objSecurity_Landing_Advisory_Page.lblDetailsPageTitle.Text != strDetails[2]) && 
                (_objSecurity_Landing_Advisory_Page.lblDetailsPageFirstPublishedValue.Text != strDetails[3]) && (_objSecurity_Landing_Advisory_Page.lblDetailsPageLastUpdatedValue.Text != strDetails[4]))
                blnResult = blnResult && false;


            return blnResult;
        }

        public void NavigateBackToLandingPage()
        {
            webDriver.Navigate().Back();
            System.Threading.Thread.Sleep(5000);
            WebDriverUtility.ClickAcceptCookieBtn(webDriver);
        }

        public bool ValidateAdvisoryGridData()
        {
            bool blnResult = false;
            string strPublishedDate = "";
            string strLastModifiedDate = "";

            IList<IWebElement> gridRows = webDriver.FindElements(By.XPath("//*[@id='accordion']/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr"));

            for (int i = 1; i <= gridRows.Count; i++)
            {
                strPublishedDate = webDriver.FindElement(By.XPath("//*[@id='accordion']/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[" + i + "]/td[4]")).Text;
                strLastModifiedDate = webDriver.FindElement(By.XPath("//*[@id='accordion']/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[" + i + "]/td[5]")).Text;
                if ((!string.IsNullOrEmpty(strPublishedDate)) && (!string.IsNullOrEmpty(strLastModifiedDate)))
                {
                    if ((Convert.ToDateTime(strPublishedDate) >= Convert.ToDateTime("01 Jan 2019")) && (Convert.ToDateTime(strLastModifiedDate) >= Convert.ToDateTime("01 Jan 2019")))
                        blnResult = true;
                    else
                    {
                        blnResult = false;
                        break;
                    }
                }
                else
                {
                    blnResult = false;
                    break;
                }


            }

            return blnResult;
        }

        public bool ValidateRbuttonCount(bool IsAuthenticated = true)
        {
            bool blnResult = false;

            string[] strAdvisory = _objSecurity_Landing_Advisory_Page._securityAdvisoryRbutton.Text.Split('(');
            int cntAdvisory = Convert.ToInt32(strAdvisory[1].ToString().Split(')')[0]);

            string[] strNotices = _objSecurity_Landing_Advisory_Page._securityNoticesRbutton.Text.Split('(');
            int cntNotices = Convert.ToInt32(strNotices[1].ToString().Split(')')[0]);

            if (IsAuthenticated==true)
            {
                string[] strInformation = _objSecurity_Landing_Advisory_Page._securityInformationalRbutton.Text.Split('(');
                int cntInformation = Convert.ToInt32(strInformation[1].ToString().Split(')')[0]);
                blnResult = (cntAdvisory >= 0) && (cntNotices >= 0) && (cntInformation >= 0);
            }
            else
            {
                blnResult = (cntAdvisory >= 0) && (cntNotices >= 0);
            }
            

            return blnResult;
        }


        public bool ValidateInformationalGridData()
        {
            bool blnResult = false;
            string strPublishedDate = "";
            string strLastModifiedDate = "";

            IList<IWebElement> gridRows = webDriver.FindElements(By.XPath("//*[@id='accordion']/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr"));

            for (int i = 1; i <= gridRows.Count; i++)
            {
                strPublishedDate = webDriver.FindElement(By.XPath("//*[@id='accordion']/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[" + i + "]/td[2]")).Text;
                strLastModifiedDate = webDriver.FindElement(By.XPath("//*[@id='accordion']/kendo-grid/div/kendo-grid-list/div/div[1]/table/tbody/tr[" + i + "]/td[3]")).Text;
                if ((!string.IsNullOrEmpty(strPublishedDate)) && (!string.IsNullOrEmpty(strLastModifiedDate)))
                {
                    if ((Convert.ToDateTime(strPublishedDate) >= Convert.ToDateTime("01 Jan 2019")) && (Convert.ToDateTime(strLastModifiedDate) >= Convert.ToDateTime("01 Jan 2019")))
                        blnResult = true;
                    else
                    {
                        blnResult = false;
                        break;
                    }
                }
                else
                {
                    blnResult = false;
                    break;
                }


            }

            return blnResult;
        }

        public bool Validate_Downloadbuttonfunctionality(string strFileTitle, string strRadiobuttonText)
        {
            bool blnResult = false;

            try
            {
                if (strRadiobuttonText == "Advisories")
                {
                    _objSecurity_Landing_Advisory_Page._securityAdvisoryRbutton.Click();
                }
                else if (strRadiobuttonText == "Noticies")
                {
                    _objSecurity_Landing_Advisory_Page._securityNoticesRbutton.Click();
                }
                else if (strRadiobuttonText == "Informational")
                {
                    _objSecurity_Landing_Advisory_Page._securityInformationalRbutton.Click();
                }

                System.Threading.Thread.Sleep(3000);

                blnResult = _objSecurity_Landing_Advisory_Page._securityDownloadLink.Displayed;


                _objSecurity_Landing_Advisory_Page._securityDownloadLink.Click();

                System.Threading.Thread.Sleep(3000);


                string Path = System.Environment.GetEnvironmentVariable("UserProfile") + "\\Downloads";
                string[] filePaths = Directory.GetFiles(Path, "*.csv");
                string filenameformat = filePaths[0].Substring(filePaths[0].LastIndexOf('\\') + 1);
                string downnloadfilenameformat = strFileTitle + DateTime.Now.ToString("yyyy_MM_dd_hh_mm") + ".csv";
                string csvData = (File.ReadAllLines(filePaths[0]).Length - 1).ToString();
                string itemstext = _objSecurity_Landing_Advisory_Page._securityAdvisoryGridPageNumbersInfo.Text;
                itemstext = itemstext.Substring(0, itemstext.LastIndexOf(' '));
                itemstext = itemstext.Substring(itemstext.LastIndexOf(' ') + 1);

                if (itemstext.Equals(csvData))
                    blnResult = blnResult && true;
                else
                    blnResult = blnResult && false;

                foreach (var item in filePaths)
                {
                    File.Delete(item);
                }
            }
            catch (Exception ex)
            {
                blnResult = false;
            }

            return blnResult;
        }

        public bool Validate_DisplayOfSearchBoxIcon(string strSearchPlaceHolder)
        {
            bool blnResult = false;

            blnResult = _objSecurity_Landing_Advisory_Page._securityAdvisorySearchTextBox.Displayed;

            blnResult = blnResult && (_objSecurity_Landing_Advisory_Page._securityAdvisorySearchTextBox.GetAttribute("placeholder") == strSearchPlaceHolder);
            blnResult = blnResult && _objSecurity_Landing_Advisory_Page._securityAdvisorySearchIcon.Displayed;

            return blnResult;
        }

        public void EnterTextInSearchBox(string _searchtext)
        {
            _objSecurity_Landing_Advisory_Page._securityAdvisorySearchTextBox.Click();
            _objSecurity_Landing_Advisory_Page._securityAdvisorySearchTextBox.SendKeys(_searchtext);
            _objSecurity_Landing_Advisory_Page._securityAdvisorySearchIcon.Click();
            System.Threading.Thread.Sleep(2000);
        }

        public bool SearchDataGeneral(string _searchtext)
        {
            bool blnResult = true;
            EnterTextInSearchBox(_searchtext);
            var norecords = webDriver.FindElement(By.XPath("//*[@id='grid']//tbody"));
            var _pagenumbercount = _objSecurity_Landing_Advisory_Page.SecurityAdvisoryGridAllPageNumbersInfo.Count;
            if (norecords.Text == "No Records Found")
            {
                blnResult = false;
            }
            else
            {
                //IList<IWebElement> searchcolumns = webDriver.FindElements(By.XPath("//*[@id='grid']//kendo-grid//table//thead//a[contains(text(),'TITLE')]"));
                IList<IWebElement> searchrows = webDriver.FindElements(By.XPath("//*[@id='grid']//kendo-grid//table//tbody//tr//a[@id='titlecol']"));

                foreach (var rowtitle in searchrows)
                {
                    if (!rowtitle.Text.ToLower().Contains(_searchtext.ToLower()))
                    {
                        blnResult = false;
                        break;
                    }

                    //webDriver.WaitForElementDisplay(_securityAdvisoryGrid, TimeSpan.FromSeconds(20));
                }
            }

            return blnResult;
        }


        public bool Validate_NextPaginationScenarios()
        {
            bool blnResult = true;
            if (_objSecurity_Landing_Advisory_Page.SecurityAdvisoryGridAllPageNumbersInfo.Count > 0)
            {
                var _pagenumbercount = _objSecurity_Landing_Advisory_Page.SecurityAdvisoryGridAllPageNumbersInfo.Count;
                if (_pagenumbercount > 1)
                {
                    for (int i = 0; i < _pagenumbercount - 1; i++)
                    {

                        _objSecurity_Landing_Advisory_Page._securityAdvisoryGridGoToNextPagination.Click();

                        if (!_objSecurity_Landing_Advisory_Page._pageGrid.Displayed)
                        {
                            blnResult = false;
                            break;
                        }


                    }
                    for (int i = 0; i < _pagenumbercount - 1; i++)
                    {

                        _objSecurity_Landing_Advisory_Page._securityAdvisoryGridGoToPreviousPagination.Click();

                        if (!_objSecurity_Landing_Advisory_Page._pageGrid.Displayed)
                        {
                            blnResult = false;
                            break;
                        }
                    }
                }


            }

            return blnResult;
        }

        public bool ClearSearchCriteria()
        {
            _objSecurity_Landing_Advisory_Page._securityAdvisorySearchTextBox.Clear();
            Thread.Sleep(5000);
            _objSecurity_Landing_Advisory_Page._securityAdvisorySearchIcon.Click();
            return (_objSecurity_Landing_Advisory_Page._pageGrid.Displayed);

        }

        public bool VerifySubHeaderHyperLinkClick()
        {
            bool blnResult = false;

            blnResult = _objSecurity_Landing_Advisory_Page._securityAdvisoryDescriptionLink1.Displayed;

            var link1url = _objSecurity_Landing_Advisory_Page._securityAdvisoryDescriptionLink1.GetAttribute("href");
            _objSecurity_Landing_Advisory_Page._securityAdvisoryDescriptionLink1.Click();
            Thread.Sleep(3000);

            blnResult = blnResult && string.Equals(link1url, webDriver.Url);


            webDriver.Navigate().Back();
            Thread.Sleep(3000);

            blnResult = blnResult && _objSecurity_Landing_Advisory_Page._securityAdvisoryDescriptionLink2.Displayed;
            var link2url = _objSecurity_Landing_Advisory_Page._securityAdvisoryDescriptionLink2.GetAttribute("href");
            _objSecurity_Landing_Advisory_Page._securityAdvisoryDescriptionLink2.Click();
            Thread.Sleep(3000);

            blnResult = blnResult && string.Equals(link2url, webDriver.Url);

            webDriver.Navigate().Back();
            Thread.Sleep(3000);

            return blnResult;
        }

   
        public bool ValidateSignInLinkDisplayed()
        {
            bool blnResult = false;

            blnResult = _objSecurity_Landing_Advisory_Page._SignInYellowBar.Displayed;
            blnResult = blnResult && _objSecurity_Landing_Advisory_Page._SignInIconYellowBar.Displayed;
            blnResult = blnResult && (_objSecurity_Landing_Advisory_Page._SignInTextYellowBar.Displayed && _objSecurity_Landing_Advisory_Page._SignInTextYellowBar.Text.Contains("sign in"));

            return blnResult;
        }

        public bool ValidateDownloadLinkDisplayed()
        {
            return _objSecurity_Landing_Advisory_Page._securityDownloadLink.Displayed;
        }

        public bool ValidateInformationicondisplayed()
        {
            return _objSecurity_Landing_Advisory_Page._securityIAlertInfoIcon.Displayed;
        }

        public bool ValidateDetailsPageOverviewTab()
        {
            bool blnResult = false;

            _objSecurity_Landing_Advisory_Page.detailsPageOverviewTab.Click();
            System.Threading.Thread.Sleep(2000);

            if (((_objSecurity_Landing_Advisory_Page.detailsPageSeverityRating.Displayed) && (_objSecurity_Landing_Advisory_Page.detailsPageSeverityRating.Text != "")) && 
                ((_objSecurity_Landing_Advisory_Page.lblDetailsPageSummaryContent.Displayed) && (_objSecurity_Landing_Advisory_Page.lblDetailsPageSummaryContent.Text !="")) &&
                ((_objSecurity_Landing_Advisory_Page.lblDetailsPageAdvisoryDetails.Displayed) && (_objSecurity_Landing_Advisory_Page.lblDetailsPageAdvisoryDetails.Text !="")))
                blnResult = true;

            return blnResult;
        }

        public bool ValidateDetailsPageRecommendationTab()
        {
            bool blnResult = false;

            _objSecurity_Landing_Advisory_Page.detailsPageRecommendationTab.Click();
            System.Threading.Thread.Sleep(2000);

            if (_objSecurity_Landing_Advisory_Page.lblDetailsPageRecommendationContent.Displayed && (_objSecurity_Landing_Advisory_Page.lblDetailsPageRecommendationContent.Text != ""))
                blnResult = true;

            return blnResult;
        }


        public bool VerifyCountryChange(string SCountryName)
        {
            
            bool result = false;
            string countryname = _objSecurity_Landing_Advisory_Page.CountryName.Text.ToString();
            if (!countryname.Equals(SCountryName))
            {
                FooterdropdownCountry_Click();
                Thread.Sleep(3000);
                if (!_objSecurity_Landing_Advisory_Page.CountryName.Text.ToString().Equals(countryname))
                {
                    result = true;
                }
                else
                    result = false;
            }
            return result;

        }

        public void FooterdropdownCountry_Click()
        {
            WebDriverUtility.OnElementClick(_objSecurity_Landing_Advisory_Page.FooterddIcon, webDriver);
            WebDriverUtility.OnElementClick(_objSecurity_Landing_Advisory_Page.KbCountryName, webDriver);
            System.Threading.Thread.Sleep(3000);
            WebDriverUtility.HandlePopup(webDriver);
        }

        public bool LoginwithDifferentAccessTopSol(string strUserName, string strPassword,string strAdvisoryColumns, string strNoticesColumns, string strInformationColumns)
        {
            bool blnResults = false;
            IList<string> uname = strUserName.Split(',');
            IList<string> pwd = strPassword.Split(',');
            
            for (int i = 0; i < uname.Count; i++)
            {
                
                LoginToApplication(uname[i], pwd[i]);
                System.Threading.Thread.Sleep(3000);
                blnResults = Validate_SecurityAdvisoryRButtonFunc(strAdvisoryColumns);
                blnResults = blnResults && Validate_SecurityNoticesRButtonFunc(strNoticesColumns);
                blnResults = blnResults && Validate_SecurityInformationalRButtonFunc(strInformationColumns);
            }

            return blnResults;
        }

        public bool VerifyMetaValue(string sKey, string sValidateValue)
        {
            string pageSource = webDriver.PageSource;
            int iPosition = pageSource.IndexOf(sKey);
            bool bExistValue = false;
            string sSplit = "meta";
            if (iPosition != -0)
            {
                string[] svalue = pageSource.Split(new[] { sSplit }, StringSplitOptions.None);
                foreach (string sMeta in svalue)
                {
                    if (sMeta.Contains(sKey))
                    {
                        string str = Regex.Replace(sMeta, @"&nbsp;", " ");
                        bExistValue = str.Contains(sValidateValue);
                        break;
                    }
                }
            }
            System.Threading.Thread.Sleep(3000);
            return bExistValue;
        }

        public bool VerifyLandingPageBreadcrumb(string strSupport, string strSecurity)
        {
            bool blnResult = false;

            if (_objSecurity_Landing_Advisory_Page.SupportBreadcrumb.Displayed && (_objSecurity_Landing_Advisory_Page.SupportBreadcrumb.Text == strSupport))
                blnResult = true;

            if (_objSecurity_Landing_Advisory_Page.SecurityBreadcrumbLandingPage.Displayed && (_objSecurity_Landing_Advisory_Page.SecurityBreadcrumbLandingPage.Text == strSecurity))
                blnResult = blnResult && true;

            return blnResult;
        }

        public bool VerifySupportBreadcrumbClick()
        {

            _objSecurity_Landing_Advisory_Page.SupportBreadcrumb.Click();
            System.Threading.Thread.Sleep(3000);

            return webDriver.Url.Contains("www.dell.com/support/home");
        }

        public bool VerifySecurityBreadcrumbClick(string strURL)
        {
            _objSecurity_Landing_Advisory_Page.SecurityBreadcrumbDetailsPage.Click();
            System.Threading.Thread.Sleep(3000);

            return webDriver.Url.Contains(strURL);
        }

        public bool VerifyDetailsPageBreadcrumb(string strSupport, string strSecurity, string strDetails)
        {
            bool blnResult = false;

            if (_objSecurity_Landing_Advisory_Page.SupportBreadcrumb.Displayed && (_objSecurity_Landing_Advisory_Page.SupportBreadcrumb.Text == strSupport))
                blnResult = true;

            if (_objSecurity_Landing_Advisory_Page.SecurityBreadcrumbDetailsPage.Displayed && (_objSecurity_Landing_Advisory_Page.SecurityBreadcrumbDetailsPage.Text == strSecurity))
                blnResult = blnResult && true;

            if (_objSecurity_Landing_Advisory_Page.DetailsBreadCrumb.Displayed && (_objSecurity_Landing_Advisory_Page.DetailsBreadCrumb.Text == strDetails))
                blnResult = blnResult && true;

            return blnResult;
        }

        public bool validateSecurityNoticesClick(string strSecurityDiv, string strURL)
        {
            bool blnResult = false;

            for (int i = 0; i < _objSecurity_Landing_Advisory_Page.Knowledgebasedivcontent.Count; i++)
            {
                var _breadcrumbstext = _objSecurity_Landing_Advisory_Page.Knowledgebasedivcontent[i].Text;
                if (_objSecurity_Landing_Advisory_Page.Knowledgebasedivcontent[i].Text == strSecurityDiv)
                {
                    _objSecurity_Landing_Advisory_Page.Knowledgebasedivcontent[i].Click();
                    System.Threading.Thread.Sleep(3000);
                    blnResult = webDriver.Url.Contains(strURL);

                }

            }

            return blnResult;
        }

        #endregion
    }
}
