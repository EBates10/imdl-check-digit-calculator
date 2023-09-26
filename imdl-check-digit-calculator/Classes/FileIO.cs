using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdl_check_digit_calculator.Classes
{
    public class FileIO
    {
        private string fileToRead = "C:\\imdl-check-digit-files\\input-container-numbers-no-check-digit.csv";
        private string fileToWrite = "C:\\imdl-check-digit-files\\output-container-numbers-with-check-digit.csv";

        public List<Container> ReadFile()
        {
            List<Container> containers = new List<Container>();

            try
            {
                using (StreamReader sr = new StreamReader(fileToRead))
                {
                    while (!sr.EndOfStream) 
                    {
                        string line = sr.ReadLine();
                        string[] arrayOfContainerNumbers = line.Split(",");
                        for (int i = 0; i < arrayOfContainerNumbers.Length; i++)
                        {
                            Container container = new Container(arrayOfContainerNumbers[i]);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                containers = new List<Container>();
            }
            return containers;
        }

        //need to write method for writing container numbers with check digit to output file
    }
}
