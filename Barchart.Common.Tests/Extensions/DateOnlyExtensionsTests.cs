using Barchart.Common.Extensions;

namespace Barchart.Common.Tests.Extensions;

public class DateOnlyExtensionsTests
{
    #region Fields
    
    private readonly ITestOutputHelper _testOutputHelper;
    
    #endregion

    #region Constructor(s)

    public DateOnlyExtensionsTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    #endregion

    #region Test Methods (CountDaysBetween)
    
    [Fact]
    public void CountDaysBetween_NumberOfDaysBetweenTodayAndToday_IsZero()
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Today);
        
        Assert.Equal(0, today.CountDaysBetween(today));
    }

    [Fact]
    public void CountDaysBetween_NumberOfDaysBetweenTodayAndTomorrow_IsOne()
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Today);
        DateOnly tomorrow = today.AddDays(1);
        
        Assert.Equal(1, today.CountDaysBetween(tomorrow));
    }

    [Fact]
    public void CountDaysBetween_NumberOfDaysBetweenYesterdayAndToday_IsOne()
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Today);
        DateOnly yesterday = today.AddDays(-1);
        
        Assert.Equal(1, yesterday.CountDaysBetween(today));
    }

    [Fact]
    public void CountDaysBetween_NumberOfDaysBetweenTomorrowAndYesterday_IsNegativeTwo()
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Today);
        DateOnly tomorrow = today.AddDays(1);
        DateOnly yesterday = today.AddDays(-1);
        
        Assert.Equal(-2, tomorrow.CountDaysBetween(yesterday));
    }

    [Fact]
    public void CountDaysBetween_NumberOfDaysBetweenTwoDates_IsOne()
    {
        DateOnly date1 = new DateOnly(2024, 4, 29);
        DateOnly date2 = new DateOnly(2024, 4, 30);
        
        Assert.Equal(1, date1.CountDaysBetween(date2));
    }

    [Fact]
    public void CountDaysBetween_NumberOfDaysBetweenTwoDates_IsTwo()
    {
        DateOnly date1 = new DateOnly(2024, 4, 29);
        DateOnly date2 = new DateOnly(2024, 5, 1);
        
        Assert.Equal(2, date1.CountDaysBetween(date2));
    }

    [Fact]
    public void CountDaysBetween_NumberOfDaysBetweenTwoDates_IsThirty()
    {
        DateOnly date1 = new DateOnly(2023, 12, 1);
        DateOnly date2 = new DateOnly(2023, 12, 31);
        
        Assert.Equal(30, date1.CountDaysBetween(date2));
    }

    [Fact]
    public void CountDaysBetween_NumberOfDaysBetweenTwoDates_IsThirtyOne()
    {
        DateOnly date1 = new DateOnly(2023, 12, 1);
        DateOnly date2 = new DateOnly(2024, 1, 1);
        
        Assert.Equal(31, date1.CountDaysBetween(date2));
    }

    [Fact]
    public void CountDaysBetween_NumberOfDaysBetweenTwoDates_IsSixtyTwo()
    {
        DateOnly date1 = new DateOnly(2023, 12, 1);
        DateOnly date2 = new DateOnly(2024, 2, 1);
        
        Assert.Equal(62, date1.CountDaysBetween(date2));
    }

    [Fact]
    public void CountDaysBetween_NumberOfDaysBetweenTwoDates_IsEightThousandEightHundredEightyFive()
    {
        DateOnly date1 = new DateOnly(2000, 1, 1);
        DateOnly date2 = new DateOnly(2024, 4, 29);
        
        Assert.Equal(8885, date1.CountDaysBetween(date2));
    }

    [Fact]
    public void CountDaysBetween_NumberOfDaysBetweenTwoDates_IsNegativeEightThousandEightHundredEightyFive()
    {
        DateOnly date1 = new DateOnly(2024, 4, 29);
        DateOnly date2 = new DateOnly(2000, 1, 1);
        
        Assert.Equal(-8885, date1.CountDaysBetween(date2));
    }
    
    #endregion

    #region Test Methods (GetDaysSinceEpoch)
    
    [Fact]
    public void GetDaysSinceEpoch_NumberOfDays_IsZero()
    {
        DateOnly date = new DateOnly(1, 1, 1);
        
        Assert.Equal(0, date.GetDaysSinceEpoch());
    }
    
    [Fact]
    public void GetDaysSinceEpoch_NumberOfDays_IsSevenHundredThirtyNineThousandFour()
    {
        DateOnly date = new DateOnly(2024, 4, 29);
        
        Assert.Equal(739004, date.GetDaysSinceEpoch());
    }

    #endregion
}