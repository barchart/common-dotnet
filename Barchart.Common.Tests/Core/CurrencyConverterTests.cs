#region Using Statements

using Barchart.Common.Core;

#endregion

namespace Barchart.Common.Tests.Core;

public class CurrencyConverterTests
{
    #region Fields
    
    ITestOutputHelper _testOutputHelper;
  
    private readonly Currency _source;
    private readonly Currency _target;
    
    private const float TOLERANCE = 0.0001f;
    
    #endregion

    #region Constructor(s)
    
    public CurrencyConverterTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
     
        _source = new Currency("USD", "US Dollar", 2, "US$"); 
        _target = new Currency("EUR", "Euro", 2, "EUR");
    }
    
    #endregion

    #region Test Methods (SetExchangeRate)
    
    [Fact]
    public void SetExchangeRate_ValidRate_StoresRate()
    {
        CurrencyConverter converter = new();
        const float rate = 0.85f;

        converter.SetExchangeRate(_source, _target, rate);

        Assert.True(converter.HasExchangeRate(_source, _target));
        Assert.True(converter.HasExchangeRate(_target, _source));
        Assert.True(Math.Abs(converter.GetExchangeRate(_source, _target) - rate) < TOLERANCE);
    }
    
    #endregion
    
    [Fact]
    public void SetExchangeRate_ZeroRate_ThrowsArgumentException()
    {
        CurrencyConverter converter = new();
        float rate = 0f;

        Assert.Throws<ArgumentException>(() => converter.SetExchangeRate(_source, _target, rate));
    }
    
    #region TestMEthods (GetExchangeRate)

    [Fact]
    public void GetExchangeRate_InvalidData_ThrowsInvalidOperationException()
    {
        CurrencyConverter converter = new();
        
        Assert.Throws<InvalidOperationException>(() => converter.GetExchangeRate(_source, _target));
    }
    
    [Fact]
    public void GetExchangeRate_ValidData_ReturnsRate()
    {
        CurrencyConverter converter = new();
        float rate = 0.85f;
        
        converter.SetExchangeRate(_source, _target, rate);

        float result = converter.GetExchangeRate(_source, _target);

        Assert.Equal(rate, result);
    }

    #endregion

    #region Test Methods (Convert)
    
    [Fact]
    public void Convert_ValidAmount_ConvertsAmount()
    {
        CurrencyConverter converter = new();
        float rate = 0.85f;
        float amount = 100f;
        float expected = 85f;
        
        converter.SetExchangeRate(_source, _target, rate);

        float result = converter.Convert(_source, _target, amount);

        Assert.Equal(expected, result);
    }

    #region Test Methods (HasExchangeRate)

    [Fact]
    public void HasExchangeRate_ExchangeRateExists_ReturnsTrue()
    {
        CurrencyConverter converter = new();
        float rate = 0.85f;
        
        converter.SetExchangeRate(_source, _target, rate);

        Assert.True(converter.HasExchangeRate(_source, _target));
        Assert.True(converter.HasExchangeRate(_target, _source));

    }
    
    [Fact]
    public void HasExchangeRate_ExchangeRateDoesNotExist_ReturnsFalse()
    {
        CurrencyConverter converter = new();

        Assert.False(converter.HasExchangeRate(_source, _target));
    }
    
    #endregion
    
    #endregion
}