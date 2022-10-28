


//In a few places Y/N? have been used, meaning YES/NO?.
//It has been shorted to make testing the program faster with just an y or n for the user.

//Color styling of the console.
Console.BackgroundColor = ConsoleColor.DarkGray;
Console.Clear();
Console.ForegroundColor = ConsoleColor.Black;



List<int> calculatedResultsList = new List<int>();
int calculatedResult = 0;



bool programRunning = true;
while (programRunning)

{
    //To clear the console of the meny between meny choices.
    //Console.Clear();

    //Welcoming to the calculator, some random stuff added for styling.
    Console.WriteLine("\n< § ~ { The Basic Calculator } ~ § >\n");

    //Meny choices.
    Console.WriteLine("[1] < Calculation of two numbers >");
    Console.WriteLine("[2] < Show previous results >");
    Console.WriteLine("[3] < Exit the program >");

    //Tryparse for the meny choice with the switch default to inform if not 1-3 have been entered.
    Int32.TryParse(Console.ReadLine(), out int menyChoice);
    switch (menyChoice)
    {
        case 1:



            //Nedan är uträkningarna. Det finns garanterat ett bättre sätt att göra detta på då de fyra olika kodblocken är väldigt lika.
            //Någon form av loop kanske? Men detta är den nivå jag kan förstå just nu.

            //calculatedResultsList.Add(calculatedResult);
            try
            {
                Console.WriteLine("Please enter a number: ");
                string? firstNumberText = Console.ReadLine();
                int firstNumber = Convert.ToInt32(firstNumberText);

                Console.WriteLine("Chose an operator ( + - * / ): ");
                string? operatorChoiceText = Console.ReadLine();
                char operatorChoice = Convert.ToChar(operatorChoiceText);


                Console.WriteLine("Please enter a number: ");
                string? secondNumberText = Console.ReadLine();
                int secondNumber = Convert.ToInt32(secondNumberText);


                if (operatorChoice == '+')
                    Console.WriteLine($"Entererd: {firstNumber} {operatorChoice} {secondNumber}. Result: {calculatedResult = firstNumber + secondNumber} ");

                if (operatorChoice == '-')
                    Console.WriteLine($"Entererd: {firstNumber} {operatorChoice} {secondNumber}. Result: {calculatedResult = firstNumber - secondNumber} ");

                if (operatorChoice == '*')
                    Console.WriteLine($"Entererd: {firstNumber} {operatorChoice} {secondNumber}. Result: {calculatedResult = firstNumber * secondNumber} ");

                if (operatorChoice == '/')
                    Console.WriteLine($"Entererd: {firstNumber} {operatorChoice} {secondNumber}. Result: {calculatedResult = firstNumber / secondNumber} ");
                {
                    Console.WriteLine(calculatedResult);
                    calculatedResultsList.Add(calculatedResult);
                    Console.ReadKey();
                }
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
            Console.WriteLine("Show the previous results of the calculator? Y/N?");
            string? showPreviousResults = Console.ReadLine();
            if (showPreviousResults == "y")
            //Print list.
            {
                Console.WriteLine(calculatedResultsList);
                Console.ReadKey();
                break;
            }
            
            else if (showPreviousResults != "y")
                //You will be returned to the meny. WriteLine and then a 2 second delay for break? Possible?
                break;

            break;







        case 3:
            Console.WriteLine("If you exit the program the calculations will not be saved. Exit the program? Y/N?");
            string? exitYesNo = Console.ReadLine();

            if (exitYesNo?.ToLower() == "y")
                programRunning = false;

            else if (exitYesNo != "y")
                break;
            break;


        default:
            Console.WriteLine("You have to chose between meny choices 1 - 3! \nPress a key and then try again.");
            break;

    }
    //To clear the console the between meny choices.
    Console.Clear();
}
