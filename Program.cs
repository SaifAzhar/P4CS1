// See https://aka.ms/new-console-template for more information

namespace P4CS
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            Menu();
        }

        
        public static void Menu()
        {
            int userInput = 0;

            do
            {
                
                Console.WriteLine("P4CS Mini Applications");
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
                    case 1: KeepCounting();
                        break;
                    case 2: SQRT();
                        break;
                    case 3: EncryptText();
                        break;
                    case 4: DecryptText();
                        break;
                }
                
            } while (userInput != 9); 
            
        }
        
        
        
        public static void KeepCounting()
        {
            Console.WriteLine("Welcome to keep counting");
            Console.WriteLine("------------------------");
            Console.WriteLine("You will be presented with 10 arithmetic questions.  After the first question, the left-hand operand is the result of the previous addition.");

            Random num1 = new Random();
            Random num2 = new Random();
            Random num3 = new Random();
            string operation = "";
            int correctAnswer = 0;
            int correctAnswerCount = 0;
            int useranswer = 0;
            int number1 = 0; 
            

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
                else{
                    Console.WriteLine("Incorrect answer");
                }
    
    
    
            }
  		
            Console.WriteLine("You got " + correctAnswerCount + " out of 10 questions right");
        }

        public static void SQRT()
        {
            Console.WriteLine("sqrt");
        }

        public static void EncryptText()
        {
            Console.WriteLine("ENC");
        }

        public static void DecryptText()
        {
            Console.WriteLine("Decrypt");
        }
        
       
    }
}


