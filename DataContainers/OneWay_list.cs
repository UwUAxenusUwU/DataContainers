using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContainers
{
    internal class List_oneway
    {
        private List_oneway_node head;

        public void Add(int data)
        {
            List_oneway_node newNode = new List_oneway_node(data);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                List_oneway_node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            } 
        }
        public void Remove(int data)        //в общем работает косячно, мистер част gpt тоже фигню выдаёт, просто чтобы долго не топтаться пока скипну
            //этот момент, нужно догнать группу 24.07.24
        {
            if (head == null) { return; }
            if (head.Data == data)
            {
                head = head.Next;
                return;
            }
            List_oneway_node current = head;
            if (current != null)
            {
                if (current.Data == data)
                {
                    current = current.Next;
                    return;
                }

            }
        }
        public void Print()
        {
            List_oneway_node current = head;
            while (current != null)
            {
                Console.Write($"{current.Data}\t");
                current = current.Next;
            }
        }
    }
}
