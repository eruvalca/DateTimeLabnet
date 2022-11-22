using DateTimeLabnet;

namespace DateTimeLab.Tests;
public class DateTimeLabCodeTests
{
    DateTimeLabCode _dateTimeCode = new();

    [Fact]
    public void GetTheDateTodayTest()
    {
        var expected = DateTime.Today;
        var actual = _dateTimeCode.GetTheDateToday();
        Assert.Equal(expected, actual);
    }

    [InlineData(12, 25, 2015, "12/25/15")]
    [InlineData(4, 1, 2017, "4/1/17")]
    [Theory]
    public void GetShortDateStringFromParamatersTest(int month, int day, int year, string expected)
    {
        var actual = _dateTimeCode.GetShortDateStringFromParamaters(month, day, year);
        Assert.Equal(expected, actual);
    }

    [InlineData("10/1/1971", "10/1/1971")]
    [InlineData("09.09.99", "9/9/1999")]
    [InlineData("January 27, 2006", "1/27/2006")]
    [InlineData("13 Aug 1994", "8/13/1994")]
    [Theory]
    public void GetDateTimeObjectFromStringTest(string date, string expected)
    {
        var actual = _dateTimeCode.GetDateTimeObjectFromString(date).ToShortDateString();
        Assert.Equal(expected, actual);
    }

    [InlineData("12/4/2005 1:55 pm", "12.04.2005 01:55 PM")]
    [InlineData("April 4, 2010 3:30 PM", "04.04.2010 03:30 PM")]
    [InlineData("9 Jun 2002 5:05 am", "06.09.2002 05:05 AM")]
    [Theory]
    public void GetFormatedDateStringTest(string testDate, string expected)
    {
        var actual = _dateTimeCode.GetFormatedDateString(testDate);
        Assert.Equal(expected, actual);
    }

    [InlineData("01/01/2005", "July 1, 2005")]
    [InlineData("4/20/2005", "October 20, 2005")]
    [InlineData("12/31/2005", "June 30, 2006")]
    [Theory]
    public void GetDateInSixMonthsTest(string testDate, string expected)
    {
        var actual = _dateTimeCode.GetDateInSixMonths(testDate);
        Assert.Equal(expected, actual);
    }

    [InlineData("04/01/2005", "March 2, 2005")]
    [InlineData("10/20/2005", "September 20, 2005")]
    [InlineData("06/30/2006", "May 31, 2006")]
    [Theory]
    public void GetDateThirtyDaysInPastTest(string testDate, string expected)
    {
        var actual = _dateTimeCode.GetDateThirtyDaysInPast(testDate);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetNextWednesdays1()
    {
        var actual = _dateTimeCode.GetNextWednesdays(3, "January 1, 2016");

        Assert.Equal(3, actual.Length);

        var first = new DateTime(2016, 1, 6);
        Assert.Equal(actual[0], first);

        var second = new DateTime(2016, 1, 13);
        Assert.Equal(actual[1], second);

        var third = new DateTime(2016, 1, 20);
        Assert.Equal(actual[2], third);
    }

    [Fact]
    public void GetNextWednesdays2()
    {
        var actual = _dateTimeCode.GetNextWednesdays(5, "February 3, 2016");

        Assert.Equal(5, actual.Length);

        var first = new DateTime(2016, 2, 3);
        Assert.Equal(actual[0], first);

        var second = new DateTime(2016, 2, 10);
        Assert.Equal(actual[1], second);

        var third = new DateTime(2016, 2, 17);
        Assert.Equal(actual[2], third);

        var fourth = new DateTime(2016, 2, 24);
        Assert.Equal(actual[3], fourth);

        var fifth = new DateTime(2016, 3, 2);
        Assert.Equal(actual[4], fifth);
    }
}
