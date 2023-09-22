using System;
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
                string containerNumber = GetContainerNumber();

                Container container = new Container(containerNumber); 

                DisplayContNumberComponentInfo(container.ContainerPreFix, container.EqCategoryIdentifier, container.ContainerSerialNumber);

                int checkDigit = container.GetCheckDigit(container.ContainerNumber);

                DisplayCheckDigit(checkDigit);

                isDone = true;
            }
        }

        public static string GetContainerNumber()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Please provide the container number in the format XXXX######: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string containerNumber = GetUserInput().ToUpper();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            return containerNumber;
        }
        public static string GetUserInput()
        {
            if (Console.ReadLine() != null)
            {
                return Console.ReadLine();
            }
            else
            {
                return "You must provide a valid entry.";
            }
        }
        private static void DisplayContNumberComponentInfo(string containerPreFix, string eqCategoryIdentifier, string containerSerialNumber)
        {
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
