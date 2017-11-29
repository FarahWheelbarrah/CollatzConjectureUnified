using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        public static void Main(string[] args)
        {
            String choice;
            help();
            while ((choice = readString("Choice (a/b/h/x):")) != "x")
            {
                switch (choice)
                {
                    case "a": performCollatzConjecture(); break;
                    case "b": countCollatzConjecture(); break;
                    case "h": help(); break;
                    default: help(); break;

                    
                }
            }
        }

        public static void performCollatzConjecture()
        {
            String input;
            ulong number;
            Console.WriteLine("Enter \"back\" to return to the main menu");
            while ((input = readString("Please enter an integer greater than 1:")) != "back")
            {
                if ((!UInt64.TryParse(input, out number) || number == 0 || number == 1))
                    {
                    Console.WriteLine("ERROR - Invalid input");
                    }
                else
                {
                    performCC(input, number);
                }
            }
        }

        public static void performCC(String input, ulong number)
        {
            ulong count = 0;
            ulong max = 0;

            while (number != 1)
            {

                if (number % 2 != 0)
                {
                    number = number * 3 + 1;
                }
                else
                {
                    number = number / 2;
                }


                ++count;

                if (number > max)
                    max = number;

                }

            Console.WriteLine("The number " + input + " reduced to 1 in " + count + " " + pluralorNot("generation", count));
            Console.WriteLine("The largest value in the sequence was " + max);
            count = 0;
            max = 0;

        }

        public static void countCollatzConjecture()
        {
            String input;
            ulong inputcount;
            Console.WriteLine("Enter \"back\" to return to the main menu");
            while ((input = readString("Please enter a generation value greater than 0:")) != "back")
            {
                if (!UInt64.TryParse(input, out inputcount) || inputcount == 0)
                {
                    Console.WriteLine("ERROR - Invalid input");
                }
                else
                {
                    performCountCC(input, inputcount);
                }

            }
        }

        public static void performCountCC(String input, ulong inputcount)
        {
            ulong number;
            ulong count = 0;
            bool nonumbersfound = true;

            for (number = 2; number <= 5000000; number++)
            {

                ulong copyofnumber = number;

                while (copyofnumber != 1)
                {

                    if (copyofnumber % 2 != 0)
                    {
                        copyofnumber = copyofnumber * 3 + 1;
                    }
                    else
                    {
                        copyofnumber = copyofnumber / 2;
                    }


                    ++count;

                }



                if (count == inputcount)
                {
                    nonumbersfound = false;
                    break;
                }

                count = 0;



            }
            if (nonumbersfound)
                Console.WriteLine("No number found from 2 to 5000000 that takes " + inputcount + " " + pluralorNot("generation", inputcount) + " to reduce to 1");
            else
                Console.WriteLine(number + " is the first number from 2 to 5000000 that takes " + inputcount + " " + pluralorNot("generation", inputcount) + " to reduce to 1");



        }

        public static void help()
        {
            Console.WriteLine("--HELP--");
            Console.WriteLine("*The Collatz Conjecture*");
            Console.WriteLine("Enter 'a' to perform the Collatz Conjecture on a given number");
            Console.WriteLine("Enter 'b' to find out the first number from 2 to 5000000 that takes a given number of generation(s) to reduce to 1 through the Collatz Conjecture");
            Console.WriteLine("Enter 'h' to see this menu again");
            Console.WriteLine("Enter 'x' to exit the program");

        }

        public static String readString(String prompt)
        {
            Console.Write(prompt + " ");
            String input = Console.ReadLine();
            return input;
        }

        public static String pluralorNot(String word, ulong count)
        {
            if (count > 1)
                return word + "s";
            else
                return word;
        }
        

        
    }
}

        
    





