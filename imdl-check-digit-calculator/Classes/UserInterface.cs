﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using imdl_check_digit_calculator.Classes;

namespace imdl_check_digit_calculator.Classes
{
    public class UserInterface
    {
        public void Run()
        {
            bool isDone = false;

            while (!isDone)
            {
                string containerNumber = GetContainerNumber().ToUpper();
                
                if (containerNumber.Length == 10)
                {
                    Container container = new Container(containerNumber);

                    DisplayContNumberComponentInfo(container.ContainerPreFix, container.EqCategoryIdentifier, container.ContainerSerialNumber);

                    int checkDigit = container.GetCheckDigit(container.ContainerNumber);

                    DisplayCheckDigit(checkDigit);

                    isDone = true;
                }


            }
        }

        public static string GetContainerNumber()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Please provide the container number in the format XXXX###### (example: TCNU123456): ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string userInput = Console.ReadLine();
            string containerNumber = "";
            bool prefixVerified = VerifyPrefix(userInput);
            bool serialNumVerified = VerifySerialNumber(userInput);
            if (userInput.Length == 10 && prefixVerified && serialNumVerified)
            {
                containerNumber = userInput;
                return containerNumber;
            }
            else
            {
                return containerNumber;
            }
        }


        private static bool VerifyPrefix(string userInput)
        {
            bool isPrefixLetters = false;
            string prefix = "";
            for (int i = 0; i < 4; i++)
            {
                if (char.IsLetter(userInput[i]))
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
        private static bool VerifySerialNumber(string userInput)
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


        private static void DisplayContNumberComponentInfo(string containerPreFix, string eqCategoryIdentifier, string containerSerialNumber)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Container Prefix: {containerPreFix}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The first 3 letters of the container number indicate the owner code or " +
                "principle operator of the container. Such code needs to be registered at the Bureau " +
                "International des Conteneurs in Paris ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Equipment Identifier: {eqCategoryIdentifier}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The fourth letter in the prefix of the container number indicates the type of equipment. " +
                "For example:\r\n" +
                "U for all freight containers\r\n" +
                "J for detachable freight container-related equipment\r\n" +
                "Z for trailers and chassis");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Serial Number: {containerSerialNumber}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The serial number consists of 6 numeric digits, assigned by the owner or operator, uniquely identifying the container within that owner/operator’s fleet.");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
        private static void DisplayCheckDigit(int checkDigit)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Check digit = {checkDigit}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}
