using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TabAndTabTest.Browser.BrowserControls
{
    [TestClass]
    public class BrowserControlTest
    {
        [TestMethod]
        public void AddBrowserTest()
        {
            TabAndTab.BrowserControl tempBrowserControl = new TabAndTab.BrowserControl();
            TabAndTab.Browser tempBrowser1 = new TabAndTab.Browser(@"C:\");
            tempBrowserControl.AddBrowser(tempBrowser1);
            TabAndTab.Browser tempBrowser2 = new TabAndTab.Browser(@"C:\");
            tempBrowserControl.AddBrowser(tempBrowser2);

            int index1 = tempBrowserControl.GetIndex(tempBrowser1);
            TabAndTab.Browser browserTarget1 = tempBrowserControl.GetBrowser(0);
            int index2 = tempBrowserControl.GetIndex(tempBrowser2);
            TabAndTab.Browser browserTarget2 = tempBrowserControl.GetBrowser(1);

            Assert.AreEqual(index1, 0);
            Assert.AreEqual(tempBrowser1, browserTarget1);
            Assert.AreEqual(index2, 1);
            Assert.AreEqual(tempBrowser2, browserTarget2);
        }

        [TestMethod]
        public void PopBrowserTest()
        {
            TabAndTab.BrowserControl tempBrowserControl = new TabAndTab.BrowserControl();
            TabAndTab.Browser tempBrowser1 = new TabAndTab.Browser(@"C:\");
            tempBrowserControl.AddBrowser(tempBrowser1);
            TabAndTab.Browser tempBrowser2 = new TabAndTab.Browser(@"C:\");
            tempBrowserControl.AddBrowser(tempBrowser2);

            Assert.AreEqual(tempBrowser1, tempBrowserControl.PopBrowser(0));
            Assert.AreEqual(tempBrowser2, tempBrowserControl.PopBrowser(0));
        }

        [TestMethod]
        public void OrderChange_ShowBrowser_GetBrowser_Test()
        {
            TabAndTab.BrowserControl tempBrowserControl = new TabAndTab.BrowserControl();
            TabAndTab.Browser temp1 = new TabAndTab.Browser(@"C:\");
            tempBrowserControl.AddBrowser(temp1);
            TabAndTab.Browser temp2 = new TabAndTab.Browser(@"C:\");
            tempBrowserControl.AddBrowser(temp2);
            TabAndTab.Browser temp3 = new TabAndTab.Browser(@"C:\");
            tempBrowserControl.AddBrowser(temp3);

            tempBrowserControl.OrderChange(0, 2);
            Assert.ReferenceEquals(temp3, tempBrowserControl.GetBrowser(0));

            tempBrowserControl.ShowBrowser(1);
            Assert.ReferenceEquals(temp2, tempBrowserControl.GetNowBrowser());
        }
    }
}
