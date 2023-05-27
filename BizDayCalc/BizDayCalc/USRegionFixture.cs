using BizDayCalc;
using Xunit;

namespace BizDayCalcTests
{
    public class USRegionFixture
    {
        public Calculator Calc { get; private set; }
        public USRegionFixture()
        {
            Calc = new Calculator();
            Calc.AddRule(new WeekendRule());
            Calc.AddRule(new HolidayRule());
        } 
    }

    //Sharing context with collection fixtures
    [CollectionDefinition("US region collection")] //1 The name of the collection
    public class USRegionCollection : ICollectionFixture<USRegionFixture> { } //2 The class fixture is what the test classes will use.
}
