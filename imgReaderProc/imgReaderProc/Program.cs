using System;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;

namespace imgReaderProc
{
    class Program
    {
        // C:\\Users\\boris\\Documents\\GitHub\\DigDes_engineer\\imgReaderProc
        static void Main(string[] args)
        {

            Console.WriteLine("Enter dir path");

            //string currPath = "C:\\Users\\boris\\Documents\\GitHub\\DigDes_engineer\\imgReaderThreads\\Pics";
            string currPath = Console.ReadLine();
            Thread.Sleep(20000);
            string[] allfiles = Directory.GetFiles(currPath, "*.bmp");
            //Directory.CreateDirectory(currPath + "\\result");
            
            List<string> changed = new List<string>(0);
            bool flag = true;

            while (flag)
            {
                foreach (string _filename in allfiles)
                {
                    DateTime oldestProc = updateOldestProc();
                    if (changed.IndexOf(_filename)!=-1) { continue; }
                    if ((isLocked(_filename))|| (Directory.GetCreationTime(_filename) > oldestProc))
                    {
                        changed.Add(_filename);
                        continue;
                    }
                    
                    if (changed.Count == allfiles.Length)
                    {
                        Console.WriteLine("Программа завершена");
                        return;
                    }
                    try//to read image
                    {

                        Image img1 = Image.FromFile(_filename);
                        Console.WriteLine("pID: {1}\nПринято в обработку\n{0}", _filename,Process.GetCurrentProcess().Id);
                        int i = Environment.TickCount;
                        img1.RotateFlip(RotateFlipType.Rotate90FlipNone);


                        img1.Save(_filename);
                        Console.WriteLine("pID: {1}\nВыполнено\n{0}", _filename, Process.GetCurrentProcess().Id);
                        Directory.SetCreationTime(_filename, DateTime.Now) ;
                        img1.Dispose();
                    }
                    catch//sometimes Out of memory exception appears
                    {
                        Console.WriteLine("pID: {1}\nUnable to read {0}\n", _filename, Process.GetCurrentProcess().Id);
                        return;
                    }
                    Thread.Sleep(2000);
                }
            }//*/
            Console.ReadLine();
            
        }

        public static DateTime updateOldestProc()
        {
            //Process _proc = Process.GetCurrentProcess();
            DateTime min = Process.GetCurrentProcess().StartTime;
            Process[] procnames = Process.GetProcessesByName("imgReaderProc");
            foreach(Process proc in procnames)
            {
                if (proc.StartTime<min) { min = proc.StartTime; }
                //Console.WriteLine(proc.StartTime);
            }
            return min;
        }//*/
        public static bool isLocked(string fileName)
        {
            try
            {
                using (Image img1 = Image.FromFile(fileName))
                {
                    img1.Dispose();
                    return false;
                    //Console.WriteLine("файл свободен");
                }
            }
            catch
            {
                //Console.WriteLine("файл занят");
                return true;
            }
        }
    }

}
