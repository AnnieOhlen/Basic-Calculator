
/*
In a few places Y/N? have been used, meaning YES/NO?.
It has been shorted to make testing the program faster with just an y or n for the user.
*/

//Styling of the console:
Console.BackgroundColor = ConsoleColor.DarkGray;
Console.Clear();
Console.ForegroundColor = ConsoleColor.Black;

//Dictionary instead of list in order to connect two types:
Dictionary<string, int> calculationsList = new Dictionary<string, int>(2);

//Bool true for the program running:
bool programRunning = true;
while (programRunning)
{
    //Welcoming to the calculator, some random stuff added for styling.
    Console.WriteLine("\n< § ~ { The Basic Calculator } ~ § >");
    Console.WriteLine("\nI bid thee welcome to a simple calculator! \n");

    //Numbered meny:
    Console.WriteLine("[1] < Calculation of two numbers (integers) >");
    Console.WriteLine("[2] < Show previous results >");
    Console.WriteLine("[3] < Clear the results >");
    Console.WriteLine("[4] < Exit the program >");

    //Tryparse for the above meny choice with the switch default to inform if not 1-4 have been entered:
    Int32.TryParse(Console.ReadLine(), out int menyChoice);
    switch (menyChoice)
    {
        case 1:
            /* Down below  in case 1 are the calculations, I believe there is a better way to do this as it is a repeatable code for the most part.
            I wrote the following code as I thought it easy for me to understand if something went wrong, logics, and also easy to read.
            */
            try
            {//Used question mark for the string to avoid null warnings (catch at the end of try).
                Console.WriteLine("\nPlease enter the first number: ");
                string? firstNumberText = Console.ReadLine();
                int firstNumber = Convert.ToInt32(firstNumberText);

                //This was tricky with the operators. First I made it more difficult than neccesary (converting string to char) but realized it was not neccesary.
                Console.WriteLine("\nChose an operator ( + - * / ): ");
                string? operatorChoice = Console.ReadLine();

                Console.WriteLine("\nPlease enter the second number: ");
                string? secondNumberText = Console.ReadLine();
                int secondNumber = Convert.ToInt32(secondNumberText);

                //A string to gather the seperate inputs from the user for the one string in Dictionary:
                string userCalculationInput = $"{firstNumberText} {operatorChoice} {secondNumberText}";
                //An int for the result to add to the one int in Dictionary:
                int calculatedResult = 0;

                /*
                Several if statements for the for operators used.
                Tried to make the code cleaner by having the calculation in the WriteLine to the Console.
                */
                if (operatorChoice == "+")
                    Console.WriteLine($"\nInput: {firstNumber} {operatorChoice} {secondNumber}. Result: {calculatedResult = firstNumber + secondNumber} ");

                if (operatorChoice == "-")
                    Console.WriteLine($"\nInput: {firstNumber} {operatorChoice} {secondNumber}. Result: {calculatedResult = firstNumber - secondNumber} ");

                if (operatorChoice == "*")
                    Console.WriteLine($"\nInput: {firstNumber} {operatorChoice} {secondNumber}. Result: {calculatedResult = firstNumber * secondNumber} ");

                if (operatorChoice == "/")
                    Console.WriteLine($"\nInput: {firstNumber} {operatorChoice} {secondNumber}. Result: {calculatedResult = firstNumber / secondNumber} ");

                //The string and the int gets added to Dictionary.
                calculationsList.Add(userCalculationInput, calculatedResult);
                Console.ReadKey();
            }
            catch
            {
                //Catch for errors, incorrect inputs, also ask the user if they would like to retry.
                Console.WriteLine($"Error: Incorrect input. \nRetry? Y/N?");
                string? retryCase1 = Console.ReadLine();
                if (retryCase1?.ToLower() == "y")
                    goto case 1;

                else if (retryCase1?.ToLower() != "y")
                            //You will be returned to the meny. WriteLine and then a 2 second delay for break? Possible?
                            break;
            }
            break;

        case 2:
            //A somple case for showing Dictionary as input and result list to the user.
            Console.WriteLine("\nShow the previous results of the calculator? Y/N?");
            string? showPreviousResults = Console.ReadLine();

            if (showPreviousResults?.ToLower() == "y")
            {
                //The foreach could be changed out for a for loop but I found the foreach less cluttered in this case.
                int calculationOrder = 1;
                foreach (var item in calculationsList)
                {
                    Console.WriteLine($"Calculation #{calculationOrder++}: " + item.Key + " = " + item.Value + "");
                }
                Console.ReadKey();
            }

            else if (showPreviousResults?.ToLower() != "y") //"You will be returned to the meny." WriteLine and then a 2 second delay for break? An idea.
                break;
            break;

            //I decided to add the possibilty for the user to clear Dictionary without restarting the program:
        case 3:
            Console.WriteLine("\nIf you clear the results you will not be able to get them back. \nClear the results? Y/N?");
            string? clearResultsChoice = Console.ReadLine();

            if (clearResultsChoice?.ToLower() == "y")
            {
                calculationsList.Clear();
                Console.WriteLine("\nThe results have been cleared. \nPress a key to return to the meny.");
                Console.ReadKey();
            }

            else if (clearResultsChoice?.ToLower() != "y")
            {
                Console.WriteLine("\nThe results will not be cleared. \nPress a key to return to the meny.");
                Console.ReadKey();
            }
            break;

            //Option to exit the program while making sure that the user do not accidently exit:
        case 4:
            Console.WriteLine("\nIf you exit the program the calculations will not be saved. \nExit the program? Y/N?");
            string? exitYesNo = Console.ReadLine();

            if (exitYesNo?.ToLower() == "y")
                programRunning = false;

            else if (exitYesNo?.ToLower() != "y")
                break;
            break;

        default:
            Console.WriteLine("\nYou have to chose between meny choices 1 - 3! \nPress a key and then try again.");
            Console.ReadKey();
            break;
    }
    //To clear the console between uses.
    Console.Clear();
}