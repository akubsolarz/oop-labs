using Simulator;

namespace TestSimulator;

public class ValidatorTests
{


    [Theory]
    [InlineData("   Shrek    ",3 ,25 ,'#', "Shrek")]
    [InlineData("   ",3 ,25 , '#', "###")]
    [InlineData("      ", 6, 10, '$', "$$$$$$")]
    [InlineData("a     ", 3, 10, '$', "A$$")]
    [InlineData("  donkey ", 3, 25, '#', "Donkey")]
    [InlineData("Puss in Boots – a clever and brave cat.", 3, 25, '#', "Puss in Boots – a clever")]
    [InlineData("a            troll name",3,25,'#', "A            troll name")]
    public void Shortener_whitespace(string input, int min, int max, char placeholder, string? expected)
    {
        
        var result = Validator.Shortener(input, min, max, placeholder);

        
        Assert.Equal(expected, result);
       
        
    }


    [Theory]
    [InlineData(11,1,10,10)]  
    [InlineData(-5,2,10,2)]   
    [InlineData(20,1,16,16)]    
    [InlineData(0,5,10,5)]   
    [InlineData(4,4,10,4)]
    public void Limiter_range(int inputLevel, int min, int max,  int expectedLevel)
    {

        var result = Validator.Limiter(inputLevel, min, max);

        Assert.Equal(expectedLevel, result);
    }
}