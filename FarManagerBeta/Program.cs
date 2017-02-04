using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManagerBeta
{
    class Program
    {
        static void print(List<Object> entries, int pos)
        {
            Console.SetCursorPosition(0, 0);
            int lineNumber = 0;
            foreach (Object entry in entries)
            {
                if (lineNumber == pos)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (entry is DirectoryInfo)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(((DirectoryInfo)entry).Name);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(((FileInfo)entry).Name);
                }
                lineNumber++;
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo sanzhar = new DirectoryInfo(@"C:\Users\sanzh\Desktop");
            DirectoryInfo[] allSanzhars = sanzhar.GetDirectories();
            FileInfo[] allNeSanzhars = sanzhar.GetFiles();
            List<Object> entries = new List<object>();
            foreach (DirectoryInfo papka in allSanzhars)
            {
                entries.Add(papka);
            }
            foreach (FileInfo fail in allNeSanzhars)
            {
                entries.Add(fail);
            }
            int pos = 0;
            print(entries, pos);
            while (true)
            {
                ConsoleKeyInfo sanzharEntered = Console.ReadKey();
                if (sanzharEntered.Key == ConsoleKey.UpArrow)
                {
                    if (pos == 0)
                    {
                        pos = entries.Count - 1;
                    }
                    else
                    {
                        pos--;
                    }
                }
                else if (sanzharEntered.Key == ConsoleKey.DownArrow)
                {
                    if (pos == entries.Count - 1)
                    {
                        pos = 0;
                    }
                    else
                    {
                        pos++;
                    }
                }
                print(entries, pos);
            }
        }
    }
}
