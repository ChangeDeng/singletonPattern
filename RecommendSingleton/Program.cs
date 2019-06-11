using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendSingleton
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    //使用密封类
    public sealed class TestClass
    {
        //【1】创建一个只读私有的成员变量，用来保存当前实例，并且在第一次引用成员的时候就创建。
        //其实我们就是把对象的创建交给CLR，这种方式本身就是线程安全
        private static readonly TestClass instance = new TestClass();

        //【2】私有化构造方法：避免外界直接new这个类的实例
        private TestClass()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + "  TestClass()构造方法开始执行时间");
            //需要访问其他资源。。。会耗费时间。。。
            System.Threading.Thread.Sleep(3000);
        }

        //【3】创建一个外接能获取到实例的静态方法
        public static TestClass GetInstance()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + "   GetInstance()方法执行的时间");
            return instance;
        }

        public void TestMethod()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + "   TestMethod()方法执行时间");
        }
    }
}
