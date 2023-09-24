using imdl_check_digit_calculator.Classes;

namespace imdl_check_digit_calculator.Tests
{
    [TestClass]
    public class UITests
    {
        [TestMethod]
        [DataRow("TCNU123456", true)]
        [DataRow("GVTU300038", true)]
        [DataRow("tcnu123456", true)]
        [DataRow("gvtu300038", true)]
        [DataRow("zxy0******", false)]
        [DataRow("ljli******", false)]
        [DataRow("NPMUxyzabc", true)]
        [DataRow("@TNCU12345", false)]
        [DataRow("XYZ1687978", false)]
        [DataRow("0000000000", false)]
        [DataRow("msku123456", true)]
        [DataRow("DCNZ256358", false)]
        [DataRow("TSXZ458625", false)]
        [DataRow("NPMJ000856", false)]
        [DataRow("TCLU458968", true)]
        public void VerifyPrefixTest(string userInput, bool expectedIsVerified)
        {
            //Arrange
            UserInterface UuserInterface = new UserInterface();

            //Act
            bool result = UserInterface.VerifyPrefix(userInput);

            //Assert
            Assert.AreEqual(expectedIsVerified, result);
        }

        [TestMethod]
        [DataRow("ABCU123456", true)]
        [DataRow("TCNUU45679", false)]
        [DataRow("@402300038", true)]
        [DataRow("****123!45", false)]
        [DataRow("xyuz-99868", false)]
        [DataRow("gvtu300038", true)]
        [DataRow("ABCD000003", true)]
        [DataRow("TCNUtcnu12", false)]
        [DataRow("1234xyziok", false)]
        [DataRow("XYZU*65168", false)]
        public void VerifySerialNumber(string userInput, bool expectedIsVerified)
        {
            //Arrange
            UserInterface UserInterface = new UserInterface();

            //Act
            bool result = UserInterface.VerifySerialNumber(userInput);

            Assert.AreEqual(result, expectedIsVerified);
        }
    }
}