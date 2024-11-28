using Barchart.Common.Core;

namespace Barchart.Common.Tests.Core;

public class CurrencyTests
{
    #region Fields
    
    private readonly ITestOutputHelper _testOutputHelper;
    
    #endregion

    #region Constructor(s)
    
    public CurrencyTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    #endregion

    [Fact]
    public void Constructor_ValidInput_InitializesProperties()
    {
        string code = "TEST";
        string description = "Test Currency";
        int precision = 2;
        string alternateDescription = "T$";

        Currency currency = new(code, description, precision, alternateDescription);

        Assert.Equal(code, currency.Code);
        Assert.Equal(description, currency.Description);
        Assert.Equal(precision, currency.Precision);
        Assert.Equal(alternateDescription, currency.AlternateDescription);
    }

    [Fact]
    public void Constructor_MissingAlternateDescription_SetsAlternateDescriptionToDescription()
    {
        string code = "TEST";
        string description = "Test Currency";
        int precision = 2;

        Currency currency = new(code, description, precision);

        Assert.Equal(description, currency.AlternateDescription);
    }

    [Theory]
    [InlineData(null, "Test Currency", 2)]
    [InlineData("TEST", null, 2)]
    [InlineData("TEST", "Test Currency", -1)]
    public void Constructor_InvalidInput_ThrowsArgumentException(string code, string description, int precision)
    {
        Assert.Throws<ArgumentException>(() => new Currency(code, description, precision));
    }

    [Fact]
    public void FromCode_ValidCode_ReturnsCurrency()
    {
        Currency? result = Currency.FromCode("USD");

        Assert.NotNull(result);
        Assert.Equal("USD", result.Code);
    }

    [Fact]
    public void FromCode_InvalidCode_ReturnsNull()
    {
        Currency? result = Currency.FromCode("INVALID");

        Assert.Null(result);
    }
    
    [Fact]
    public void TryParse_ValidCode_ReturnsTrueAndCurrency()
    {
        bool success = Currency.TryParse("AUD", out var currency);

        Assert.True(success);
        Assert.NotNull(currency);
        Assert.Equal("AUD", currency.Code);
    }

    [Fact]
    public void TryParse_InvalidCode_ReturnsFalseAndNull()
    {
        bool success = Currency.TryParse("INVALID", out var currency);

        Assert.False(success);
        Assert.Null(currency);
    }

    [Fact]
    public void Equals_SameCode_ReturnsTrue()
    {
        Currency currency1 = Currency.USD;
        Currency? currency2 = Currency.FromCode("USD");

        Assert.True(currency1.Equals(currency2));
    }

    [Fact]
    public void Equals_DifferentCode_ReturnsFalse()
    {
        Currency currency1 = Currency.USD;
        Currency currency2 = Currency.EUR;

        Assert.False(currency1.Equals(currency2));
    }

    [Fact]
    public void GetHashCode_SameCode_ReturnsSameHash()
    {
        Currency currency1 = Currency.USD;
        Currency? currency2 = Currency.FromCode("USD");

        Assert.NotNull(currency2);
        Assert.Equal(currency1.GetHashCode(), currency2.GetHashCode());
    }

    [Fact]
    public void GetItems_WhenCalled_ReturnsAllCurrencies()
    {
        List<Currency> items = Currency.GetItems().ToList();

        Assert.NotEmpty(items);
        Assert.Contains(items, x => x.Code == "USD");
        Assert.Contains(items, x => x.Code == "EUR");
    }
}