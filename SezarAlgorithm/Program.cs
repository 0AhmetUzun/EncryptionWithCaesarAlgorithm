using System;
using System.Collections.Generic;
using System.Text;

namespace SezarAlgorithm
{
    internal class Program
    {
        static Dictionary<char, char> upperCaseEncryptDict = new Dictionary<char, char>();
        static Dictionary<char, char> lowerCaseEncryptDict = new Dictionary<char, char>();
        static Dictionary<char, char> upperCaseDecryptDict = new Dictionary<char, char>();
        static Dictionary<char, char> lowerCaseDecryptDict = new Dictionary<char, char>();

        static void Main(string[] args)
        {
            int scroll = 3;
            BuildDictionaries(scroll);

            while (true)
            {
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1 - Code");
                Console.WriteLine("2 - Decode");
                Console.WriteLine("3 - Quit");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Enter a number.");
                    continue;
                }

                if (choice == 1)
                {
                    Console.Write("Enter text: ");
                    string text = Console.ReadLine();
                    Console.WriteLine("Coded text: " + Coded(text));
                }
                else if (choice == 2)
                {
                    Console.Write("Enter encrypted text: ");
                    string text = Console.ReadLine();
                    Console.WriteLine("Decoded text: " + Decoded(text));
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Quitting...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid selection, please try again.");
                }

                Console.WriteLine(); 
            }
        }

        static void BuildDictionaries(int scroll)
        {
            string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lower = "abcdefghijklmnopqrstuvwxyz";

            for (int i = 0; i < upper.Length; i++)
            {
                char u = upper[i];
                char uScrolled = upper[(i + scroll) % upper.Length];
                upperCaseEncryptDict[u] = uScrolled;
                upperCaseDecryptDict[uScrolled] = u;

                char l = lower[i];
                char lScrolled = lower[(i + scroll) % lower.Length];
                lowerCaseEncryptDict[l] = lScrolled;
                lowerCaseDecryptDict[lScrolled] = l;
            }
        }

        static string Coded(string input)
        {
            StringBuilder result = new StringBuilder();

            foreach (char ch in input)
            {
                if (upperCaseEncryptDict.ContainsKey(ch))
                    result.Append(upperCaseEncryptDict[ch]);
                else if (lowerCaseEncryptDict.ContainsKey(ch))
                    result.Append(lowerCaseEncryptDict[ch]);
                else
                    result.Append(ch);
            }

            return result.ToString();
        }

        static string Decoded(string input)
        {
            StringBuilder result = new StringBuilder();

            foreach (char ch in input)
            {
                if (upperCaseDecryptDict.ContainsKey(ch))
                    result.Append(upperCaseDecryptDict[ch]);
                else if (lowerCaseDecryptDict.ContainsKey(ch))
                    result.Append(lowerCaseDecryptDict[ch]);
                else
                    result.Append(ch);
            }

            return result.ToString();
        }
    }
}