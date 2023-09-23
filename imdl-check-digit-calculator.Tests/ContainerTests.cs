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
        [DataRow("MSMU796217", 3)]
        [DataRow("MSMU819766", 0)]
        [DataRow("MEDU207089", 0)]
        [DataRow("FDCU032827", 9)]
        [DataRow("TXGU539212", 9)]
        [DataRow("TEMU216382", 5)]
        [DataRow("CRSU926520", 2)]
        [DataRow("MEDU401823", 2)]     
        [DataRow("MSMU819766", 0)]     
        [DataRow("MSDU605097", 1)]
        [DataRow("MSDU605799", 7)]
        [DataRow("MEDU207089", 0)]
        [DataRow("BMOU281854", 9)]
        [DataRow("TCLU911122", 0)]
        [DataRow("MSDU606204", 1)]
        [DataRow("FSCU940849", 8)]
        [DataRow("MSMU420804", 6)]
        [DataRow("SEGU613258", 0)]
        [DataRow("OOLU797537", 7)]
        [DataRow("HASU513718", 4)]
        [DataRow("MRSU373590", 5)]
        [DataRow("MSCU567403", 3)]
        [DataRow("MEDU708110", 0)]
        [DataRow("TTNU104236", 0)]
        [DataRow("TLLU762718", 0)]
        [DataRow("GLDU096565", 8)]
        [DataRow("MSDU839027", 1)]
        [DataRow("MSDU240383", 3)]
        [DataRow("MSCU684413", 4)]
        [DataRow("MEDU601608", 0)]
        [DataRow("BEAU605566", 7)]
        [DataRow("TGBU743277", 9)]
        [DataRow("TGHU066022", 8)]
        [DataRow("MSDU851521", 3)]
        [DataRow("MSDU851521", 3)]
        [DataRow("MEDU700556", 3)]
        [DataRow("WAMU000000", 0)]
        [DataRow("MSMU822158", 1)]
        [DataRow("MSDU894613", 9)]
        [DataRow("MSMU822158", 1)]
        [DataRow("MSMU539071", 5)]
        [DataRow("MSDU894613", 9)]
        [DataRow("MEDU846526", 5)]
        [DataRow("MSMU810634", 0)]
        [DataRow("MSMU140454", 9)]
        [DataRow("MEDU290102", 1)]
        [DataRow("OOCU640857", 8)]
        [DataRow("MEDU876921", 0)]
        [DataRow("MSMU810634", 0)]
        [DataRow("TEMU889303", 4)]
        [DataRow("MRSU373590", 5)]
        [DataRow("TEMU616331", 4)]
        [DataRow("MEDU604496", 6)]
        [DataRow("MEDU441119", 4)]
        [DataRow("TGBU608925", 9)]
        [DataRow("CAIU871777", 2)]
        [DataRow("MEDU940986", 2)]
        [DataRow("OOCU640857", 8)]
        [DataRow("CAIU981379", 1)]
        [DataRow("CAIU287459", 0)]
        [DataRow("FSCU940849", 8)]
        [DataRow("MSMU598649", 5)]
        [DataRow("TRHU758058", 0)]
        [DataRow("FCGU169053", 6)]
        [DataRow("TGHU921813", 5)]
        [DataRow("MEDU876921", 0)]
        [DataRow("TCNU890245", 5)]
        [DataRow("CAIU986079", 3)]
        [DataRow("CAIU287459", 0)]
        [DataRow("TGHU921813", 5)]
        [DataRow("MEDU944870", 3)]
        [DataRow("CAIU724735", 5)]
        [DataRow("TXGU545215", 1)]
        [DataRow("TCNU102143", 0)]
        [DataRow("MSDU176229", 5)]
        [DataRow("MSDU764245", 0)]
        [DataRow("MSMU703490", 3)]
        [DataRow("MSDU606204", 1)]
        [DataRow("MSDU606203", 6)]
        [DataRow("CARU216288", 4)]
        [DataRow("CAAU553232", 4)]
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
