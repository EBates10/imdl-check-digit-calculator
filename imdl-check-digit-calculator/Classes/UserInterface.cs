using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using imdl_check_digit_calculator.Classes;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace imdl_check_digit_calculator.Classes
{
    public class UserInterface
    {
        public void Run()
        {
            bool isDone = false;

            while (!isDone)
            {
                string userInput1 = DisplayMainMenu();
                MainMenuSwitchCase(isDone, userInput1);
                isDone = ContinueOrExitMenu(isDone);
            }
        }


        public static string DisplayMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Welcome to the Intermodal Check Digit Calculator!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("(1) Enter an individual container number");
            Console.WriteLine("(2) Enter a list of container numbers");
            Console.WriteLine("(3) Upload a csv file");
            Console.ForegroundColor = ConsoleColor.White;
            string userInput = Console.ReadLine();
            return userInput;
        }
        private static void MainMenuSwitchCase(bool isDone, string userInput)
        {
            switch (userInput)
            {
                case "1":
                    string containerNumber = GetIndividualContainerNumber();
                    if (containerNumber.Length != 0)
                    {
                        Container container = new Container(containerNumber);
                        //DisplayContNumberComponentInfo(container.ContainerPreFix, container.EqCategoryIdentifier, container.ContainerSerialNumber);
                        int checkDigit = container.ContainerCheckDigit;
                        DisplayCheckDigitIndividualContainer(checkDigit);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please make sure your entry is in the correct format.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    break;
                case "2":
                    string[] containerNumbers = GetListContainerNumbers();
                    if (containerNumbers.Length != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Please see your container numbers with check digit below: ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        DisplayContainerListWithCheckDigits(containerNumbers);
                        Console.ForegroundColor = ConsoleColor.Yellow;         
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please make sure your entry is in the correct format.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This feature is currently under construction.");
                    break;
            }
        }
        public static string GetIndividualContainerNumber()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please provide the container number in the format XXXU###### (example: TCNU123456): ");
            Console.ForegroundColor = ConsoleColor.White;
            string userInput = Console.ReadLine();
            string containerNumber = "";
            if (userInput.Length == 10)
            {
                if (VerifyPrefix(userInput) && VerifySerialNumber(userInput))
                {
                    containerNumber = userInput.ToUpper();
                    return containerNumber;
                }
                else
                {
                    return containerNumber;
                }
            }
            else
            {
                return containerNumber;
            }
        }
        private static void DisplayContNumberComponentInfo(string containerPreFix, string eqCategoryIdentifier, string containerSerialNumber)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Container Prefix: {containerPreFix}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The first 3 letters of the container number indicate the owner code or " +
                "principle operator of the container. Such code needs to be registered at the Bureau " +
                "International des Conteneurs in Paris ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Equipment Identifier: {eqCategoryIdentifier}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The fourth letter in the prefix of the container number indicates the type of equipment. " +
                "For example:\r\n" +
                "U for all freight containers\r\n" +
                "J for detachable freight container-related equipment\r\n" +
                "Z for trailers and chassis");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Serial Number: {containerSerialNumber}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The serial number consists of 6 numeric digits, assigned by the owner or operator, uniquely identifying the container within that owner/operator’s fleet.");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
        private static void DisplayCheckDigitIndividualContainer(int checkDigit)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Check digit = {checkDigit}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static string[] GetListContainerNumbers()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please provide a list of container numbers in the format XXXU######, " +
                "separated by a comma + space (example: \"TCNU123456, NYKU123456\"): ");
            Console.ForegroundColor = ConsoleColor.White;
            string userInput = Console.ReadLine().ToUpper();
            bool inputVerified = VerifyListFormat(userInput);
            if (inputVerified)
            {
                string[] containerNumbers = userInput.Split(", ");
                bool containersVerified = VerifyNumbersInList(containerNumbers);
                return containerNumbers;
            }
            else
            {
                string[] array = new string[0];
                return array;
            }
        }

        private static bool VerifyListFormat(string userInput)
        {
            bool result = false;
            for (int i = 10; i < userInput.Length-1; i+=12)
            {
                if (userInput[i] == ',' && userInput[i+1] == ' ')
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        private static bool VerifyNumbersInList(string[] containerNumbers)
        {
            bool result = false;
            bool[] results = new bool[containerNumbers.Length];
            for (int i = 0; i < containerNumbers.Length; i++)
            {
                if (VerifyPrefix(containerNumbers[i]) && VerifySerialNumber(containerNumbers[i]))
                {
                    results[i] = true;
                }
            }
            foreach (bool res in results)
            {
                if (res)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        private static void DisplayContainerListWithCheckDigits(string[] containerNumbers)
        {
            List<Container> containers = new List<Container>();
            for (int i = 0; i < containerNumbers.Length; i++)
            {
                Container container = new Container(containerNumbers[i]);
                containers.Add(container);
            }
            foreach (Container cont in containers)
            {
                Console.WriteLine(cont.ContainerNumberWithCheckDigit);
            }
        }

        public static bool VerifyPrefix(string userInput)
        {
            bool isPrefixLetters = false;
            string prefix = "";
            for (int i = 0; i < 4; i++)
            {
                if (char.IsLetter(userInput[i]) && (userInput[3] == 'U' || userInput[3] == 'u'))
                {
                    prefix += userInput[i];
                }
                if (prefix.Length == 4)
                {
                    isPrefixLetters = true;
                }
            }

            return isPrefixLetters;
        }
        public static bool VerifySerialNumber(string userInput)
        {
            bool isSerialNumANumber = false;
            string serialNum = "";
            for (int i = 4; i < userInput.Length; i++)
            {
                if (char.IsNumber(userInput[i]))
                {
                    serialNum += userInput[i];
                }
                if (serialNum.Length == 6)
                {
                    isSerialNumANumber = true;
                }
            }

            return isSerialNumANumber;
        }

        public static bool ContinueOrExitMenu(bool isDone)
        {
            bool result = false;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Would you like to go back to the main menu, or quit?");
            Console.WriteLine("(1) Return to main menu");
            Console.WriteLine("(2) Quit");
            Console.ForegroundColor = ConsoleColor.White;
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    result = false;
                    break;
                case "2":
                    result = true;
                    break;
            }
            return result;
        }

    }
}
