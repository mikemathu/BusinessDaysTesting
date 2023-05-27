﻿using System;
using System.Collections.Generic;
using BizDayCalc;
using Xunit;
namespace BizDayCalcTests
{
    public class USHolidayTest
    {
        public static IEnumerable<object[]> Holidays
        {
            get
            {
                yield return new object[] { new DateTime(2016, 1, 1) };
                yield return new object[] { new DateTime(2016, 7, 4) };
                yield return new object[] { new DateTime(2016, 12, 24) };
                yield return new object[] { new DateTime(2016, 12, 25) };
            }
        }

        private Calculator calculator;

        //Using the constructor for setup
        //constructor of a test class can be used to share common setup code for all the test methods in a class
        public USHolidayTest() 
        {
            calculator = new Calculator();
            calculator.AddRule(new HolidayRule());
            Console.WriteLine("In USHolidayTest constructor");
        }     

        [Theory]
        [MemberData(nameof(Holidays))]
        public void TestHolidays(DateTime date)
        {
            Assert.False(calculator.IsBusinessDay(date));
            Console.WriteLine( $"In TestHolidays {date:yyyy-MM-dd}");
        }

        [Theory]
        [InlineData("2016-02-28")]
        [InlineData("2016-01-02")]
        public void TestNonHolidays(string date)
        {
            Assert.True(calculator.IsBusinessDay(DateTime.Parse(date)));
            Console.WriteLine($"In TestNonHolidays {date}");
        }
    }
}
