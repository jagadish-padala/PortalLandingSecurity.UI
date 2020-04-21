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
    class Security_Landing_Details_Smoke_Workflow
    {

        #region Variables

        private readonly IWebDriver webDriver;
        
        Security_Landing_Details_Page _objSecurity_Landing_Details_Page;

        #endregion

        #region Constructor

        public Security_Landing_Details_Smoke_Workflow(IWebDriver _webDriver)
        {
            webDriver = _webDriver;
           
            _objSecurity_Landing_Details_Page = new Security_Landing_Details_Page(webDriver);
        }

        #endregion

        #region Methods

       
        public bool Verify_DisplayOfBreadCrumbsOnPage(string strBreadcrumb1, string strBreadcrumb2, string strBreadcrumb3)
        {
            bool blnResult = false;
            Thread.Sleep(3000);

            blnResult = _objSecurity_Landing_Details_Page._securityAdvisorybreadcrumbstext.Displayed;

            if (blnResult == true)
            {
                for (int i = 0; i < _objSecurity_Landing_Details_Page.securityAdvisoryBreadcrumb.Count; i++)
                {
                    if (((i == 0) || (i == 1)) && _objSecurity_Landing_Details_Page.securityAdvisoryBreadcrumb[i].Text == "")
                        blnResult = true;
                    else if (i == 2 && _objSecurity_Landing_Details_Page.securityAdvisoryBreadcrumb[i].Text.ToLower().Contains(strBreadcrumb1.ToLower()))
                        blnResult = true;
                    else if (i == 3 && _objSecurity_Landing_Details_Page.securityAdvisoryBreadcrumb[i].Text.ToLower().Contains(strBreadcrumb2.ToLower()))
                        blnResult = true;
                    else if (i == 4 && _objSecurity_Landing_Details_Page.securityAdvisoryBreadcrumb[i].Text.ToLower().Contains(strBreadcrumb3.ToLower()))
                        blnResult = true;
                    else
                        blnResult = false;


                }

            }

            return blnResult;
        }


        #endregion
    }





}
