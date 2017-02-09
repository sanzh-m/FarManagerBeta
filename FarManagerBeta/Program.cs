using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManagerBeta
{
    class Program
    {
        static string delete (string s)
        {
            int i = s.Length-1;
            if (s.Length < 4) return s;
            while (!'\\'.Equals(s[i]))
            {
                --i;
            }
            string k = null;
            for (int j=0; j<i; ++j)
            {
                k += s[j];
            }
            return k;
        }
        static void print(List<Object> entries, int pos)
        {
            Console.Clear();
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
            string path = @"D:\Backup";
            DirectoryInfo sanzhar = new DirectoryInfo(path);
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
                else if (sanzharEntered.Key == ConsoleKey.Enter)
                {
                    Object s = new Object();
                    s = entries[pos];
                    if (s.GetType() == typeof(DirectoryInfo))
                    {
                        path += @"\" + ((DirectoryInfo)entries[pos]).Name;
                        sanzhar = new DirectoryInfo(path);
                        allSanzhars = sanzhar.GetDirectories();
                        allNeSanzhars = sanzhar.GetFiles();
                        entries.Clear();
                        entries = new List<object>();
                        foreach (DirectoryInfo papka in allSanzhars)
                        {
                            entries.Add(papka);
                        }
                        foreach (FileInfo fail in allNeSanzhars)
                        {
                            entries.Add(fail);
                        }
                        pos = 0;

                    }
                    else
                    {
                        string k = path + @"\" + ((FileInfo)entries[pos]).Name;
                        Process p = new Process();
                        p.StartInfo.FileName = k;
                        p.StartInfo.UseShellExecute = true;
                        p.Start();
                    }
                }
                if (sanzharEntered.Key == ConsoleKey.Backspace)
                {
                    path = delete(path);
                    sanzhar = new DirectoryInfo(path);
                    allSanzhars = sanzhar.GetDirectories();
                    allNeSanzhars = sanzhar.GetFiles();
                    entries = new List<object>();
                    foreach (DirectoryInfo papka in allSanzhars)
                    {
                        entries.Add(papka);
                    }
                    foreach (FileInfo fail in allNeSanzhars)
                    {
                        entries.Add(fail);
                    }
                    pos = 0;
                }
                print(entries, pos);
            }
        }
    }
}
