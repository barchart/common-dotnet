#region Using Statements

using Barchart.Common.Core;
using Barchart.Common.Core.Exceptions;

#endregion

namespace Barchart.Common.Tests.Core;

public class CurrencyConverterTests
{
    #region Constants
    
    private const float TOLERANCE = 0.0001f;
    
    #endregion
        
    #region Fields
    
    ITestOutputHelper _testOutputHelper;
  
    private readonly Currency _source = Currency.USD;
    private readonly Currency _target = Currency.EUR;
    
    #endregion

    #region Constructor(s)
    
    public CurrencyConverterTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
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
    
    [Fact]
    public void SetExchangeRate_ZeroRate_ThrowsInvalidExchangeRateException()
    {
        CurrencyConverter converter = new();
        float rate = 0f;

        Assert.Throws<InvalidExchangeRateException>(() => converter.SetExchangeRate(_source, _target, rate));
    }
    
    #endregion
    
    #region TestMethods (GetExchangeRate)

    [Fact]
    public void GetExchangeRate_InvalidData_ThrowsExchangeRateNotFoundException()
    {
        CurrencyConverter converter = new();
        
        Assert.Throws<ExchangeRateNotFoundException>(() => converter.GetExchangeRate(_source, _target));
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

    #endregion
    
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
}