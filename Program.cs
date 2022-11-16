// See https://aka.ms/new-console-template for more information
// push code to github

using System.Diagnostics;

namespace P4CS
{
    class Program
    {
        public static void Main(string[] args)
        {
            Menu(); // Allows the menu to show when ran
        }

        public static void Menu()
        {
            int userInput = 0;

            do
            {
                Console.WriteLine(
                    "P4CS Mini Applications"); // These lines simply print out the options for the user to choose from
                Console.WriteLine("----------------------");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1) Keep counting");
                Console.WriteLine("2) Square root calculator");
                Console.WriteLine("3) Encrypt text (Caesar cipher)");
                Console.WriteLine("4) Decrypt text (Caesar cipher)");
                Console.WriteLine("9) Quit");

                Console.WriteLine("Please enter option: ");
                userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        KeepCounting(); // when the user makes their choice, the switch case opens the method that correlates to the case chosen
                        break;
                    case 2:
                        SQRT();
                        break;
                    case 3:
                        EncryptText();
                        break;
                    case 4:
                        DecryptText();
                        break;
                }
            } while (userInput != 9);
        }

        public static void KeepCounting()
        {
            Console.WriteLine("Welcome to keep counting");
            Console.WriteLine("------------------------");
            Console.WriteLine(
                "You will be presented with 10 arithmetic questions.  After the first question, the left-hand operand is the result of the previous addition.");

            Random num1 = new Random();
            Random num2 = new Random();
            Random num3 = new Random();
            string operation = "";
            int correctAnswer = 0;
            int correctAnswerCount = 0;
            int useranswer = 0;
            int number1 = 0; // set to 0. This value is later changed within the loop when a random number is generated
            var timer = new Stopwatch();
            timer.Start();

            for (int i = 1; i < 11; i++)
            {
                if (i == 1)
                {
                    number1 = num1.Next(1, 11); // randomly generates a number for the first operand   
                }
                else
                {
                    number1 = correctAnswer;
                }

                int number2 = num2.Next(1, 11);
                int PorN = num3.Next(1, 3); // Positive or negative - Coin flip to determine whether it will be a + or -


                if (PorN == 1)
                {
                    operation = "+";
                    correctAnswer = number1 + number2;
                }
                else
                {
                    operation = "-";
                    correctAnswer = number1 - number2;
                }

                Console.WriteLine("Question " + i + ": " + number1 + " " + operation + " " + number2 + " = ");
                useranswer = int.Parse(Console.ReadLine());

                if (useranswer == correctAnswer)
                {
                    Console.WriteLine("Correct answer!");
                    correctAnswerCount++;
                }
                else
                {
                    Console.WriteLine("Incorrect answer");
                }
            }

            timer.Stop();

            TimeSpan timeTaken = timer.Elapsed;
            string totalTime = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            Console.WriteLine(totalTime);
            Console.WriteLine("You got " + correctAnswerCount + " out of 10 questions right");
        }

        static void SQRT()
        {
            Console.WriteLine("Square Root Calculator");
            Console.WriteLine("--------------------");


            Console.WriteLine("Please enter a positive integer: ");
            int userInteger = int.Parse(Console.ReadLine());

            Console.WriteLine("How many decimal places do you want the solution to be calculated to?");
            int userChoiceDecimalPlace = int.Parse(Console.ReadLine());

            double upperBound = userInteger;
            double lowerBound = 1;
            double average = 0;
            
            Console.WriteLine("Loop SQRT");

            while (true)
            {
                average = ((upperBound + lowerBound) / 2);
                average *= average;

                if (average > userInteger)
                {
                    upperBound = average;
                }
                else if (average < userInteger)
                {
                    lowerBound = average;
                }
                
                Console.WriteLine(average);
                
                if ((upperBound - lowerBound) < userChoiceDecimalPlace)
                {
                    break;
                }
            } 
        }

        static void EncryptText()
        {
            // convert acceptedSymbols to char[] 'A' 'B' 
            // string to char[]
            char[] acceptedSymbols =
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' '
            }; // array to contain all the symbols which we can accept

            Console.WriteLine("Encrypt Text");
            Console.WriteLine("------------");
            Console.WriteLine("Please enter text to encrypt: ");
            string userInput = Console.ReadLine();
            Console.WriteLine("Please enter key between 1 and 36: ");
            int key = int.Parse((Console.ReadLine()));

            while (true)
            {
                if (key > 0 && key < 37) break;
                Console.WriteLine("Please enter a number within the valid range: ");
                key = int.Parse((Console.ReadLine()));
            }


            char[] charArray = userInput.ToUpper().ToCharArray();
            string encrypted = "";


            for (int i = 0; i < charArray.Length; i++)
            {
                char currentCharacter = charArray[i];


                if (acceptedSymbols.Contains(currentCharacter))
                {
                    char newChar = ' ';
                    int index = Array.IndexOf(acceptedSymbols, currentCharacter);
                    index += key;
                    newChar = acceptedSymbols[index];
                    encrypted += newChar;
                }
                else
                {
                    Console.WriteLine("Invalid input text");
                    break;
                }
            }


            Console.WriteLine("Encrypted text: " + encrypted);
        }


        static void DecryptText()
        {
            char[] acceptedSymbols =
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' '
            };

            Console.WriteLine("Decrypt text");
            Console.WriteLine("-------------");
            Console.WriteLine("Please enter encrypted text to decrypt: ");
            string userInput = Console.ReadLine();
            Console.WriteLine("Please enter a shift (between 1 and 36");
            int key = int.Parse(Console.ReadLine());

            while (true)
            {
                if (key > 0 && key < 37) break;
                Console.WriteLine("Please enter a number within the valid range: ");
                key = int.Parse((Console.ReadLine()));
            }


            char[] charArray = userInput.ToUpper().ToCharArray();
            string decrypted = "";


            for (int i = 0; i < charArray.Length; i++)
            {
                char currentCharacter = charArray[i];

                if (acceptedSymbols.Contains(currentCharacter))
                {
                    char newChar = Convert.ToChar(currentCharacter - key);
                    decrypted += newChar;
                }
                else
                {
                    Console.WriteLine("Invalid input text");
                    break;
                }
            }


            Console.WriteLine("Decrypted text: " + decrypted);
        }
    }
}