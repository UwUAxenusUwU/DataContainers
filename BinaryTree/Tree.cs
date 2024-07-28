using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class Tree:IEnumerator, IEnumerable
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
            public bool isLeaf()
            {
                return pLeft == pRight;
            }
        }
        public Element Root;
        public Tree()
        {
            //Console.WriteLine($"Tcnstr:\t{GetHashCode()}");
        }
        ~Tree()
        {
            Clear(ref Root);
            Root = null;
            //Console.WriteLine($"Tdstr:\t{GetHashCode()}");
        }

        public void Clear()
        {
            Clear(ref Root);
        }
        void Clear(ref Element Root)
        {
            if(Root == null)return;
            Clear(ref Root.pLeft);
            Clear(ref Root.pRight); 
            Root = null;
            System.GC.WaitForPendingFinalizers();
        }
        public void Add(int Data)
        {
            Insert(Data, Root);
        }
        public IEnumerator GetEnumerator()
        {
            return this;
        }
        public object Current
        {
            get => Root.Data;
        }
        public bool MoveNext()
        {
            return true;
        }
        public void Reset()
        {
            
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
        public void Erase(int Data)
        {
            Erase(Data, ref Root);
        }
        void Erase(int Data, ref Element Root)
        {
            if(Root ==  null) return ;
            Erase(Data, ref Root.pLeft);
            Erase(Data, ref Root.pRight);
            if (Data == Root.Data)
            {
                if(Root.isLeaf())
                {
                    Root = null;
                }
                else
                {
                    if(Count(Root.pLeft) > Count(Root.pRight))
                    {
                        Root.Data = Max(Root.pLeft);
                        Erase(Max(Root.pLeft), ref Root.pRight);
                    }
                    else
                    {
                        Root.Data = Min(Root.pRight);
                        Erase(Min(Root.pRight), ref Root.pLeft);
                    }
                }
            }
        }
        public void Balance()
        {
            Balance(Root);
        }
        void Balance(Element Root)
        {
            if ((Count(Root.pLeft) - Count(Root.pRight)) < 2)
            {
                Insert(Root.Data, Root.pRight);
                Root.Data = Max(Root.pLeft);
                Erase(Max(Root.pLeft), ref Root.pLeft);
            }
            if ((Count(Root.pRight) - Count(Root.pLeft)) > 2)
            {
                Insert(Root.Data, Root.pLeft);
                Root.Data = Min(Root.pRight);
                Erase(Min(Root.pRight), ref Root.pRight);
            }
            if(Math.Abs(Count(Root.pLeft)-Count(Root.pRight))>2)
            {
                Balance(Root);
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
        public int Depth()
        {
            return Depth(Root);
        }
        int Depth(Element Root)
        {
            if (Root == null) return 0;
            //else return Depth(Root.pLeft) + 1 > Depth(Root.pRight) + 1? Depth(Root.pLeft) + 1 : Depth(Root.pRight) + 1;
            int lDepth = Depth(Root.pLeft) + 1;
            int rDepth = Depth(Root.pRight) + 1;
            return Math.Max(lDepth, rDepth);
            
        }
        public void Print(int depth)
        {
            Print(Root, depth);
            Console.WriteLine();
        }
        void Print(Element Root, int Depth)
        {
            if (Root==null) return;
            if (Depth==0) Console.Write(Root.Data + "\t"); 
            Print(Root.pLeft, Depth-1);
            Print(Root.pRight, Depth-1);
        }
        public void TreePrint()
        {
            TreePrint(0);
        }
        void TreePrint(int Depth)
        {
            if (Depth > this.Depth()) return;
            Print(Depth);
            Console.WriteLine();
            TreePrint(Depth + 1);
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
