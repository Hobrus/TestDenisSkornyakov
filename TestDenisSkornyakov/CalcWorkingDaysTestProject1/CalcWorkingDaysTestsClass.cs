using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDenisSkornyakov;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcWorkingDaysTestsNamespace
{
    [TestClass()]
    public class CalcWorkingDaysTestsClass
    {
        [TestMethod()]
        public void Sum2018_01_18Plus5Plus2Holidays_2018_01_25Returned()
        {
            //arrange
            DateTime a = new DateTime(2018, 1, 18);
            Double N = 5;
            Double RB = 1;
            List<string> Dirs = new List<string>();
            Dirs.Add("C:\\Даты\\Январь 2018\\Выходные.txt");
            Dirs.Add("C:\\Даты\\Январь 2018\\Праздники.txt");
            DateTime expected = new DateTime(2018, 1, 25);
            //act
            DateTime actual= new DateTime();
            actual = TestDenisSkornyakov.Form1.CalcWorkingDays(a, N, Dirs, RB);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Sum2018_01_18Plus30Plus13Holidays_2018_03_02Returned()
        {
            //arrange
            DateTime a = new DateTime(2018, 1, 18);
            Double N = 30;
            Double RB = 1;
            List<string> Dirs = new List<string>();
            Dirs.Add("C:\\Даты\\Январь 2018\\Выходные.txt");
            Dirs.Add("C:\\Даты\\Январь 2018\\Праздники.txt");
            Dirs.Add("C:\\Даты\\Февраль 2018\\Выходные.txt");
            Dirs.Add("C:\\Даты\\Февраль 2018\\Праздники.txt");
            DateTime expected = new DateTime(2018, 3, 2);
            //act
            DateTime actual = new DateTime();
            actual = TestDenisSkornyakov.Form1.CalcWorkingDays(a, N, Dirs, RB);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Subtract2018_01_18Subtract5Subtract2Holidays_2018_01_11Returned()
        {
            //arrange
            DateTime a = new DateTime(2018, 1, 18);
            Double N = 5;
            Double RB = -1;
            List<string> Dirs = new List<string>();
            Dirs.Add("C:\\Даты\\Январь 2018\\Выходные.txt");
            Dirs.Add("C:\\Даты\\Январь 2018\\Праздники.txt");
            DateTime expected = new DateTime(2018, 1, 11);
            //act
            DateTime actual = new DateTime();
            actual = TestDenisSkornyakov.Form1.CalcWorkingDays(a, N, Dirs, RB);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Sum2018_01_01Plus9Plus10Holidays_2018_01_22Returned()
        {
            //arrange
            DateTime a = new DateTime(2018, 1, 1);
            Double N = 9;
            Double RB = 1;
            List<string> Dirs = new List<string>();
            Dirs.Add("C:\\Даты\\Январь 2018\\Выходные.txt");
            Dirs.Add("C:\\Даты\\Январь 2018\\Праздники.txt");
            DateTime expected = new DateTime(2018, 1, 22);
            //act
            DateTime actual = new DateTime();
            actual = TestDenisSkornyakov.Form1.CalcWorkingDays(a, N, Dirs, RB);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Sum2017_01_01Plus9Plus10Holidays_2018_01_20Returned()
        {
            //arrange
            DateTime a = new DateTime(2017, 1, 1);
            Double N = 9;
            Double RB = 1;
            List<string> Dirs = new List<string>();
            Dirs.Add("C:\\Даты\\Январь 2017\\Выходные.txt");
            Dirs.Add("C:\\Даты\\Январь 2017\\Праздники.txt");
            DateTime expected = new DateTime(2017, 1, 20);
            //act
            DateTime actual = new DateTime();
            actual = TestDenisSkornyakov.Form1.CalcWorkingDays(a, N, Dirs, RB);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}