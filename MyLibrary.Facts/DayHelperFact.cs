using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyLibrary.Facts
{
    public class DayHelperFact
    {
        public class ToFriendlyText
        {
            public ToFriendlyText()
            {

            }
            //[Fact]
            //public void SingleDay()
            //{
            //    //arrange => Prepare input data
            //    var d = new DayHelper();
            //    var input = new int[] { 1 };

            //    //act => process of method to test
            //    string result = d.ToFriendlyText(input);

            //    //assert => check expected result
            //    Assert.Equal("1", result);
            //}

            private static IEnumerable<object[]> DayInMonthTestData()
            {
                for (int i = 1; i <= 31; i++)
                {
                    yield return new object[] { i, i.ToString() };
                }
            }

            [Theory]
            //[InlineData(1, "1")]
            //[InlineData(2, "2")]
            //[InlineData(3, "3")]
            //[InlineData(4, "4")]
            //[InlineData(5, "5")]
            [MemberData(nameof(DayInMonthTestData))]
            public void SingleDay(int day, string expected)
            {
                //arrange => Prepare input data
                var d = new DayHelper();
                var input = new int[] { day };

                //act => process of method to test
                string result = d.ToFriendlyText(input);

                //assert => check expected result
                Assert.Equal(expected, result);
            }

            [Fact]
            public void EmptyArray_EmptyString()
            {
                //arrange => Prepare input data
                var d = new DayHelper();

                //act => process of method to test
                var result = d.ToFriendlyText(new int[] { });

                //assert => check expected result
                Assert.Equal("", result);
            }

            [Fact]
            public void ContinuouslyDays()
            {
                var d = new DayHelper();
                var input = new int[] { 1, 2, 3 };

                var result = d.ToFriendlyText(input);

                Assert.Equal("1-3", result);
            }

            [Fact]
            public void ContinuouslyAndSingleDays()
            {
                var d = new DayHelper();
                var input = new int[] { 1, 2, 5 };

                var result = d.ToFriendlyText(input);

                Assert.Equal("1-2 and 5", result);
            }

            [Fact]
            public void InvalidDay_ThrowException()
            {
                var d = new DayHelper();

                Assert.Throws<InvalidDayException>(() =>
                {
                    var result = d.ToFriendlyText(new int[] { 0, 1 });
                });
            }

            [Fact]
            public void InvalidDay_ThrowException_2()
            {
                var d = new DayHelper();

                Assert.Throws<InvalidDayException>(() =>
                {
                    var result = d.ToFriendlyText(new int[] { 1, 32 });
                });
            }



        }
    }
}
