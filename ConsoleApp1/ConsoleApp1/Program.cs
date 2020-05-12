using System;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
 
        class Addition
        {
            public Addition(int a)
            {
                Console.WriteLine("Constructor called, a={0}", a);
            }
        }//*/
        abstract class absClass
        {
            public static void Display()
            {
                Console.WriteLine("Hello world");
            }//*/
            public void Print()
            {
                Console.WriteLine("DigDes!");
            }
        }
        public static void Reflection()
        {
            Type t = typeof(System.Reflection.MethodInfo);
            Assembly asm = t.Assembly;
            Type[] typelist = asm.GetTypes();
            foreach (Type cl in typelist)
            {
                Console.WriteLine("");
                //Console.Write(cl.Name);
                Console.Write(" ");
                //Console.WriteLine(cl.IsAbstract);
                //Console.WriteLine("**************************************************************************");
                MethodInfo[] mi = cl.GetMethods(BindingFlags.Instance
                           | BindingFlags.Static
                           | BindingFlags.Public
                           | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
                ConstructorInfo[] ci = cl.GetConstructors(BindingFlags.Instance
                            | BindingFlags.Static
                            | BindingFlags.Public
                            | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);


                if (cl.Name == "Invoke")
                {
                    Console.Write(cl.Name);
                    Console.WriteLine(cl.IsAbstract);
                    foreach (var tt in mi)
                    {
                        Console.Write(tt.Name);
                        Console.Write(" ");
                        Console.WriteLine(tt.IsAbstract);
                    }
                }
                Console.WriteLine("");
            }
        }       //*/
        static void Main(string[] args)
        {
            //Reflection();
            //знаешь что в этой библ есть класс методинфо. писать тайпоф методинфо. поучаем экз тайпоф методинфо. дальше через точку можно плучить экз ассемблей этого класса
            //можно по др пути, нашел метод инвок, класс приватный, поискать в этой библиотеки другие публичные классы из него взять, получать ассемблей 
            //Type t = typeof(System.Reflection.MethodInfo);
            /*Type t = typeof(Program);
            Assembly asm = t.Assembly;
            //object obj = Activator.CreateInstance(t);
            Console.WriteLine(asm);
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            MethodInfo[] mi = t.GetMethods();
            //MethodInfo mi2 = t.GetMethod("Invoke");

            MethodInfo mi2 = t.GetMethod("Invoke", new Type[] { t, t });
            foreach (var tt in mi)
            {
                Console.Write(tt.Name);
                Console.WriteLine(" ");
                
                if ((tt.Name == "Invoke")
                    //&&(!tt.IsAbstract)
                    )
                {
                    //object result = tt.Invoke(obj, new object[] { });
                    Console.WriteLine(tt.GetType());
                }
            }//*/

            Console.WriteLine();
            Console.WriteLine();

        }
    }
}
