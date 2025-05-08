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
                Console.Write(lineNumber + ":"); //display file line number
                foreach (string words in wordsInLine)
                {
                    if (isWord(words))
                    {
                        numberWords++;
                        Console.Write(words.ToLower() + ","); //display lowercase version of word

                        text.AddUnique(words.ToLower());
                    }
                }
                Console.WriteLine();
            }
            //Console.Write(fileName + " contains " + numberWords + "words."); //display file line number
            //Console.ReadKey();
            Console.WriteLine($"Number of unique words: {text.CountUniqueWords()}");
            Console.ReadKey();
            Console.WriteLine("\n Number of Occurrences:");
            text.Display();
            Console.ReadKey();
            Console.WriteLine($"\nWords in descending alphabetical order:");
            text.DisplaySorted();
            Console.ReadKey();
            var (longestWord, count) = text.GetLongestWord();
            Console.WriteLine($"Longest word: {longestWord} ({count} occurrences)");
            Console.ReadKey();
            var (mostFrequent, highestcount) = text.GetMostFrequentWord();
            Console.WriteLine($"Most Frequent Word: {mostFrequent} ({highestcount} occurrences)");
            Console.ReadKey();
            Console.WriteLine("\nPlease enter a word: ");
            string inputWord = Console.ReadLine();
            text.ShowWordFrequency( inputWord );
            Console.ReadKey();

        }

        static Boolean isWord(string str) //uses regular expression to check str is a letters only
        {
            return Regex.IsMatch(str, @"\b(?:[a-z]{2,}|[ai])\b", RegexOptions.IgnoreCase);
        }


    }
}
