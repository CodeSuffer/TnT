using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TabAndTabTest.Browser.BrowserControls
{
    /// <summary>
    /// BrowserTest의 요약 설명
    /// </summary>
    [TestClass]
    public class BrowserTest
    {
        public BrowserTest()
        {
            //
            // TODO: 여기에 생성자 논리를 추가합니다.
            //
        }

        [TestMethod]
        public void Browser_Init_Test()
        {
            TabAndTab.Browser testBrowser = new TabAndTab.Browser(@"C:\");

            Assert.AreEqual(@"C:\", testBrowser.Address);
        }

        [TestMethod]
        public void Address_Changing_Test1()
        {
            TabAndTab.Browser testBrowser = new TabAndTab.Browser("TEST");

            Assert.AreEqual("Wrong Page", testBrowser.Address);
        }

        [TestMethod]
        public void Address_Changing_Test2()
        {
            TabAndTab.Browser testBrowser = new TabAndTab.Browser(@"C:\");

            testBrowser.AddressChanging(@"C:\Program files");
            Assert.AreEqual(@"C:\Program files", testBrowser.Address);
        }
        
        [TestMethod]
        public void GoForward_Test()
        {
            TabAndTab.Browser testBrowser = new TabAndTab.Browser(@"C:\");

            testBrowser.AddressChanging(@"C:\Program files");
            testBrowser.AddressChanging(@"C:\Windows");
            testBrowser.GoBack();
            testBrowser.GoForward();

            Assert.AreEqual(@"C:\Windows", testBrowser.Address);
        }
    }
}
