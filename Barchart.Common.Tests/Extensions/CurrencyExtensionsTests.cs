#region Using Statements

using Barchart.Common.Core;
using Barchart.Common.Extensions;

#endregion

namespace Barchart.Common.Tests.Extensions;

public class CurrencyExtensionsTests
{
    #region Fields
    
    private readonly ITestOutputHelper _testOutputHelper;
    
    #endregion

    #region Constructor(s)
    
    public CurrencyExtensionsTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    #endregion

    #region Test Methods (GetDescription)

    [Fact]
    public void GetDescription_ValidCurrency_ReturnsDescription()
    {
        Assert.Equal("US Dollar", Currency.USD.GetDescription());
    }
    
    #endregion

    #region Test Methods (GetPrecision)
    
    [Fact]
    public void GetPrecision_ValidCurrency_ReturnsPrecision()
    {
        Assert.Equal(2, Currency.USD.GetPrecision());
    }
    
    #endregion

    #region Test Methods (GetAlternateDescription)
    
    [Fact]
    public void GetAlternateDescription_ValidCurrency_ReturnsAlternateDescription()
    {
        Assert.Equal("US$", Currency.USD.GetAlternateDescription());
    }

    #endregion

    #region Test Methods (FromCode)
    
    [Fact]
    public void FromCode_ValidCode_ReturnsCurrency()
    {
        Currency? result = CurrencyExtensions.FromCode("USD");

        Assert.NotNull(result);
        Assert.Equal(Currency.USD, result);
    }

    [Fact]
    public void FromCode_InvalidCode_ReturnsNull()
    {
        Currency? result = CurrencyExtensions.FromCode("INVALID");

        Assert.Null(result);
    }
    
    #endregion

    #region Test Methods (TryParse)

    [Fact]
    public void TryParse_ValidCode_ReturnsTrueAndCurrency()
    {
        bool success = CurrencyExtensions.TryParse("AUD", out Currency? currency);

        Assert.True(success);
        Assert.NotNull(currency);
        Assert.Equal(Currency.AUD, currency);
    }

    [Fact]
    public void TryParse_InvalidCode_ReturnsFalseAndNull()
    {
        bool success = CurrencyExtensions.TryParse("INVALID", out Currency? currency);

        Assert.False(success);
        Assert.Null(currency);
    }
    
    #endregion

    #region Test Methods (Equals)

    [Fact]
    public void Equals_SameCode_ReturnsTrue()
    {
        Currency currency1 = Currency.USD;
        Currency? currency2 = CurrencyExtensions.FromCode("USD");

        Assert.True(currency1.Equals(currency2));
    }
    
    #endregion

    #region Test Methods (GetHashCode)

    [Fact]
    public void GetHashCode_SameCode_ReturnsSameHash()
    {
        Currency currency1 = Currency.USD;
        Currency? currency2 = CurrencyExtensions.FromCode("USD");

        Assert.NotNull(currency2);
        Assert.Equal(currency1.GetHashCode(), currency2.GetHashCode());
    }

    #endregion
    
    #region Test Methods (GetItems)

    [Fact]
    public void GetItems_WhenCalled_ReturnsAllCurrencies()
    {
        List<Currency> items = CurrencyExtensions.GetItems().ToList();

        Assert.NotEmpty(items);
        Assert.Contains(items, x => x == Currency.USD);
        Assert.Contains(items, x => x == Currency.EUR);
    }
    
    #endregion
}