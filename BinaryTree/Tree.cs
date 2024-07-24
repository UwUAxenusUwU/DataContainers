using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class Tree
    {
        public class Element
        {
            public int Data;
            public Element pLeft;
            public Element pRight;
            public Element(int Data, Element pLeft=null, Element pRight=null)
            {
                this.Data = Data;
                this.pLeft = pLeft;
                this.pRight = pRight;
                //Console.WriteLine($"Ecnstr:\t{GetHashCode()}");
            }
            ~Element()
            {
                //Console.WriteLine($"Edstr:\t{GetHashCode()}");
            }
        }
        public Element Root;
        public Tree()
        {
            //Console.WriteLine($"Tcnstr:\t{GetHashCode()}");
        }
        ~Tree()
        {
            //Console.WriteLine($"Tdstr:\t{GetHashCode()}");
        }

        public void Insert(int Data)
        {
            Insert(Data, Root);
        }
        void Insert(int Data, Element Root)
        {
            if (this.Root == null ) { this.Root = new Element(Data); }
            if (Root == null) return;
            if (Data < Root.Data)
            {
                if(Root.pLeft == null) 
                {
                    Root.pLeft = new Element(Data);
                }
                else Insert(Data, Root.pLeft);
            }
            else
            {
                if (Root.pRight == null)
                    {
                    Root.pRight = new Element(Data);
                    }
                else Insert(Data,Root.pRight);
            }
        }
        public int Min()
        {
            if (Root == null) throw new Exception("No min in Tree");
            return Min(Root);
        }
        int Min(Element Root)
        {
            if (Root.pLeft == null) return Root.Data;
            else return Min(Root.pLeft);
        }
        public int Max()
        {
            if (Root == null) throw new Exception("No max in Tree");
            return Max(Root);
        }
        int Max(Element Root)
        {
            if (Root.pRight == null) return Root.Data;
            else return Max(Root.pRight);
        }
        public int Count()
        {
            return Count(Root);
        }
        int Count(Element Root)
        {
            return Root==null? 0 : Count(Root.pLeft) + Count(Root.pRight) + 1;
        }
        public int Sum()
        {
            return Sum(Root);
        }
        int Sum(Element Root)
        {
            return Root == null ? 0 : Sum(Root.pLeft)+Sum(Root.pRight)+Root.Data;
        }
        public double Avg()
        {
            return (double)Sum(Root)/Count(Root);
        }
        public void Print()
        {
            Print(Root);
            Console.WriteLine();
        }
        void Print(Element Root)
        {
            if (Root == null) return;
            Print(Root.pLeft);
            Console.WriteLine($"{Root.Data}\t");
            Print(Root.pRight);
        }
    }
}
