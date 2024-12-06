#region Using Statements

using Barchart.Common.Extensions;

#endregion

namespace Barchart.Common.Tests.Extensions;

public class DateTimeExtensionsTests
{
    #region Fields
    
    private readonly ITestOutputHelper _testOutputHelper;
    
    #endregion

    #region Constructor(s)

    public DateTimeExtensionsTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    #endregion
    
    #region Test Methods (GetMillisecondsSinceUnixEpoch)

    [Fact]
    public void GetMillisecondsSinceUnixEpoch_DateTimeIsUnixEpoch_IsZero()
    {
        DateTime dateTime = DateTime.UnixEpoch;
        
        Assert.Equal(0, dateTime.GetMillisecondsSinceUnixEpoch());
    }
    
    [Fact]
    public void GetMillisecondsSinceUnixEpoch_DateTimeIsOneDayAfterUnixEpoch_IsEightySixThousandFourHundred()
    {
        DateTime dateTime = DateTime.UnixEpoch.AddDays(1);
        
        Assert.Equal(86400000, dateTime.GetMillisecondsSinceUnixEpoch());
    }
    
    [Fact]
    public void GetMillisecondsSinceUnixEpoch_DateTimeIsOneDayBeforeUnixEpoch_IsNegativeEightySixThousandFourHundred()
    {
        DateTime dateTime = DateTime.UnixEpoch.AddDays(-1);
        
        Assert.Equal(-86400000, dateTime.GetMillisecondsSinceUnixEpoch());
    }
    
    [Fact]
    public void GetMillisecondsSinceUnixEpoch_DateTimeIsOneSecondAfterUnixEpoch_IsOneThousand()
    {
        DateTime dateTime = DateTime.UnixEpoch.AddSeconds(1);
        
        Assert.Equal(1000, dateTime.GetMillisecondsSinceUnixEpoch());
    }
    
    [Fact]
    public void GetMillisecondsSinceUnixEpoch_DateTimeIsOneSecondBeforeUnixEpoch_IsNegativeOneThousand()
    {
        DateTime dateTime = DateTime.UnixEpoch.AddSeconds(-1);
        
        Assert.Equal(-1000, dateTime.GetMillisecondsSinceUnixEpoch());
    }
    
    [Fact]
    public void GetMillisecondsSinceUnixEpoch_DateTimeIsOneMillisecondAfterUnixEpoch_IsOne()
    {
        DateTime dateTime = DateTime.UnixEpoch.AddMilliseconds(1);
        
        Assert.Equal(1, dateTime.GetMillisecondsSinceUnixEpoch());
    }
    
    [Fact]
    public void GetMillisecondsSinceUnixEpoch_DateTimeIsOneMillisecondBeforeUnixEpoch_IsNegativeOne()
    {
        DateTime dateTime = DateTime.UnixEpoch.AddMilliseconds(-1);
        
        Assert.Equal(-1, dateTime.GetMillisecondsSinceUnixEpoch());
    }
    
    [Fact]
    public void GetMillisecondsSinceUnixEpoch_DateTimeIsOneMillisecondBeforeAndAfterUnixEpoch_IsZero()
    {
        DateTime dateTime = DateTime.UnixEpoch.AddMilliseconds(-1).AddMilliseconds(1);
        
        Assert.Equal(0, dateTime.GetMillisecondsSinceUnixEpoch());
    }
    
    [Fact]
    public void GetMillisecondsSinceUnixEpoch_DateTimeIsOneSecondBeforeAndAfterUnixEpoch_IsZero()
    {
        DateTime dateTime = DateTime.UnixEpoch.AddSeconds(-1).AddSeconds(1);
        
        Assert.Equal(0, dateTime.GetMillisecondsSinceUnixEpoch());
    }
    
    [Fact]
    public void GetMillisecondsSinceUnixEpoch_DateTimeIsOneDayBeforeAndAfterUnixEpoch_IsZero()
    {
        DateTime dateTime = DateTime.UnixEpoch.AddDays(-1).AddDays(1);
        
        Assert.Equal(0, dateTime.GetMillisecondsSinceUnixEpoch());
    }
    
    [Fact]
    public void GetMillisecondsSinceUnixEpoch_DateTimeIsOneYearBeforeUnixEpoch_IsNegative31_536_000_000()
    {
        DateTime dateTime = DateTime.UnixEpoch.AddYears(-1);
        
        Assert.Equal(-31536000000, dateTime.GetMillisecondsSinceUnixEpoch());
    }
    
    [Fact]
    public void GetMillisecondsSinceUnixEpoch_DateTimeIsOneYearAfterUnixEpoch_Is31_536_000_000()
    {
        DateTime dateTime = DateTime.UnixEpoch.AddYears(1);
        
        Assert.Equal(31536000000, dateTime.GetMillisecondsSinceUnixEpoch());
    }
    
    [Fact]
    public void GetMillisecondsSinceUnixEpoch_DateTimeIsOneYearBeforeAndAfterUnixEpoch_IsZero()
    {
        DateTime dateTime = DateTime.UnixEpoch.AddYears(-1).AddYears(1);
        
        Assert.Equal(0, dateTime.GetMillisecondsSinceUnixEpoch());
    }
    
    [Fact]
    public void GetMillisecondsSinceUnixEpoch_DateTimeIsOneYearBeforeAndOneDayAfterUnixEpoch_IsNegative31_535_680_000()
    {
        DateTime dateTime = DateTime.UnixEpoch.AddYears(-1).AddDays(1);
        
        Assert.Equal(-31449600000, dateTime.GetMillisecondsSinceUnixEpoch());
    }
    
    #endregion
}