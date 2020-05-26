using System;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Diagnostics;

namespace imgReaderThreads
{
    class Program
    {

        static void Main(string[] args)
        {
            int nWthreads;
            int nCthreads;
            ThreadPool.GetMaxThreads(out nWthreads, out nCthreads);
            //Console.WriteLine("Max Threads " + nWthreads + "\n IO threads " + nCthreads);

            Console.WriteLine("Enter dir path");

            //string currPath = "C:\\Users\\boris\\Documents\\GitHub\\DigDes_engineer\\imgReaderThreads\\Pics";
            string currPath = Console.ReadLine();
            
            string[] allfiles = Directory.GetFiles(currPath, "*.bmp");
            
            //Console.WriteLine(allfiles.Length);

            //checking for empty directory, just in case
            if (allfiles.Length == 0)
            {
                Console.WriteLine("\nNo files in directory");
                return;
            }
            
            
            for(int i=0; i<allfiles.Length; i++)
            {
                
                
                Thread myThread = new Thread(new ParameterizedThreadStart(readImgs));//creating new thread
                myThread.Name = "Thread: "+i.ToString();
                myThread.Start(allfiles[i]);//starting param. thread
                Thread.Sleep(i*10*i);//main thread delay
            }

            //Console.ReadLine();
        }

        //param have to be object because of ParameterizedThreadStart(readImgs)
        //later make it string to operate
        static void readImgs(object filename)
        {
            string _filename = (string)filename;
            
            Console.WriteLine("Thread: {1}\nВзято в обработку:\n{0}\n",_filename,Thread.CurrentThread.ManagedThreadId);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            int i = Environment.TickCount;
            try//to read image
            {
                Image img1 = Image.FromFile(_filename);
                img1.RotateFlip(RotateFlipType.Rotate90FlipNone);


                img1.Save(_filename);
                img1.Dispose();
            }
            catch//sometimes Out of memory exception appears
            {
                Console.WriteLine("Thread: {1}\nUnable to read {0}\n", _filename,Thread.CurrentThread.ManagedThreadId);
                return;
            }

            //calculating time
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            i = Environment.TickCount - i;

            Console.WriteLine("Thread: {2}\nОбработано:\n{0}\nза {1} ms\n", _filename, ts.TotalMilliseconds, Thread.CurrentThread.ManagedThreadId);
            
            GC.Collect();//just in case
            Thread.Sleep(50);//sub thread delay
        }
        
    }
}
