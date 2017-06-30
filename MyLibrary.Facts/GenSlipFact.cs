using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyLibrary.Facts
{
    public class GenSlipFact
    {
        public class GenSlip
        {
            [Fact]
            //Given_When_Then
            public void ClaimInsuredTwoSlipsNoRePrint_GetListOfSlip_TwoOfPrintedSlips()
            {
                //arrange
                string formName = " B328/06/2017 10:16(1)| A28/06/2017 10:16(1)|";
                var slip = new Slip();
                var printType = PrintType.ClaimInsured;

                //act
                var result = slip.GetPrintedSlip(printType, formName);

                //assert
                Assert.Equal(new string[] { "B328/06/2017 10:16(1)", "A28/06/2017 10:16(1)" }, result);
            }

            [Fact]
            public void ClaimInsuredThreeSlipsRePrintOne_GetListOfSlip_TwoOfPrintedSlips()
            {
                //arrange
                string formName = " B328/06/2017 10:16(1)| A28/06/2017 10:16(1)| B328/06/2017 10:20(2)|";
                var slip = new Slip();
                var printType = PrintType.ClaimInsured;

                //act
                var result = slip.GetPrintedSlip(printType, formName);

                //assert
                Assert.Equal(new string[] { "A28/06/2017 10:16(1)", "B328/06/2017 10:20(2)" }, result);
            }
        }
    }
}
