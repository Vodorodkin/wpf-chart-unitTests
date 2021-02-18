using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using project;
namespace methodsTests
{
    [TestClass]
    public class UnitTest1
    {
        double[] array;
        double[] array1;
        double[] array2;
        double[] array3;
        double h;
        [TestInitialize]
        public void Initialize ()
        {
            array = new double[] { 0, 2, 4, 5, 6, 10, 11 };
            array1 = new double[] { 104.67 , 17.45 , 21.86 };
            array2 = new double[] { 104 , -94.05 };
            array3 = new double[] {0,0,0,0,0,0,0,0,0,0,0};
            h=0.1;
        }
        [TestMethod]      
        public void TestShellSort()
        {
            double[] exepted = new double[] {11,10,6,5,4,2,0};
            double[] actual = methods.ShellSort(array);
            CollectionAssert.AreEqual(exepted, actual);
        }
        [TestMethod]
        public void TestPN1()
        {
            double[] exepted = new double[] { 104.67 , -87.22, 45.815 };
            double[] actual = methods.PN1(3, array1);
            CollectionAssert.AreEqual(exepted, actual);
        }
        [TestMethod]
        public void TestPN2()
        {
            double[] exepted = new double[] { 104 , 94.6 , 85.19 , 75.78 , 66.38 , 56.98, 47.57 , 38.17, 28.76, 19.36 , 9.95 };
            double[] actual = methods.PN2(array2,2,array3,h,11);
            CollectionAssert.AreEqual(exepted, actual);
        }

    }
}
