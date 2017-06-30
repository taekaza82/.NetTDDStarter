using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace MyLibrary.Facts
{
    public class FillUpFact
    {
        public class Kml
        {
            private readonly ITestOutputHelper output;
            public Kml(ITestOutputHelper output)
            {
                this.output = output;
            }

            [Fact]
            public void FirstFillUp_Null()
            {
                //arrange
                var x = new FillUp();
                x.Odometer = 1000;
                x.Litters = 50.00;
                x.IsFull = true;

                //act
                double? kml = x.Kml;

                //assert
                Assert.Null(kml);
            }

            [Fact]
            public void SecondFillUp()
            {
                //arrange
                var f1 = new FillUp();
                f1.Odometer = 1000;
                f1.Litters = 50.00;
                f1.IsFull = true;

                var f2 = new FillUp();
                f2.Odometer = 1600;
                f2.Litters = 60.00;
                f2.IsFull = true;

                f1.NextFillUp = f2;

                //act
                double? kml1 = f1.Kml;
                double? kml2 = f2.Kml;

                //assert
                Assert.Equal(10, kml1);
                Assert.Null(kml2);
            }

            private static IEnumerable<object[]> FillUpDataCsv()
            {
                using (var reader = new StreamReader("FillUps.csv"))
                using (var csv = new CsvReader(reader))
                {
                    var data = csv.GetRecords<FillUpData>().ToList();
                    for (int i = 0; i < data.Count - 1; i++)
                    {
                        yield return new object[]
                        {
                            data[i].Odometer, data[i].Liters,
                            data[i + 1].Odometer, data[i + 1].Liters,
                            data[i].Kml
                        };
                    }
                }
            }

            [Theory]
            [MemberData(nameof(FillUpDataCsv))]
            public void TwoFillUp(
                int odo1, double litters1,
                int odo2, double litters2,
                double? expected
                )
            {
                //arrange                
                var f1 = new FillUp(odo1, litters1);
                var f2 = new FillUp(odo2, litters2);
                f1.NextFillUp = f2;               

                //act
                double? kml1 = f1.Kml;
                double? kml2 = f2.Kml;

                output.WriteLine($"{odo1,10} {litters1,10:n2} {kml1,10:n2}");
                output.WriteLine($"{odo2,10} {litters2,10:n2} {kml2,10:n2}");

                //assert
                Assert.Equal(expected, kml1);
                Assert.Null(kml2);
            }
        }
    }
}
