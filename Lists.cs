using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox
{
    internal class Lists
    {
        internal static void ListSW(string[] strings) 
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            List<string> list = new List<string>();
            foreach (string s in strings)
            {
                list.Add(s);
            }
            sw.Stop();

            Console.WriteLine($"Time elapsed for List: {sw.ElapsedMilliseconds} ms");
        }

        internal static void LinkedListSW(string[] strings)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            LinkedList<string> linkedList = new LinkedList<string>();
            foreach (string s in strings)
            {
                linkedList.AddLast(s);
            }
            sw.Stop();
            Console.WriteLine($"Time elapsed for LinkedList: {sw.ElapsedMilliseconds} ms");
        }
    }
}
