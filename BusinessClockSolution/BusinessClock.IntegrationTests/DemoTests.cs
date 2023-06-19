

namespace BusinessClock.IntegrationTests;

public class DemoTests
{
    [Fact]
    public void CanAddTwoNumbers()
    {
        // Given
        int a = 10, b = 20, answer;
        // When
        answer = a + b; // "System under test" (SUT)
        // Then
        Assert.Equal(30, answer);

    }

    [Theory]
    [InlineData(10,20, 30)]
    [InlineData(2,2,4)]
    [InlineData(8,2,10)]
    public void CanAddAnyTwoNumbers(int a, int b, int expected)
    {
        int answer = a + b;
        Assert.Equal(expected, answer);
    }
}
