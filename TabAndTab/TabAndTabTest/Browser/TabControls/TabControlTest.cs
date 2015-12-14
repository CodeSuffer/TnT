using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TabAndTab;

namespace TabAndTabTest.Browser.TabControls
{
    [TestClass]
    public class TabControlTest
    {
        [TestMethod]
        public void GetTabTest()
        {
            TabControl temp = new TabControl();
            temp.AddNewTab(@"C:\");
            temp.AddNewTab(@"D:\");
            temp.AddNewTab(@"F:\");

            Assert.AreEqual(@"C:\", temp.GetTab(0).ButtonText);
            Assert.AreEqual(@"D:\", temp.GetTab(1).ButtonText);
            Assert.AreEqual(@"F:\", temp.GetTab(2).ButtonText);
        }

        [TestMethod]
        public void SetTabTextTest()
        {
            TabControl temp = new TabControl();
            temp.AddNewTab(@"C:\");
            temp.AddNewTab(@"D:\");
            temp.AddNewTab(@"F:\");

            temp.SetTabText(1, "TEST");
            
            Assert.AreEqual(@"TEST", temp.GetTab(1).ButtonText);
        }
    }
}
