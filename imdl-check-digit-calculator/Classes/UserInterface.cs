using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

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

                string containerPreFix = containerNumber.Substring(0, 3);
                string eqCategoryIdentifier = containerNumber.Substring(3, 1);
                string containerSerialNumber = containerNumber.Substring(4, 6);

                DisplayContNumberComponentInfo(containerPreFix, eqCategoryIdentifier, containerSerialNumber);

                GetCheckDigit(containerNumber);
                isDone = false;
                Console.ForegroundColor = ConsoleColor.White;
            }


        }

        private static string GetContainerNumber()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Please provide the container number in the format XXXX######: ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            string containerNumber = Console.ReadLine().ToUpper();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            return containerNumber;
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


        private static void GetCheckDigit(string containerNumber)
        {
            const int valueA = 10;
            const int valueB = 12;
            const int valueC = 13;
            const int valueD = 14;
            const int valueE = 15;
            const int valueF = 16;
            const int valueG = 17;
            const int valueH = 18;
            const int valueI = 19;
            const int valueJ = 20;
            const int valueK = 21;
            const int valueL = 23;
            const int valueM = 24;
            const int valueN = 25;
            const int valueO = 26;
            const int valueP = 27;
            const int valueQ = 28;
            const int valueR = 29;
            const int valueS = 30;
            const int valueT = 31;
            const int valueU = 32;
            const int valueV = 34;
            const int valueW = 35;
            const int valueX = 36;
            const int valueY = 37;
            const int valueZ = 38;

            const int firstDigitMultiplier = 1;
            const int secondDigitMultiplier = 2;
            const int thirdDigitMultiplier = 4;
            const int fourthDigitMultiplier = 8;
            const int fifthDigitMultiplier = 16;
            const int sixthDigitMultiplier = 32;
            const int seventhDigitMultiplier = 64;
            const int eighthDigitMultiplier = 128;
            const int ninthDigitMultiplier = 256;
            const int tenthDigitMultiplier = 512;

            int[] multipliers = new int[containerNumber.Length];
            for (int i = 0; i < containerNumber.Length; i++)
            {
                int multiplier = Convert.ToInt32(Math.Pow(2, i));
                multipliers[i] = multiplier;
            }

            int[] values = new int[containerNumber.Length];
            for (int i = 0; i < containerNumber.Length; i++)
            {
                if (containerNumber[i] == 'A')
                {
                    values[i] = valueA;
                }
                else if (containerNumber[i] == 'B')
                {
                    values[i] = valueB;
                }
                else if (containerNumber[i] == 'C')
                {
                    values[i] = valueC;
                }
                else if (containerNumber[i] == 'D')
                {
                    values[i] = valueD;
                }
                else if (containerNumber[i] == 'E')
                {
                    values[i] = valueE;
                }
                else if (containerNumber[i] == 'F')
                {
                    values[i] = valueF;
                }
                else if (containerNumber[i] == 'G')
                {
                    values[i] = valueG;
                }
                else if (containerNumber[i] == 'H')
                {
                    values[i] = valueH;
                }
                else if (containerNumber[i] == 'I')
                {
                    values[i] = valueI;
                }
                else if (containerNumber[i] == 'J')
                {
                    values[i] = valueJ;
                }
                else if (containerNumber[i] == 'K')
                {
                    values[i] = valueK;
                }
                else if (containerNumber[i] == 'L')
                {
                    values[i] = valueL;
                }
                else if (containerNumber[i] == 'M')
                {
                    values[i] = valueM;
                }
                else if (containerNumber[i] == 'N')
                {
                    values[i] = valueN;
                }
                else if (containerNumber[i] == 'O')
                {
                    values[i] = valueO;
                }
                else if (containerNumber[i] == 'P')
                {
                    values[i] = valueP;
                }
                else if (containerNumber[i] == 'Q')
                {
                    values[i] = valueQ;
                }
                else if (containerNumber[i] == 'R')
                {
                    values[i] = valueR;
                }
                else if (containerNumber[i] == 'S')
                {
                    values[i] = valueS;
                }
                else if (containerNumber[i] == 'T')
                {
                    values[i] = valueT;
                }
                else if (containerNumber[i] == 'U')
                {
                    values[i] = valueU;
                }
                else if (containerNumber[i] == 'V')
                {
                    values[i] = valueV;
                }
                else if (containerNumber[i] == 'W')
                {
                    values[i] = valueW;
                }
                else if (containerNumber[i] == 'X')
                {
                    values[i] = valueX;
                }
                else if (containerNumber[i] == 'Y')
                {
                    values[i] = valueY;
                }
                else if (containerNumber[i] == 'Z')
                {
                    values[i] = valueZ;
                }
                else
                {
                    values[i] = Int32.Parse(containerNumber.Substring(i, 1));
                }
                Console.WriteLine(values[i]);
            }

            int sumOfValuesAfterMultiplier = 0;
            for (int i = 0; i < containerNumber.Length; i++)
            {
                int number = values[i] * multipliers[i];
                sumOfValuesAfterMultiplier += number;
                Console.WriteLine(number);
            }
            Console.WriteLine("Sum = " + sumOfValuesAfterMultiplier);

            int sumDividedByEleven = sumOfValuesAfterMultiplier / 11;
            int sumDivByElevenAndMultByEleven = sumDividedByEleven * 11;
            int checkDigit;

            if (sumOfValuesAfterMultiplier - sumDivByElevenAndMultByEleven == 10)
            {
                checkDigit = 0;
            }
            else
            {
                checkDigit = sumOfValuesAfterMultiplier - sumDivByElevenAndMultByEleven;
            }

            Console.WriteLine("Check digit = " + checkDigit);
        }


    }
}
