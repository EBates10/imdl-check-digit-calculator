using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdl_check_digit_calculator.Classes
{
    public class Container
    {
        public string ContainerNumber { get; set; }

        public string ContainerPreFix { get { return ContainerNumber.Substring(0, 3); } }
        public string EqCategoryIdentifier { get { return ContainerNumber.Substring(3, 1); } }
        public string ContainerSerialNumber { get { return ContainerNumber.Substring(4, 6); } }

        public Container(string containerNumber)
        {
            ContainerNumber = containerNumber;
        }


        public int GetCheckDigit(string containerNumber)
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

            Dictionary<char, int> letterValues = new Dictionary<char, int>()
            {
                {'A', 10 },
                {'B', 12 },
                {'C', 13 },
                {'D', 14 },
                {'E', 15 },
                {'F', 16 },
                {'G', 17 },
                {'H', 18 },
                {'I', 19 },
                {'J', 20 },
                {'K', 21 },
                {'L', 23 },
                {'M', 24 },
                {'N', 25 },
                {'O', 26 },
                {'P', 27 },
                {'Q', 28 },
                {'R', 29 },
                {'S', 30 },
                {'T', 31 },
                {'U', 32 },
                {'V', 34 },
                {'W', 35 },
                {'X', 36 },
                {'Y', 37 },
                {'Z', 38 }
            };

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
                    values[i] = letterValues['A'];
                }
                else if (containerNumber[i] == 'B')
                {
                    values[i] = letterValues['B'];
                }
                else if (containerNumber[i] == 'C')
                {
                    values[i] = letterValues['C'];
                }
                else if (containerNumber[i] == 'D')
                {
                    values[i] = letterValues['D'];
                }
                else if (containerNumber[i] == 'E')
                {
                    values[i] = letterValues['E'];
                }
                else if (containerNumber[i] == 'F')
                {
                    values[i] = letterValues['F'];
                }
                else if (containerNumber[i] == 'G')
                {
                    values[i] = letterValues['G'];
                }
                else if (containerNumber[i] == 'H')
                {
                    values[i] = letterValues['H'];
                }
                else if (containerNumber[i] == 'I')
                {
                    values[i] = letterValues['I'];
                }
                else if (containerNumber[i] == 'J')
                {
                    values[i] = letterValues['J'];
                }
                else if (containerNumber[i] == 'K')
                {
                    values[i] = letterValues['K'];
                }
                else if (containerNumber[i] == 'L')
                {
                    values[i] = letterValues['L'];
                }
                else if (containerNumber[i] == 'M')
                {
                    values[i] = letterValues['M'];
                }
                else if (containerNumber[i] == 'N')
                {
                    values[i] = letterValues['N'];
                }
                else if (containerNumber[i] == 'O')
                {
                    values[i] = letterValues['O'];
                }
                else if (containerNumber[i] == 'P')
                {
                    values[i] = letterValues['P'];
                }
                else if (containerNumber[i] == 'Q')
                {
                    values[i] = letterValues['Q'];
                }
                else if (containerNumber[i] == 'R')
                {
                    values[i] = letterValues['R'];
                }
                else if (containerNumber[i] == 'S')
                {
                    values[i] = letterValues['S'];
                }
                else if (containerNumber[i] == 'T')
                {
                    values[i] = letterValues['T'];
                }
                else if (containerNumber[i] == 'U')
                {
                    values[i] = letterValues['U'];
                }
                else if (containerNumber[i] == 'V')
                {
                    values[i] = letterValues['V'];
                }
                else if (containerNumber[i] == 'W')
                {
                    values[i] = letterValues['W'];
                }
                else if (containerNumber[i] == 'X')
                {
                    values[i] = letterValues['X'];
                }
                else if (containerNumber[i] == 'Y')
                {
                    values[i] = letterValues['Y'];
                }
                else if (containerNumber[i] == 'Z')
                {
                    values[i] = letterValues['Z'];
                }
                else
                {
                    values[i] = Int32.Parse(containerNumber.Substring(i, 1));
                }
            }

            int sumOfValuesAfterMultiplier = 0;
            for (int i = 0; i < containerNumber.Length; i++)
            {
                int number = values[i] * multipliers[i];
                sumOfValuesAfterMultiplier += number;
            }

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

            return checkDigit;
        }
    }
}
