using System;
using BizDayCalc;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit;
using Xunit.Abstractions;

namespace BizDayCalcTests
{
    ///Sharing context with class fixtures
     
      public class USRegionTest : IClassFixture<USRegionFixture>  // Tells xUnit that this test uses a class fixture
    {
        private USRegionFixture fixture;
        public USRegionTest(USRegionFixture fixture) // xUnit creates the object and passes it to the test’s constructor
        {
            this.fixture = fixture;
        }

        [Theory]
        [InlineData("2016-01-01")]
        [InlineData("2016-12-25")]
        public void TestHolidays(string date)
        {
            Assert.False(fixture.Calc.IsBusinessDay(DateTime.Parse(date))); //Using the Calculator object from the fixture
        }

        [Theory]
        [InlineData("2016-02-29")]
        [InlineData("2016-01-04")]
        public void TestNonHolidays(string date)
        {
            Assert.True(fixture.Calc.IsBusinessDay(
            DateTime.Parse(date)));
        }
    }



    /// <summary>
    /// Sharing context with collection fixtures 
    /// </summary>

    /*  The collection fixture class doesn’t have any setup or
      cleanup code of its own.That’s done in the class fixture.*/


    /*   
     *   
     *   [Collection("US region collection")]//Refers to the collection by name

       public class USRegionTest //Test class no longer implements interface
       {
           private USRegionFixture fixture;
           public USRegionTest(USRegionFixture fixture) // xUnit creates the object and passes it to the test’s constructor
           {
               this.fixture = fixture;
           }

           [Theory]
           [InlineData("2016-01-01")]
           [InlineData("2016-12-25")]
           public void TestHolidays(string date)
           {
               Assert.False(fixture.Calc.IsBusinessDay(DateTime.Parse(date))); //Using the Calculator object from the fixture
           }

           [Theory]
           [InlineData("2016-02-29")]
           [InlineData("2016-01-04")]
           public void TestNonHolidays(string date)
           {
               Assert.True(fixture.Calc.IsBusinessDay(
               DateTime.Parse(date)));
           }

           private USRegionFixture ffixture;
           public void UUSRegionTest(USRegionFixture fixture)
           {
               this.ffixture = fixture;
           }
       }
    */



    ///GETTING OUTPUT FROM XUNIT TESTS
    ///
    /* [Collection("US region collection")]
     public class USRegionTest
     {
         private readonly USRegionFixture fixture;
         private readonly ITestOutputHelper output;
         public USRegionTest(USRegionFixture fixture, ITestOutputHelper output) 
         {
              this.fixture = fixture;
              this.output = output;
         }

         [Theory]
         [InlineData("2016-01-01")]
         [InlineData("2016-12-25")]
         public void TestHolidays(string date)
         {
             output.WriteLine($@"TestHolidays(""{date}"")"); 
             Assert.False(fixture.Calc.IsBusinessDay( DateTime.Parse(date)));
         }

         [Theory]
         [InlineData("2016-02-29")]
         [InlineData("2016-01-04")]
         public void TestNonHolidays(string date)
         {
             output.WriteLine($@"TestNonHolidays(""{date}"")");
             Assert.True(fixture.Calc.IsBusinessDay(DateTime.Parse(date)));
         }
     }*/

}