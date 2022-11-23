// See https://aka.ms/new-console-template for more information
// push code to github

using System.Diagnostics;

namespace P4CS
{
    class Program
    {
        /*
         TESTING FOR SQUARE ROOT CALCULATOR
         ----------------------------------
         Test input = 45
         Decimal places = 5
         Expected output = 6.70820
         Actual output = 6.70821
         Reasoning = Testing to 5 decimal places
         */

        public static void Main(string[] args)
        {
            Menu();
            // Allows the menu to show when ran
        }

        static void Menu()
        {
            int userInput = 0;

            do
            {
                Console.WriteLine("P4CS Mini Applications"); // These lines simply print out the options for the user to choose from
                Console.WriteLine("----------------------");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1) Keep counting");
                Console.WriteLine("2) Square root calculator");
                Console.WriteLine("3) Encrypt text (Caesar cipher)");
                Console.WriteLine("4) Decrypt text (Caesar cipher)");
                Console.WriteLine("9) Quit");

                Console.WriteLine("Please enter option: ");

                try //checking to see if user input is an int. If not then we spit out an error message
                {
                    userInput = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                switch (userInput) //switch case used to allow user to choose which method (mini app) they want to access
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
            } while (userInput != 9); //pressing 9 allows them to end the program
        }

        static void KeepCounting()
        {
            Console.WriteLine("Welcome to keep counting");
            Console.WriteLine("------------------------");
            Console.WriteLine(
                "You will be presented with 10 arithmetic questions.  After the first question, the left-hand operand is the result of the previous addition.");

            Random num1 = new Random(); //generates random number for the first question
            Random num2 = new Random(); //generates second random number (which will be used for all the questions
            Random num3 = new Random();
            
            string operation = "";
            int correctAnswer = 0;
            int correctAnswerCount = 0;
            int useranswer = 0;
            int number1 = 0; // set to 0. This value is later changed within the loop when a random number is generated
            
            var timer = new Stopwatch(); //initialise timer to time the duration of the mini app
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

                int number2 = num2.Next(1, 11); // second random number given its scope
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

                try // checking to see if user input is an int. If not then we spit out an error message
                {
                    useranswer = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine((e.Message));
                }

                if (useranswer == correctAnswer)
                {
                    Console.WriteLine("Correct answer!");
                    correctAnswerCount++; // increment counter
                }
                else
                {
                    Console.WriteLine("Incorrect answer");
                }
            }

            timer.Stop();

            TimeSpan timeTaken = timer.Elapsed;
            string totalTime = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            Console.WriteLine(totalTime); // displaying time taken to complete
            Console.WriteLine("You got " + correctAnswerCount + " out of 10 questions right");
        }

