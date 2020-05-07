using System;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        /*public class MagicClass
        {
            private int magicBaseValue;

            public MagicClass()
            {
                magicBaseValue = 9;
            }

            public int ItsMagic(int preMagic)
            {
                return preMagic * magicBaseValue;
            }
        }//*/
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
            Type[] typelist = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type cl in typelist)
            {
                Console.WriteLine("");
                Console.Write(cl.Name);
                Console.Write(" ");
                Console.WriteLine(cl.IsAbstract);
                Console.WriteLine("**************************************************************************");
                MethodInfo[] mi = cl.GetMethods(BindingFlags.Instance
                           | BindingFlags.Static
                           | BindingFlags.Public
                           | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);//*/
                ConstructorInfo[] ci = cl.GetConstructors(BindingFlags.Instance
                           | BindingFlags.Static
                           | BindingFlags.Public
                           | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);//*/
                if (cl.IsAbstract)
                {
                    Type absType = cl;
                    Console.WriteLine(absType);
                    ConstructorInfo absConstructor = ci[0];
                    object absClassObject = absConstructor.Invoke(new object[] { });
                    MethodInfo absMethod = absType.GetMethod("Print");
                }//*/


                    foreach (var tt in mi)
                {
                    Console.Write(tt.Name);
                    Console.Write(" ");
                    Console.WriteLine(tt.IsAbstract);
                }

                Console.WriteLine("");
            }
        }
        static void Main(string[] args)
        {
            //Reflection();
            Assembly asm = Assembly.LoadFrom("System.Reflection.dll");

            Type t = asm.GetType("ConsoleApp1.Program+absClass", true, true);

            // создаем экземпляр класса Program
            /*object obj = Activator.CreateInstance(t);

            // получаем метод GetResult
            MethodInfo method = t.GetMethod("Print");

            // вызываем метод, передаем ему значения для параметров и получаем результат
            object result = method.Invoke(obj, new object[] { 6, 100, 3 });
            Console.WriteLine((result));//*/
            Console.WriteLine();


        }
    }
}
