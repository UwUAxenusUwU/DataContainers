using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List_oneway list = new List_oneway();
            list.Add(5);
            list.Add(99);
            list.Add(254);
            list.Add(231);
            list.Add(123);
            list.Add(321);
            list.Print();
            Console.WriteLine();
            list.Remove(99);
            list.Print();
        }
    }
}