        static void SQRT()
        {
            Console.WriteLine("Square Root Calculator");
            Console.WriteLine("--------------------");
            Console.WriteLine("Please enter a positive integer: ");

            int userInteger = 0;
            int userChoiceDecimalPlace = 0;

            try // checking to see if user input is an int. If not then we spit out an error message
            {
                userInteger = int.Parse(Console.ReadLine());

                Console.WriteLine("How many decimal places do you want the solution to be calculated to?");
                userChoiceDecimalPlace = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            double precision = ((userChoiceDecimalPlace / userChoiceDecimalPlace) /
                                (Math.Pow(10, userChoiceDecimalPlace))); //formula to determine precision 

            double upperBound = userInteger * 2; // setting upper bound
            double lowerBound = 1; //setting lower bound (purposely made them very broad so they can be narrowed down during run time

            while ((upperBound - lowerBound) > precision)
            {
                double average = ((upperBound + lowerBound) / 2);
                double averageSquared = average * average;

                if (averageSquared > userInteger)
                {
                    upperBound = average; //reassigning upper bound if the average is higher than the number they originally gave
                }
                else if (averageSquared < userInteger)
                {
                    lowerBound = average; //reassigning lower bound if the average is lower than the number they originally gave
                }

                if ((upperBound - lowerBound) <
                    precision) // checks to see if the difference between the bounds is smaller than the precision. If it is we know to conclude the program.
                {
                    Console.WriteLine("The square root of " + userInteger + " to " + userChoiceDecimalPlace + " decimal places is " + Math.Round(average, userChoiceDecimalPlace));
                    break;
                }
            }
        }

        static void EncryptText()
        {
            char[] acceptedSymbols =
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' '
            }; // array to contain all the symbols which we can accept

            Console.WriteLine("Encrypt Text");
            Console.WriteLine("------------");
            Console.WriteLine("Please enter text to encrypt: ");

            string userInput = "";
            int key = 0;

            try // checking to see if user input is an int. If not then we spit out an error message
            {
                userInput = Console.ReadLine();
                Console.WriteLine("Please enter key between 1 and 36: ");
                key = int.Parse((Console.ReadLine()));

                while (true) // making sure their input for their key is within the bounds of 1 and 36 and returning a message if it is not
                {
                    if (key > 0 && key < 37) break;
                    Console.WriteLine("Please enter a number within the valid range: ");
                    key = int.Parse((Console.ReadLine()));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            char[] charArray = userInput.ToUpper().ToCharArray(); //creating a new array for the chars to be stored. Storing them all as capitals
            string encrypted = "";


            for (int i = 0; i < charArray.Length; i++)
            {
                char currentCharacter = charArray[i];


                if (acceptedSymbols.Contains(currentCharacter)) // checking to see if the char is contained in the accepted symbols array
                {
                    char newChar = ' ';
                    int index = Array.IndexOf(acceptedSymbols, currentCharacter); // finds index of the current char in the array
                    index += key; // adjusts the index to find the char in the new index position 
                    if (index > 37)
                    {
                        index = index % 37; // returns the index to the beginning of the array
                    }

                    newChar = acceptedSymbols[index]; //retrieves the char in the new index position
                    encrypted += newChar; //adds the char to the encrypted message
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
            int key = 0;
            string userInput = "";

            Console.WriteLine("Decrypt text");
            Console.WriteLine("-------------");
            Console.WriteLine("Please enter encrypted text to decrypt: ");

            try // checking to see if user input is an int. If not then we spit out an error message
            {
                userInput = Console.ReadLine();
                Console.WriteLine("Please enter a shift between 1 and 36");
                key = int.Parse(Console.ReadLine());


                while
                    (true) // making sure their input for their key is within the bounds of 1 and 36 and returning a message if it is not
                {
                    if (key > 0 && key < 37) break;
                    Console.WriteLine("Please enter a number within the valid range: ");
                    key = int.Parse((Console.ReadLine()));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            char[]
                charArray = userInput.ToUpper()
                    .ToCharArray(); //creating a new array for the chars to be stored. Storing them all as capitals
            string decrypted = "";


            for (int i = 0; i < charArray.Length; i++)
            {
                char currentCharacter = charArray[i];


                if (acceptedSymbols.Contains(currentCharacter)) // checking to see if the char is contained in the accepted symbols array
                {
                    char newChar = ' ';
                    int index = Array.IndexOf(acceptedSymbols, currentCharacter); // finds index of the current char in the array
                    index -= key; // adjusts the index to find the char in the new index position

                    if (index < 0) //if the index is lower than 0, then we ABS the value to make it positive
                    {
                        index = Math.Abs(index);
                        int newIndex = Array.IndexOf(acceptedSymbols, currentCharacter); //we find the index of the current character we are trying to decrypt
                        index -= newIndex; //find the difference between the current position and index
                        index = 37 - index; //subtract the difference from 37 to find the updated index of the character from the back end of the array
                    }

                    newChar = acceptedSymbols[--index]; //retrieves the char in the new index position
                    decrypted += newChar; //adds char to the decrypted message
                }
                else
                {
                    Console.WriteLine("Invalid input text"); //otherwise we throw an error message
                    break;
                }
            }


            Console.WriteLine("Decrypted text: " + decrypted);
        }
    }
}