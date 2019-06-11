using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton2
{

        class Program
        {
            static void Main(string[] args)
            {
                Task.Factory.StartNew(() =>
                {
                    var test = TestClass.GetInstance();//占用资源
                    test.TestMethod();
                });
                Task.Factory.StartNew(() =>
                {
                    var test = TestClass.GetInstance();//占用资源
                    test.TestMethod();
                });

                Console.Read();
            }
        }

        public class TestClass
        {
            //【1】创建一个私有的静态成员变量，用来保存当前类的实例
            private static TestClass instance;

            //【2】私有化构造方法：避免外界直接new这个类的实例
            private TestClass()
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString() + "  TestClass()构造方法开始执行时间");
                //需要访问其他资源。。。会耗费时间。。。
                System.Threading.Thread.Sleep(3000);
            }
            //【4】创建一个静态只读的辅助对象(为了lock使用的)
            private static readonly object helperObject = new object();

            //【3】创建一个让外界能获取到实例的静态方法
            public static TestClass GetInstance()
            {
                if (instance == null)//先判断实例是否存在，不存在则执行锁
                {
                    lock (helperObject)
                    {
                        //这个判断是防止在实例为null的情况下，可能有多个线程都会排队等待进入
                        //如果没有这判断，则第一个判断进来后所有的线程都会执行实例化
                        //如果有了这个判断，那么第一个线程实例化以后，后面排队进来的线程就不会再实例化了。
                        if (instance == null)
                        {
                            instance = new TestClass();
                        }
                        //   instance = new TestClass();
                    }
                }
                return instance;
            }

            public void TestMethod()
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString() + "   TestMethod()方法执行时间");
            }
        }
}
