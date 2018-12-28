﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using BLL;
using System;

namespace UnitTest
{
    [TestClass]
    public class TestArea
    {
        private AreaBLL areaBLL = new AreaBLL();

        [TestMethod]
        public void TestCRUDArea()
        {
            string nameExpected = "BanVIP";
            Area area = areaBLL.CreateArea(nameExpected);
            Assert.AreEqual(nameExpected, area.Name);
            TestUpdateArea(area);
        }
        public void TestUpdateArea(Area area)
        {
            string nameTest = "BanThuong";
            area.Name = nameTest;
            areaBLL.Update(area);
            List<Area> areas = areaBLL.ListArea();
            string nameExpected= "";
            for (int i=0; i < areas.Count; i++)
            {
                if (areas[i].ID == area.ID) nameExpected = areas[i].Name;
            }
            Assert.AreEqual(nameTest, nameExpected);
            TestDeleteArea(area);
        }
        public void TestDeleteArea(Area area)
        {
            bool isDelete = true;
            areaBLL.Delete(area);
            List<Area> areas = areaBLL.ListArea();
            for (int i = 0; i < areas.Count; i++)
            {
                if (areas[i].ID == area.ID) isDelete = false;
            }
            Assert.AreEqual(isDelete, true);
        }
        [TestMethod]
        public void TestInputEmptyArea()
        {
            try
            {
                Area area = areaBLL.CreateArea("");
            }
            catch (Exception e)
            {
                Assert.AreNotEqual("", e.ToString());
            }
           
        }
    }
}
