using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using imdl_check_digit_calculator;
using imdl_check_digit_calculator.Classes;

namespace imdl_check_digit_calculator.Tests
{
    [TestClass]
    public class ContainerTests
    {
        [TestMethod]
        [DataRow("GVTU300038", 9)]
        [DataRow("WNGU514530", 7)]
        [DataRow("WNGU514560", 5)]
        [DataRow("WNGU514531", 2)]
        [DataRow("TGBU482139", 7)]
        [DataRow("TCNU106807", 9)]
        [DataRow("CSNU789914", 0)]
        [DataRow("BEAU601112", 3)]
        [DataRow("CCLU529543", 6)]
        [DataRow("OOLU441721", 6)]
        [DataRow("CBHU947318", 2)]
        [DataRow("OOLU493219", 7)]
        [DataRow("DRYU981902", 3)]
        [DataRow("CSNU200967", 1)]
        public void GetCheckDigitTest(string containerNumber, int expectedCheckDigit)
        {
            //Arrange
            Container container = new Container(containerNumber);

            //Act
            int result = container.GetCheckDigit(container.ContainerNumber);

            //Assert
            Assert.AreEqual(expectedCheckDigit, result);
        }
    }
}
