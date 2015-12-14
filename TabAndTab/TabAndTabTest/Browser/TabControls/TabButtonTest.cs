using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TabAndTab;

namespace TabAndTabTest.Browser.TabControls
{
    [TestClass]
    public class TabButtonTest
    {
        [TestMethod]
        public void TabButton_Init()
        {
            TabButton temp = new TabButton("test");
            Assert.AreEqual("test", temp.ButtonText);
        }
    }
}
