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
                switch(containerNumber[i])
                {
                    case 'A':
                        values[i] = letterValues['A'];
                        break;
                    case 'B':
                        values[i] = letterValues['B'];
                        break;
                    case 'C':
                        values[i] = letterValues['C'];
                        break;
                    case 'D':
                        values[i] = letterValues['D'];
                        break;
                    case 'E':
                        values[i] = letterValues['E'];
                        break;
                    case 'F':
                        values[i] = letterValues['F'];
                        break;
                    case 'G':
                        values[i] = letterValues['G'];
                        break;
                    case 'H':
                        values[i] = letterValues['H'];
                        break;
                    case 'I':
                        values[i] = letterValues['I'];
                        break;
                    case 'J':
                        values[i] = letterValues['J'];
                        break;
                    case 'K':
                        values[i] = letterValues['K'];
                        break;
                    case 'L':
                        values[i] = letterValues['L'];
                        break;
                    case 'M':
                        values[i] = letterValues['M'];
                        break;
                    case 'N':
                        values[i] = letterValues['N'];
                        break;
                    case 'O':
                        values[i] = letterValues['O'];
                        break;
                    case 'P':
                        values[i] = letterValues['P'];
                        break;
                    case 'Q':
                        values[i] = letterValues['Q'];
                        break;
                    case 'R':
                        values[i] = letterValues['R'];
                        break;
                    case 'S':
                        values[i] = letterValues['S'];
                        break;
                    case 'T':
                        values[i] = letterValues['T'];
                        break;
                    case 'U':
                        values[i] = letterValues['U'];
                        break;
                    case 'V':
                        values[i] = letterValues['V'];
                        break;
                    case 'W':
                        values[i] = letterValues['W'];
                        break;
                    case 'X':
                        values[i] = letterValues['X'];
                        break;
                    case 'Y':
                        values[i] = letterValues['Y'];
                        break;
                    case 'Z':
                        values[i] = letterValues['Z'];
                        break;
                    default:
                        values[i] = Int32.Parse(containerNumber.Substring(i, 1));
                        break;
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
