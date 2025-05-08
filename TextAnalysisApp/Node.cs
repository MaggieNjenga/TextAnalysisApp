using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysisTool
{
    internal class Node // we first create a blueprint for each node
    {
        private string data; //field to store the data of the node which is some word in a text
        private int count; //field to store the number of times the word appears in a node
        private Node next; //field to store the reference to the next node in the list

        public Node(string word)
        {
            this.data = word; //initialize the data field with the provided word
            this.count = 1; //start counting from 1 when each word is created
            this.next = null; //initialize the next field to null as the new node does not point to anything yet
        }
        public Node(string word, Node list)
        {
            this.data = word;
            this.count = count;
            this.next = list;
        }
        public string Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
        public int Count
        {
            get { return this.count; }
            set { this.count = value; }
        }
        public Node Next
        {
            get { return this.next; }
            set { this.next = value; }
        }
    }
}
