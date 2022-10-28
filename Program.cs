
//In a few places Y/N? have been used, meaning YES/NO?.
//It has been shorted to make testing the program faster with just an y or n for the user.

//Color styling of the console.
Console.BackgroundColor = ConsoleColor.DarkGray;
Console.Clear();
Console.ForegroundColor = ConsoleColor.Black;

//Dictionary instead of list in order to connect two types.
Dictionary<string, int> calculationsList = new Dictionary<string, int>(2);

bool programRunning = true;
while (programRunning)

{
    //Welcoming to the calculator, some random stuff added for styling.
    Console.WriteLine("\n< § ~ { The Basic Calculator } ~ § >\n");

    //Meny choices.
    Console.WriteLine("[1] < Calculation of two numbers >");
    Console.WriteLine("[2] < Show previous results >");
    Console.WriteLine("[3] < Clear the results >");
    Console.WriteLine("[4] < Exit the program >");

    //Tryparse for the meny choice with the switch default to inform if not 1-3 have been entered.
    Int32.TryParse(Console.ReadLine(), out int menyChoice);
    switch (menyChoice)
    {
        case 1:
            //Nedan är uträkningarna. Det finns garanterat ett bättre sätt att göra detta på då de fyra olika kodblocken är väldigt lika.
            //Någon form av loop kanske? Men detta är den nivå jag kan förstå just nu.
            try
            {
                Console.WriteLine("\nPlease enter the first number: ");
                string? firstNumberText = Console.ReadLine();
                int firstNumber = Convert.ToInt32(firstNumberText);

                Console.WriteLine("\nChose an operator ( + - * / ): ");
                string? operatorChoiceText = Console.ReadLine();
                char operatorChoice = Convert.ToChar(operatorChoiceText); //Null solved with catch.


                Console.WriteLine("\nPlease enter the second number: ");
                string? secondNumberText = Console.ReadLine();
                int secondNumber = Convert.ToInt32(secondNumberText);

                string userCalculationInput = $"{firstNumberText} {operatorChoiceText} {secondNumberText}";
                int calculatedResult = 0;

                if (operatorChoice == '+')
                    Console.WriteLine($"\nInput: {firstNumber} {operatorChoice} {secondNumber}. Result: {calculatedResult = firstNumber + secondNumber} ");

                if (operatorChoice == '-')
                    Console.WriteLine($"\nInput: {firstNumber} {operatorChoice} {secondNumber}. Result: {calculatedResult = firstNumber - secondNumber} ");

                if (operatorChoice == '*')
                    Console.WriteLine($"\nInput: {firstNumber} {operatorChoice} {secondNumber}. Result: {calculatedResult = firstNumber * secondNumber} ");

                if (operatorChoice == '/')
                    Console.WriteLine($"\nInput: {firstNumber} {operatorChoice} {secondNumber}. Result: {calculatedResult = firstNumber / secondNumber} ");

                calculationsList.Add(userCalculationInput, calculatedResult);
                Console.ReadKey();
                break;

            }
            catch
            {
                Console.WriteLine($"Error: Incorrect input. \nRetry? Y/N?");
                string? retryCase1 = Console.ReadLine();
                if (retryCase1 == "y")
                    goto case 1;

                else if (retryCase1 != "y")
                            //You will be returned to the meny. WriteLine and then a 2 second delay for break? Possible?
                            break;
            }
            break;

        case 2:
            Console.WriteLine("\nShow the previous results of the calculator? Y/N?");
            string? showPreviousResults = Console.ReadLine();

            if (showPreviousResults?.ToLower() == "y")
            {
                Console.WriteLine("\nComplete list of the calculations: \n");
                int calculationOrder = 1;
                for (int i = 0; i < calculationsList.Count; i++)
                {
                    Console.WriteLine($"Calculation #{calculationOrder++}: " + calculationsList.ElementAt(i).Key + " = " + calculationsList.ElementAt(i).Value);
                }


                //Alternativt:
                /*
                foreach (var item in calculationsList)
                {
                    Console.WriteLine($"Calculation #{calculationsList.Count}: [" + item.Key + " = " + item.Value + "]");
                }
                */


                Console.ReadKey();
                break;
            }

            else if (showPreviousResults?.ToLower() != "y") //You will be returned to the meny. WriteLine and then a 2 second delay for break? Possible?
                break;
            break;

        case 3:
            Console.WriteLine("If you clear the results you will not be able to get them back. Clear the results? Y/N?");
            string? clearResultsChoice = Console.ReadLine();

            if (clearResultsChoice?.ToLower() == "y")
                calculationsList.Clear();

            else if (clearResultsChoice?.ToLower() == "n")
            {
                Console.WriteLine("The results will not be cleared.");
                Console.ReadKey();
                break;
            }
            else
            {
                Console.WriteLine("Error: You did not enter Y or N.");
                //Console.P();
                goto case 3;
            }
            break;

        case 4:
            Console.WriteLine("If you exit the program the calculations will not be saved. Exit the program? Y/N?");
            string? exitYesNo = Console.ReadLine();

            if (exitYesNo?.ToLower() == "y")
                programRunning = false;

            else if (exitYesNo?.ToLower() != "y")
                break;
            break;

        default:
            Console.WriteLine("You have to chose between meny choices 1 - 3! \nPress a key and then try again.");
            break;
    }

    //To clear the console.
    Console.Clear();
}
