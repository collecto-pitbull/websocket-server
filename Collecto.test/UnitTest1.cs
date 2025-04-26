namespace Collecto.test;

public class CollectoTest
{
    [Fact]
    public void CollectoAppIsWorking()
    {
        Assert.True(true);
    }
    
    [Theory]
        [InlineData(2,2, 4)]
        [InlineData(2,3, 5)]
        [InlineData(3,3, 6)]
    public void Sum_Operation_return_result(int a, int b, int expected)
    {
        Assert.Equal(expected, a + b);
    }
    
    
}