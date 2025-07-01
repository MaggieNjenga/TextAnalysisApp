using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace TextAnalysisTool
{
    internal class LinkedList
    {
        private Node headlist  = null; //initialize an empty list that points to the first node in the list
        public void AddUnique(string word) //add a word to the front of the list
        {
            Node temp = headlist;
            while (temp != null)
            {
                if (temp.Data == word)
                {
                    temp.Count++; //if word already exists increase count
                    return;
                }
                temp = temp.Next;
            }

            Node newNode = new Node(word); //create a new node
            newNode.Next = headlist; // link new node to the current head
            headlist = newNode; //Move head to point to new node          
        }
        public int CountUniqueWords()
        {
            int UniqueCount = 0;
            Node temp = headlist;
            while (temp != null)
            {
                UniqueCount++;
                temp = temp.Next;
            }
            return UniqueCount;
        }
        public void DisplayOcurrences()
        {
            Node temp = headlist;
            while (temp != null)
            {
               Console.WriteLine($"{temp.Data}: {temp.Count} times");
               temp = temp.Next;
            }
        }

        public void DisplaySorted()
        {
            List<(string word, int count)> sortedList = new List<(string, int)>(); //create new temporary list to store all the words and their counts
            Node temp = headlist;

            while (temp != null)
            {
                sortedList.Add((temp.Data, temp.Count)); //at each step, add the current node's word and count into the new list
                temp = temp.Next; 
            }

            var sorted = sortedList.OrderBy(w => w.word);

            foreach (var item in sorted)
            {
                Console.WriteLine($"{item.word}:{item.count} times");
            }
        }

        public(string word, int count) GetLongestWord()
        {
            Node temp = headlist;
            string longestword = "";
            int count = 0;

            while (temp != null)
            {
                if (temp.Data.Length > longestword.Length)
                {
                    longestword = temp.Data;
                    count = temp.Count;
                }
                temp = temp.Next;
            }
            return(longestword, count);
        }

        public(string word, int count) GetMostFrequentWord()
        {
            Node temp = headlist;
            string mostFrequent = "";
            int highestcount = 0;

            while (temp != null)
            {
                if (temp.Count > highestcount)
                {
                    mostFrequent = temp.Data;
                    highestcount = temp.Count;
                }
                temp = temp.Next;
            }
            return (mostFrequent, highestcount);
        }

        public void ContainsInput(string word)
        {
            string input = word.ToLower();
            Node temp = headlist;
            while (temp != null)
            {
                if(temp.Data == input)
                {
                    Console.WriteLine($"The word '{word}' appears {temp.Count} times.");
                    return;
                }
                temp = temp.Next;
            }
            Console.WriteLine($"The word '{word}' was not found in the file.");
        }




    }
}
