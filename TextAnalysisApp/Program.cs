using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace TextAnalysisTool
{
    internal class Program
    {
        static string fileName = "C:\\Users\\maggi\\Documents\\Man Met\\Algorithms and Data Structures\\sherlockHolmes.txt"; //file to read
        static string[] linesInFile;
        static void Main(string[] args)
        {
            readDisplayFileWords();
        }

        static void readDisplayFileWords()
        {
            linesInFile = File.ReadAllLines(fileName);
            int lineNumber = 0;
            int numberWords = 0;
            //delimiters are chars that split words in a text file
            char[] delimiters = { ' ', ',', '"', ':', ';', '?', '!', '-', '.', '\'', '*' };
            LinkedList text = new LinkedList();
            foreach (string line in linesInFile) //take each line string form the file one at a time
            {
                lineNumber++; //increment the current line number
                              //split up line into separate words using any delimiter - array of strings, each element is a word on the current line
                string[] wordsInLine = line.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries);
                //Console.Write(lineNumber + ":"); //display file line number
                foreach (string words in wordsInLine)
                {
                    if (isWord(words))
                    {
                        numberWords++;
                        //Console.Write(words.ToLower() + ","); //display lowercase version of word

                        text.AddUnique(words.ToLower());
                    }
                }
                //Console.WriteLine();
            }
            //Console.Write(fileName + " contains " + numberWords + "words."); //display file line number
            //Console.ReadKey();

            bool exit = false; 

            while (!exit)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Display number of unique words");
                Console.WriteLine("2. Display number of occurrences of each word");
                Console.WriteLine("3. Display words in ascending alphabetical order");
                Console.WriteLine("4. Display longest word");
                Console.WriteLine("5. Display most frequent word");
                Console.WriteLine("6. Please enter a word to check if it exits");
                Console.WriteLine("7. Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Number of unique words: {text.CountUniqueWords()}");
                        break;
                    case "2":
                        Console.WriteLine("Number of occurrences:");
                        text.DisplayOcurrences();
                        break;
                    case "3":
                        Console.WriteLine("Words in ascending alphabetical order:");
                        text.DisplaySorted();
                        break;
                    case "4":
                        var (longestWord, count) = text.GetLongestWord();
                        Console.WriteLine($"Longest word: {longestWord} ({count} occurrences)");
                        break;
                    case "5":
                        var (mostFrequent, highestcount) = text.GetMostFrequentWord();
                        Console.WriteLine($"Most Frequent Word: {mostFrequent} ({highestcount} occurrences)");
                        break;
                    case "6":
                        Console.WriteLine("Please enter a word: ");
                        string inputWord = Console.ReadLine();
                        text.ContainsInput(inputWord);
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }


            }
            
           
            
            
            
            
            
            
            

        }

        static Boolean isWord(string str) //uses regular expression to check str is a letters only
        {
            return Regex.IsMatch(str, @"\b(?:[a-z]{2,}|[ai])\b", RegexOptions.IgnoreCase);
        }


    }
}
