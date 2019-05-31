using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastermindTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mastermind Test");
            Console.WriteLine("\nInstructions: Enter 4 digits");
            Console.WriteLine("\nA minus (-) sign will be displayed for every digit that is correct " +
                "\nbut in the wrong position, and a plus(+) sign should be printed for every digit that " +
                "\nis both correct and in the correct position.\n");

            var masterMindGame = new Mastermind();

            //Generate an answer and save at console to be displayed at the end
            var answer = masterMindGame.GenerateAnswer();

            //For testing purposes
            //Console.WriteLine($"Correct Answer {answer}");

            do
            {
                Console.WriteLine($"Introduce your 4 digits for attempt No." +
                    $"{masterMindGame.Attempts + 1} and click Enter");

                var userInput = Console.ReadLine();

                if (masterMindGame.CheckUserInput(userInput))
                {                    
                    masterMindGame.Attempts++;

                    if (masterMindGame.Guessed(userInput))
                    {
                        masterMindGame.Won = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine(new string('+', masterMindGame.NumberOfAccerts));
                        Console.WriteLine(new string('-', masterMindGame.NumberOfMinus));                        
                    }
                }
                else
                {
                    Console.WriteLine("Please introduce only numbers from 1 to 6");
                }

            } while (masterMindGame.Attempts < 10);

            if (masterMindGame.Won)
            {
                Console.WriteLine("Congratulations!!! You are Mastermind Winner!");
            }
            else
            {
                Console.WriteLine($"You lost! the correct answer is: {answer}");
            }

            Console.Read();
        }
    }
}
