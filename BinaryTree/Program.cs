//#define TREE_BASE_CHECK
//#define INITIALIZER_LIST_CHECK
//#define PERFORMANCE_CHECK
//#define TREE_PRINT_CHECK
#define BALANCE_CHECK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace BinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Random rnd = new Random(0);
            //Console.Write("Set Tree size: ");
            //int n = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine();
#if TREE_BASE_CHECK
            try
            {
                Tree tree = new Tree();
                for (int i = 0; i < n; i++)
                {
                    tree.Insert(rnd.Next(100));
                }
                tree.Print();
                Console.WriteLine(tree.Min());
                Console.WriteLine(tree.Max());
                Console.WriteLine(tree.Count());
                Console.WriteLine(tree.Sum());
                Console.WriteLine(tree.Avg());
                tree.Clear();
                tree.Print();

#endif
#if INITIALIZER_LIST_CHECK
            try
            {
                Tree tree = new Tree() { 50, 25, 75, 16, 32, 64, 91 };
                for (int i = 0; i < n; i++)
                {
                    tree.Insert(rnd.Next(100));
                }
                tree.Print();
                Console.WriteLine("Min: " + tree.Min());
                Console.WriteLine("Max: " + tree.Max());
                Console.WriteLine("Count: " + tree.Count());
                Console.WriteLine("Depth: " + tree.Depth());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
#endif
#if PERFORMANCE_CHECK
            try
            {

                Tree tree = new Tree();
                for (int i = 0; i < n; i++)
                {
                    tree.Insert(rnd.Next(100));
                }
                //tree.Print();

                #region stupid performance measuring
                ////perfomance test
                //Stopwatch sw = new Stopwatch();
                //Console.WriteLine("Min: " + tree.Min());
                //Console.WriteLine("Max: " + tree.Max());
                //Console.WriteLine("Count: " + tree.Count());
                //sw.Start();
                //Console.Write("Depth: " + tree.Depth());
                ////Thread.Sleep(1000);
                //Console.WriteLine($", time needed: {sw.Elapsed.TotalMilliseconds} ms");
                //sw.Stop(); 
                #endregion

                TreePerformance<int>.Measure("Min value in tree: ", tree.Min);
                TreePerformance<int>.Measure("Max value in tree: ", tree.Max);
                TreePerformance<int>.Measure("Sum of elements in tree: ", tree.Sum);
                TreePerformance<int>.Measure("Count of elements in tree: ", tree.Count);
                TreePerformance<double>.Measure("Avg of elements in tree: ", tree.Avg);
                TreePerformance<int>.Measure("Depth value in tree: ", tree.Depth);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            } 
#endif
#if TREE_PRINT_CHECK
            Tree tree = new Tree() { 50, 25, 75, 16, 32, 64, 91 };
            tree.Print();
            //Console.WriteLine("Set depth: ");
            //int depth = Convert.ToInt32(Console.ReadLine());
            //tree.Print(depth);
            tree.TreePrint(); 
#endif
#if BALANCE_CHECK
            //Tree tree = new Tree() { 3, 5, 8, 13, 21, 34, 55, 89 };
            Tree tree = new Tree() { 50, 25, 75, 16, 32, 64, 91 };
            tree.TreePrint();
            tree.Erase(25);
            tree.TreePrint();
            tree.Balance();
            tree.TreePrint();
#endif

        }
    }
}
