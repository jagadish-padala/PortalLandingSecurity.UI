// ***********************************************************************
// Author           : AMERICAS\Jagadish_Padala
// Created          : 4/21/2020 11:07:48 PM
//
// Last Modified By : AMERICAS\Jagadish_Padala
// Last Modified On : 4/21/2020 11:07:48 PM
// ***********************************************************************
// <copyright file="AdeptWebUITest.cs" company="Dell">
//     Copyright (c) Dell 2020. All rights reserved.
// </copyright>
// <summary>Describe what is being tested in this test class here.</summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Dell.Adept.UI.Web.Testing.Framework;
using Dell.Adept.UI.Web.Testing.Framework.WebDriver;
using Dell.Adept.Testing.DataGenerators.Primitive;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PortalLandingSecurity.UI
{

    [TestClass]
    [TestCategory("AdeptWebUITest")]
    [SingleWebDriver(false)]
    public class AdeptWebUITest : WebUIMsTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdeptWebUITest"/> class.
        /// </summary>
        public AdeptWebUITest()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        [TestMethod]
        [Owner("Jagadish_Padala")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(2)]
        [TestCategory("")]
        [Description("Describe the Test case here.")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML","|DataDirectory|\\TestDataSource.xml","TestData", DataAccessMethod.Sequential)] 
        //[DeploymentItem(@"FromSolutionFolderName\TestDataSource.xml", "OutputFolderName")]
        public void AdeptWebUITest_Test()
        {
            //
            // TODO: Add test logic here
            //
        }

    }
}

