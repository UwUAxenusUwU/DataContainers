//#define TREE_BASE_CHECK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random(0);
#if TREE_BASE_CHECK
            Console.WriteLine("Set Tree size:");
            int n = Convert.ToInt32(Console.ReadLine());
            try
            {
                //Tree tree = new Tree();
                //for (int i = 0; i < n; i++)
                //{
                //    tree.Insert(rnd.Next(100));
                //}
                //tree.Print();
                //Console.WriteLine(tree.Min());
                //Console.WriteLine(tree.Max());
                //Console.WriteLine(tree.Count());
                //Console.WriteLine(tree.Sum());
                //Console.WriteLine(tree.Avg());

                UniqTree tree1 = new UniqTree();
                for (int i = 0; i < n; i++)
                {
                    tree1.Insert(rnd.Next(100));
                }
                tree1.Print();
                Console.WriteLine(tree1.Min());
                Console.WriteLine(tree1.Max());
                Console.WriteLine(tree1.Count());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            } 
#endif
            Tree tree = new Tree() { 3,5,8,13,21};
        }
    }
}
