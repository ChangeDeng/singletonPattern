using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestClass testClass = new TestClass(); no work

            TestClass testClass = TestClass.GetInstance();

            testClass.TestMethod();

            TestClass testClass2 = TestClass.GetInstance();

            testClass2.TestMethod();

            Console.Read();
        }
    }
    public class TestClass
    {
        private static TestClass instance = null;
        
        private TestClass()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + "  TestClass()");
            System.Threading.Thread.Sleep(3000);
        }

        public static TestClass GetInstance()
        {
            if (instance == null)
            {
                instance = new TestClass();
            }
            return instance;
        }
        public void TestMethod()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + " this is a TestMethod()");
        }
    }
}
