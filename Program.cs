using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EncodeDecodeApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            StartFunction();
        }
        #region functions
        /// <summary>
        /// Application startting point which takes choice from to decide flow of program
        /// </summary>
        public static void StartFunction()
        {
            char choice;
            bool val;

            Console.WriteLine("---Welcome to Encode String Application--- \n ");
            Console.WriteLine("---Press [Y] or [y] to Check Predifned string output else press any key--- \n ");
            // use of Char.TryParse() method
            val = Char.TryParse(Console.ReadLine(), out choice);
            if (val == true)
            {
                if (choice == 'y' || choice == 'Y')
                    OuptputForDefinedStrings();
                else
                    GetString();
            }
            else
                Console.WriteLine("--You have entered wrong choice-- \n ");
        }

        /// <summary>
        /// Print output for predefined strings.
        /// </summary>
        static void OuptputForDefinedStrings()
        {            
            string modifiedString;

            string[] definedString = new string[]
               { "Hello World! 1234",
                "123B456",
                "Have you tried turning it off and on again?",
                "The quick brown fox jumps over the lazy dog",
                "Why haven't you finished the exercise yet?” said Nate.",
                "You've never heard of the Millennium Falcon? It's the ship that made the Kessel Run in less than 12 parsecs.",
                "The one from the village, FN2187"
               };
            Console.WriteLine("---Please find output for already given strings as per the document--- \n ");

            foreach (string actualString in definedString)
            {
                modifiedString = EncodeString(actualString.ToLower());
                PrintOutput(actualString, modifiedString);
                Console.WriteLine();
            }

            ExitFunction();

        }

        /// <summary>
        /// Print output for given string 
        /// </summary>
        static void GetString()
        {
            string actualString;
            string modifiedString;
            
            Console.WriteLine("\n Please Enter the string : ");
            actualString = Console.ReadLine();
            if (actualString.Length > 300)
                Console.WriteLine("\n Please Enter the string has length <= 300 : ");
            else
            {
                modifiedString = EncodeString(actualString.ToLower());
                PrintOutput(actualString, modifiedString);
            }
            ExitFunction();
        }

        /// <summary>
        /// Business logic to convert characters as per the business requirements
        /// • Replace Vowels with numbers: a -> 1, e -> 2, i -> 3, o -> 4, and u -> 5
        ///• Consonants are replaced with previous letter: b -> a, c -> b, d -> c, etc.
        ///• y is replaced with space
        ///• space is replaced with y
        ///• Numbers are replaced with their reverse: 1 -> 1, 23 -> 32, 1234 -> 4321
        ///• Other characters remain unchanged(punctuation, etc.)
        ///• All output should be lower case, regardless of input case ("Hello World" should produce the same result as "hello world")
        /// </summary>
        /// <param name="actualString"></param>
        /// <returns></returns>
        static string EncodeString(string actualString)
        {
           
            string vowels = "aeiou";
            Dictionary<char, char> dictTable = new Dictionary<char, char> { { 'a', '1' }, { 'e', '2' }, { 'i', '3' }, { 'o', '4' }, { 'u', '5' },
            { 'y', ' ' }, { ' ', 'y' }};

            var replacedString = Regex.Replace(actualString, @"\d+", m => new string(m.Value.Reverse().ToArray()));

            StringBuilder s = new StringBuilder();
            foreach(char c in replacedString.ToString())
            {
                char modifiedChar = ' ';
                int i = c;
                if (i >= 48 && i <= 57)
                {
                    modifiedChar = c;
                }
                else
                {
                    if (vowels.IndexOf(c.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0)
                    {
                        if (dictTable.ContainsKey(c))
                            modifiedChar = dictTable[c];
                    }
                    else 
                    {
                        if (dictTable.ContainsKey(c))
                            modifiedChar = dictTable[c];
                        else if (Char.IsLetter(c))
                            modifiedChar = (char)(((int)c) - 1);
                        else
                            modifiedChar = c;
                    }
                }
                s.Append(modifiedChar.ToString());
            }

            return s.ToString();


        }
        /// <summary>
        /// Print output for actual string and modified string to user
        /// </summary>
        /// <param name="actualString"></param>
        /// <param name="modifiedString"></param>
        static void PrintOutput(string actualString,string modifiedString)
        {
            Console.WriteLine("Actual String = " + actualString);
            Console.WriteLine("modifiedString String = " + modifiedString);
        }
        /// <summary>
        /// Provides a way to exit from an application based on user's choice
        /// </summary>
        static void  ExitFunction()
        {
            Console.Write("Press any key to continue else <Enter> to exit... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                GetString();
                Console.Write("Press any key to continue else <Enter> to exit... ");
            }
        }
       

        #endregion
    }
}
