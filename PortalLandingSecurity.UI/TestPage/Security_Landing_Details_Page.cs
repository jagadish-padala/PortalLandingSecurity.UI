// ***********************************************************************
// Author           : AMERICAS\Chandudhar_S_B
// Created          : 3/15/2019 12:33:32 PM
//
// Last Modified By : AMERICAS\Chandudhar_S_B
// Last Modified On : 3/15/2019 12:33:32 PM
// ***********************************************************************
// <copyright file="Security_Landing_Details_Page.cs" company="Dell">
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

namespace SecurityLandingPortal.TestPage
{
    /// <summary>
    /// This base class is the where all specific page classes will be derived.
    /// </summary>
    public class Security_Landing_Details_Page : PageBase

    {
        IWebDriver webDriver;

        /// <summary>
        /// Constructor to hand off webDriver
        /// </summary>
        /// <param name="webDriver"></param>
        public Security_Landing_Details_Page(IWebDriver webDriver) : base(ref webDriver)
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
        public IWebElement _securityAdvisorybreadcrumbstext { get { return webDriver.FindElement(By.CssSelector(".breadcrumb.hidden-xs")); } }

        private IList<IWebElement> _securityAdvisoryBreadcrumb;
        public IList<IWebElement> securityAdvisoryBreadcrumb
        {
            get
            {
                _securityAdvisoryBreadcrumb = webDriver.FindElements(By.XPath("//ul[@class='breadcrumb hidden-xs']//li"));
                return _securityAdvisoryBreadcrumb;
            }
        }


    }
}
