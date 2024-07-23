using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContainers
{
    internal class List_oneway_node
    {
        public int Data {get; set;}
        public List_oneway_node Next { get; set;}

        public List_oneway_node(int data) 
        {
            Data = data;
            Next = null;
        }
    }
    }
