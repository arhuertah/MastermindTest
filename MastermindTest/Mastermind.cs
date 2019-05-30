using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastermindTest
{
    public class Mastermind
    {
        /// <summary>
        /// Correct Answer
        /// </summary>
        public int[] Answer { get; set; }

        /// <summary>
        /// Number of attempts
        /// </summary>
        public int Attempts { get; set; }

        /// <summary>
        /// Winner flag
        /// </summary>
        public bool Won { get; set; }

        public int NumberOfMinus { get; set; }

        public int NumberOfAccerts { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Mastermind()
        {
            Attempts = 0;
            Answer = new int[4];
        }

        /// <summary>
        /// Generates randomly the correct answer
        /// </summary>
        /// <returns></returns>
        public string GenerateAnswer()
        {
            var random = new Random();

            //Assign each element with random number
            for (int i = 0; i < Answer.Length; i++)
            {
                Answer[i] = random.Next(1, 6);
            }

            //Convert int Array to String
            var returnAnswer = String.Join("", Answer.Select(x => x.ToString()).ToArray());

            return returnAnswer;
        }

        /// <summary>
        /// Validates User digits submited
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        public bool CheckUserInput(string userInput)
        {
            //Validate if userInput is a number
            int number = 0;
            var isOk = int.TryParse(userInput, out number);

            //Validates userInput length
            isOk = userInput.Length == 4 ? true : false;

            //Converts the string into int array for validations
            var tryAnswer = userInput.ToCharArray().Select(s => int.Parse(s.ToString()));

            //validates answer boundaries
            foreach (int digit in tryAnswer)
            {
                if (digit <= 0 || digit > 6)
                {
                    isOk = false;
                }
            }

            return isOk;            
        }

        /// <summary>
        /// Assuming string is validated we will check the result from userInput
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        public bool Guessed(string userInput)
        {
            this.NumberOfAccerts = 0;
            this.NumberOfMinus = 0;
            var tryAnswer = userInput.ToCharArray().Select(s => int.Parse(s.ToString())).ToArray();

            for (int index = 0; index < tryAnswer.Count(); index++)
            {
                if (Answer.Contains(tryAnswer[index]))
                {
                    this.NumberOfMinus++;
                }

                if (Answer[index] == tryAnswer[index])
                {
                    this.NumberOfAccerts++;
                    this.NumberOfMinus--;
                }
            }

            if (this.NumberOfAccerts == 4)
                return true;

            return false;
        }
    }
}
