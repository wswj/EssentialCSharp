using System;

namespace EssentialCSharp
{
    class Program
    {
        static int Main1(string[] args)
        {
            //接收命令行参数
            foreach (var item in args)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(System.Environment.CommandLine); ;
            Console.WriteLine("Hello World!");
            Console.Write("请输入内容:");
            string input= Console.ReadLine();
            Console.WriteLine($"输入的内容为:{input}");
            string text = "123";
            var textArray = text.ToCharArray();
            foreach (var item in textArray)
            {
                Console.WriteLine(item);
            }
            Array.Reverse(textArray);
            foreach (var item in textArray)
            {
                Console.WriteLine(item);
            }
            //方法传参默认值传递(即将值拷贝给形参,方法中改变参数值不影响原始值)
            string test1 = "123";
            string test2 = "234";
            TestValueArg(test1,test2);
            Console.WriteLine($"{test1}:{test2}");

            //引用传递(传递引用参数改变原始值也会跟着改变)
            Switch(ref test1,ref test2);
            Console.WriteLine($"{test1}:{test2}");
            int i = 0;
            int j = 1;
            //引用传递源值会改变
            SwitchInt(ref i,ref j);
            Console.WriteLine($"{i}:{j}");


            //本质和ref一致,但是ref类型的参数必须先赋值,但out类型不需要,调用的方法必须给out类型的参数赋值否则报错
            string testOut = "test";
            TestOut(testOut,out string testOut2);
            Console.WriteLine(testOut2);


            //只读传引用(传递的参数只能读不能修改)
            string testIn1 = "testIn1";
            TestIn(testIn1,out string testIn2);
            Console.WriteLine($"testin:{testIn2}");
            return 1;
        }
        static void TestValueArg(string v1,string v2) {
            v1 = "456";
            v2 = "567";
        }
        /// <summary>
        /// 引用传递
        /// </summary>
        /// <param name="v1"></param>
        /// <param name=""></param>
        static void Switch(ref string v1,ref string v2) {
            string temp = string.Empty;
            temp = v1;
            v1 = v2;
            v2 = temp;
        }
        static void SwitchInt(ref int x,ref int y) {
            x = 1;
            y = 2;
        }
        static void TestOut(string test1,out string test2) {
            test2 = "testout";
        }
        static void TestIn(in string tets1,out string test2) {
            test2 = tets1;
        }

        //返回变量引用
        public static ref byte FindFirstRedEyePixel(byte[] image) {
            for (int i = 0; i < image.Length; i++)
            {
                if (image[i]==(byte)ConsoleColor.Red) {
                    return ref image[i];
                }
            }
            throw new InvalidOperationException("not pixel are red");
        }
    }
}
