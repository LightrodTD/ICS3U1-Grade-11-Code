//Author: Mehdi Syed
//Project Name: PASS3
//File Name: Program.cs
//Creation Date: ‎‎Oct. 28, ‎2019
//Modified Date: Dec. 10, 2019
//Description: This program accomplishes string analysis based on user input.
//             Depending one which if the 10 tasks the user chooses, each task will do some manipulation upon the
//             the string, and output its result. Then, if he/she wants to, the user can do some manipulation upon that result.
//             There are many oppurtunities for what the user can accomplish with any given string input.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASS3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Store the user entered options for phrase and menu
            string userString = "";
            string option = "";

            //Store the value after processing the string
            string result = "";

            //Keep looping until the X is entered
            while (option.ToUpper() != "X")
            {
                //Begin every iteration by showing the menu and getting a menu option
                DisplayMenu(userString, result);
                option = Console.ReadLine();

                //clear the processing result for new processing
                result = "";

                //Perform the desired string analysis based on the option and current phrase
                switch (option)
                {
                    case "1":
                        userString = GetPhrase();
                        break;
                    case "2":
                        result = GetNumWords(userString);
                        break;
                    case "3":
                        result = CharacterCount(userString);
                        break;
                    case "4":
                        userString = ReversePhrase(userString);
                        break;
                    case "5":
                        userString = ReverseWords(userString);
                        break;
                    case "6":
                        userString = RemoveFirstOccurance(userString);
                        break;
                    case "7":
                        userString = RemoveLastOccurance(userString);
                        break;
                    case "8":
                        result = IsPalindrome(userString);
                        break;
                    case "9":
                        result = BinToDecConversion(userString);
                        break;
                    case "10":
                        result = DecToBinConversion(userString);
                        break;
                    default:
                        //An invalid menu option was chosen
                        result = "Invalid Menu Option";
                        break;
                }
            }

            //End the program
            Console.WriteLine("\nHave a nice day!");
            Console.ReadLine();
        }

        //PRE: userString and result hold the current state of the phrase and processing results
        //POST: The state of the program and menu will be displayed to the user on a clean screen
        //DESC: Display the menu to the user
        private static void DisplayMenu(string userString, string result)
        {
            //Clear the screen and display the program's current state
            Console.Clear();
            Console.WriteLine("Previous Result: " + result);
            Console.WriteLine("Current Phrase: " + userString);
            Console.WriteLine("");

            //Display the collection of menu options
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Enter a new phrase");
            Console.WriteLine("2. Count the number of words in the phrase");
            Console.WriteLine("3. Count the quantity of a chosen character that are in the phrase");
            Console.WriteLine("4. Reverse the phrase");
            Console.WriteLine("5. Reverse the words of the phrase");
            Console.WriteLine("6. Remove the first occurance of a character from the phrase");
            Console.WriteLine("7. Remove the last occurance of a character from the phrase");
            Console.WriteLine("8. Is the phrase a palindrome (ignoring spaces)?");
            Console.WriteLine("9. Convert a phrase of binary bits into its base-10 value");
            Console.WriteLine("10. Convert a base-10 numeric phrase into its base-2 binary value");
            Console.WriteLine("X. Exit");

            //Prompt the user for an option
            Console.Write("\nOption: ");
        }

        //PRE: text is a string
        //POST: returns true if text is made up completely of 1's and 0's
        //DESC: Determine if text is a valid binary number
        private static bool IsBinaryString(string text)
        {
            //loop through each character of text
            for (int i = 0; i < text.Length; i++)
            {
                //If the current character is not a 1 or a 0 then it is not
                //a valid binary number, so return false
                if (text[i] != '1' && text[i] != '0')
                {
                    return false;
                }
            }

            //No character tested was invalid, therefore it is a binary number
            return true;
        }

        //PRE: text is a string
        //POST: returns true if text is made up of nothing but digits from 0 through 9
        //DESC: Determine if text is a valid decimal number
        private static bool IsDecimalString(string text)
        {
            //Loop through each character of text
            for (int i = 0; i < text.Length; i++)
            {
                //If the current caracter is not between ASCII 48 to 57 inclusive
                //it is not a valid decimal number, so return false
                if ((int)text[i] < 48 || (int)text[i] > 57)
                {
                    return false;
                }
            }

            //No character tested was invalid, therefore it is a decimal number
            return true;
        }
        //PRE: 
        //POST: returns the phrase inputted by the user
        //DESC: Asks for a phrase for string manipulation
        private static string GetPhrase()
        {
            //Clear Menu and ask for a phrase
            Console.Clear();
            Console.WriteLine("Write a Phrase:");
            string y = Convert.ToString(Console.ReadLine());
            //Return the string
            return y;
        }

        //PRE: text is a string
        //POST: return the nimber of words in the phrase
        //DESC: Find out the number of words in the phrase inputted
        private static string GetNumWords(string text)
        {
            //Integer values corresponding with characters of text
            int limit = 0;
            //Word Counter
            int word = 1;

            //While the limit is less than or equal to the text length minus 1
            while (limit <= text.Length - 1)
            {
                //If this character equals a space, add 1 to word counter
                if (text[limit] == ' ')
                {
                    word += 1;
                }
                //Increase limit by 1
                limit += 1;
            }
            //Convert word counter to string and return the output
            string x = Convert.ToString(word);
            return x;
        }

        //PRE: text is a string
        //POST: returns number of certain characters of text
        //DESC: Count the number of characters, chosen by user, in the text(phrase)
        private static string CharacterCount(string text)
        {
            //Clear menu and display current phrase
            Console.Clear();
            Console.WriteLine("Current Phrase: " + text);
            //Ask and retrieve which character to count
            Console.WriteLine("What character should I count?");
            char str = Convert.ToChar(Console.ReadLine());

            //Integer values corresponding with characters of text
            int limit = 0;
            //Character Counter
            int count = 0;

            //While the limit is less than or equal to the text length minus 1
            while (limit <= text.Length - 1)
            {
                //If certain character is equal to choosen character(from input), add 1 to counter
                if (text[limit] == str)
                {
                    count += 1;
                }
                //Increase limit by 1
                limit += 1;
            }
            //Convert count to string, and return output plus a secondary string
            string x = Convert.ToString(count);
            string y = "Count -> " + x;
            return y;
        }

        //PRE: text is a string
        //POST: return reversed-phrase
        //DESC: Reverse every single character
        private static string ReversePhrase(string text)
        {
            //Set reverse to nothing and textLength to the text Length minus 1
            string reverse = "";
            int textLength = text.Length - 1;

            //While the textLength is greater than or equal to 0
            while (textLength >= 0)
            {
                //Add the current character to reverse and decrease textLength by 1
                reverse += text[textLength];
                textLength -= 1;
            }
            //Retrun the phrase reverse
            return reverse;
        }

        //PRE: text is a string
        //POST: return reversed words
        //DESC: Reverse the order of words, but not the words themselves
        private static string ReverseWords(string text)
        {
            //reverse the given string
            string reversed = ReversePhrase(text);
            //Integer values corresponding with characters of text
            int limit = 0;
            //Create an array for each word
            string[] texts = new string[Convert.ToInt32(GetNumWords(text)) + 2];
            //Set the final phrase to nothing
            string finalPhrase = "";
            //Create a variable for space
            string space = " ";
            //Integer values corresponding with the number of words
            int n = 0;
            //While limit is less than or equal to the length of revered minus 1
            while (limit <= reversed.Length - 1)
            {
                //If a space is found, reverse the word, and add the current word(texts[]) to final phrase plus space
                //Add 1 to n and limit
                if (reversed[limit] == ' ')
                {
                    finalPhrase += ReversePhrase(texts[n]) + space;
                    n += 1;
                    limit += 1;
                }
                //Else
                else
                {
                    //If limit is equal to final letter, 
                    //add final letter to current text, reverse text and add text to final phrase
                    if (limit == reversed.Length - 1)
                    {
                        texts[n] += Convert.ToString(reversed[limit]);
                        finalPhrase += ReversePhrase(texts[n]);
                        //Add 1 to n
                        n += 1;
                    }
                    //Add current letter to current text and increase limit by 1
                    texts[n] += Convert.ToString(reversed[limit]);
                    limit += 1;
                }
            }
            //Return final phrase
            return finalPhrase;
        }

        //PRE: text is a string
        //POS: return new phrase without the first occurence of chosen character
        //DESC: Remove the FIRST occurence of a character within a ohrase
        private static string RemoveFirstOccurance(string text)
        {
            //Clear menu and ask which character the computer should remove from the left
            Console.Clear();
            Console.WriteLine("What letter should I remove firstly from the left?");
            //Store input in type char
            char str = Convert.ToChar(Console.ReadLine());
            //Integer values corresponding with characters of text
            int limit = 0;
            //An adder, to act as limit
            int adder = 0;
            //Final phrase
            string text2 = "";
            //While the limit is less than or equal to the length of text minus 1
            while (limit <= text.Length - 1)
            {
                //If current letter is equal to chosen character
                if (text[limit] == str)
                {
                    //If adder is equal to 0, increase the limit by 1
                    if (adder == 0)
                    {
                        limit += 1;
                    }
                    //Increase adder by 1
                    adder += 1;
                }
                //Add current letter to text2 and increase limti by 1
                text2 += Convert.ToString(text[limit]);
                limit += 1;
            }
            //Return text2
            return text2;
        }

        //PRE: text is a string
        //POS: return new phrase without the last occurence of chosen character
        //DESC: Remove the LAST occurence of a character, chosen by the user, from the phrase
        private static string RemoveLastOccurance(string text)
        {
            //Clear menu and ask which character the computer should remove from the right
            Console.Clear();
            Console.WriteLine("What letter should I remove firstly from the right?");
            //Store input in type char
            char str = Convert.ToChar(Console.ReadLine());
            //Integer values corresponding with characters of text
            int limit = text.Length - 1;
            //An adder, to act as limit
            int adder = 0;
            //2 strings that hold a reversed phrase and a final phrase
            string text2 = "";
            string text3 = "";
            //While limit is greater than or equal to 0
            while (limit >= 0)
            {
                //If current letter is equal to chosen character
                if (text[limit] == str)
                {
                    //If adder is equal to 0, decrease the limit by 1
                    if (adder == 0)
                    {
                        limit -= 1;
                    }
                    //Increase adder by 1
                    adder += 1;
                }
                //Add current letter to final string and decrease limit by 1
                text2 += Convert.ToString(text[limit]);
                limit -= 1;
            }
            //Reverse the final phrase and return the output
            text3 = ReversePhrase(text2);
            return text3;
        }

        //PRE: text is a string
        //POS: returns whether or not the phrase is a palindrome
        //DESC: Checks whether or not a phrase is a palindrome or not, disregarding spaces.
        private static string IsPalindrome(string text)
        {
            //Set reverse to nothing and textLength to the text Length minus 1
            string reverse = "";
            int textLength = text.Length - 1;
            //While the textLength is greater than or equal to 0
            while (textLength >= 0)
            {
                //Add the current character to reverse and decrease textLength by 1
                reverse += text[textLength];
                textLength -= 1;
            }

            //String for spacing
            string str = " ";
            //Integer values corresponding with characters of text
            int limit = 0;
            //Create a string for the orignal text without spacing
            string text2 = "";

            //While the limit is less than or equal to the length of the lext minus 1
            while (limit <= text.Length - 1)
            {
                //If the current character is equal to a space, add 1 to the limit
                if (text[limit] == Convert.ToChar(str))
                {
                    limit += 1;
                }
                //Add the current character the text2 string and increase limit by 1
                text2 += Convert.ToString(text[limit]);
                limit += 1;
            }

            //String for spacing
            string str2 = " ";
            //Integer values corresponding with characters of text (specifically, for the reversed text)
            int limit2 = 0;
            //Create a string for the reversed text without spacing
            string text22 = "";

            //While the limit is less than or equal to the length of the reversed text minus 1
            while (limit2 <= reverse.Length - 1)
            {
                //If the current character is equal to a space, add q to the limit
                if (reverse[limit2] == Convert.ToChar(str2))
                {
                    limit2 += 1;
                }
                //Add current character to the text22 string and increase the limit by 1
                text22 += Convert.ToString(reverse[limit2]);
                limit2 += 1;
            }

            //Create a string for the result
            string x;
            //If the text22 is equal to text2, x equals to "The phrase is a palindrome"
            if (text22 == text2)
            {
                x = "The phrase is a palindrome";
            }
            //Else, x equals to "The phrase is not a palindrome"
            else
            {
                x = "The phrase is not a palindrome";
            }
            return x;
        }

        //PRE: text is a string
        //POS: return the decimal number of the binary input
        //DESC: Convert binary input to its decimal equivalent
        private static string BinToDecConversion(string text)
        {
            //Store the text as an integer
            int y;
            //A string for the result
            string z;
            //A bool type to see whether or not the text can be turned into a decimal
            bool x = IsBinaryString(text);
            //If the text can be converted, convert the text to its decimal equivalent and add it the final string
            if (x == true)
            {
                y = Convert.ToInt32(text, 2);
                z = "True Binary Number --> Deciaml: " + Convert.ToString(y);
                //Retrun the output of z
                return z;
            }
            //Else, return false
            else
            {
                return "False --> Not a proper Binary Number";
            }
        }

        //PRE: text is a string
        //POS: return the binary number of the decimal input
        //DESC: Convert decimal input to its binary equivalent
        private static string DecToBinConversion(string text)
        {
            //A bool type to see whether or not the text can be turned into a bianry
            bool x = IsDecimalString(text);
            //Store the text as an integer
            int y;
            //An integer tpye to store the remainder of the binary calculations
            int rem;
            //A string to add the final value
            string z = "";
            //If the number can be converted to binary
            if (x == true)
            {
                //Convert the text to an integer
                y = Convert.ToInt32(text);
                //While the integer is greater than 1
                while (y > 1)
                {
                    //Calculate remainder of division anf convert the result into a string
                    rem = y % 2;
                    //Add value to string
                    z += Convert.ToString(rem);
                    y = y / 2;
                }
                //Add integer the string and return the value (binary number)
                z += Convert.ToString(y);
                return "True Decimal Number --> Binary: " + z;
            }
            //Else, return a phrase stating the text does not work
            else
            {
                return "False --> Not a proper Decimal Number";
            }
        }
    }
}
