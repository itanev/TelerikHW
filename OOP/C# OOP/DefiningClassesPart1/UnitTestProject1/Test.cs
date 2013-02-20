using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileDevice;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            GSM MyGSM = new GSM("Monte", "Samsung", 10, "Pesho", "DINO", 10, 6, BatteryType.LiIon, 7, 256000);
        }

        [TestMethod]
        public void TestMethod2()
        {
            List<GSM> GSMList = new List<GSM>();

            GSMList.Add(new GSM("Monte", "Samsung", "DINO"));
            GSMList.Add(new GSM("4310", "Nokia", "PESHO", 200));
            GSMList.Add(new GSM("3060", "Motorola", "KIRO", 200, "Ivan"));
            GSMList.Add(new GSM("IPhone4S", "Apple", "SHRT", 800, "Ivan", 9, 8));
            GSMList.Add(new GSM("3640", "Simens", "UIO", 200, "Ivan", 9, 8, BatteryType.NiCd));
            GSMList.Add(new GSM("4780", "HTC", "IYUT", 500, "Ivan", 6, 8, BatteryType.NiCd, 8));
            GSMList.Add(new GSM("Nexus", "Google", 900, "Pesho", "TECH", 10, 6, BatteryType.LiIon, 7, 256000));
        }

        [TestMethod]
        public void TestMethod3()
        {
            List<GSM> GSMList = new List<GSM>();

            GSMList.Add(new GSM("Monte", "Samsung", "DINO"));
            GSMList.Add(new GSM("4310", "Nokia", "PESHO", 200));
            GSMList.Add(new GSM("3060", "Motorola", "KIRO", 200, "Ivan"));
            GSMList.Add(new GSM("IPhone4S", "Apple", "SHRT", 800, "Ivan", 9, 8));
            GSMList.Add(new GSM("3640", "Simens", "UIO", 200, "Ivan", 9, 8, BatteryType.NiCd));
            GSMList.Add(new GSM("4780", "HTC", "IYUT", 500, "Ivan", 6, 8, BatteryType.NiCd, 8));
            GSMList.Add(new GSM("Nexus", "Google", 900, "Pesho", "TECH", 10, 6, BatteryType.LiIon, 7, 256000));

            foreach (var gsm in GSMList)
            {
                GSM.IPhone = "Some information for IPhone4S from" + gsm.Model;
                Console.WriteLine("{0} : \nIPhone info: \n {1}\n", gsm, GSM.IPhone);
            }
        }

        [TestMethod]
        public void TestMethod4()
        {
            GSM MyGSM = new GSM("Monte", "Samsung", -10, "Pesho", "DINO", 10, 6, BatteryType.LiIon, 7, 256000);
        }

        //To fail
        [TestMethod]
        public void TestMethod5()
        {
            GSM MyGSM = new GSM("Monte", "Samsung", 10, "Pesho", "DINO", -10, 6, BatteryType.LiIon, 7, 256000);
        }

        //To fail
        [TestMethod]
        public void TestMethod6()
        {
            GSM MyGSM = new GSM("Monte", "Samsung", 10, "Pesho", "DINO", 10, -6, BatteryType.LiIon, 7, 256000);
        }

        //To fail
        [TestMethod]
        public void TestMethod7()
        {
            GSM MyGSM = new GSM("Monte", "Samsung", 10, "Pesho", "DINO", 10, 6, BatteryType.LiIon, -7, 256000);
        }

        //To fail
        [TestMethod]
        public void TestMethod8()
        {
            GSM MyGSM = new GSM("Monte", "Samsung", 10, "Pesho", "DINO", 10, 6, BatteryType.LiIon, 7, -256000);
        }

    }
}
