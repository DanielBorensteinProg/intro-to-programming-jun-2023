
using BusinessClockApi.Models;
using BusinessClockApi.Services;
using Moq;

namespace BusinessClock.UnitTests;

public class BusinessClockTests
{

    [Fact]
    public void ClosedOnSaturday()
    {
        // Given 
        // It is a Saturday
        var stubbedSaturdaySystemTime = new Mock<ISystemTime>();
        stubbedSaturdaySystemTime.Setup(c => c.GetCurrent())
                .Returns(new DateTime(2023, 6, 17, 9, 5, 00));
        BusinessClockService clock = new BusinessClockService(stubbedSaturdaySystemTime.Object);

        // When
        GetStatusResponse response = clock.GetCurrentStatus();


        // Then
        Assert.False(response.Open);
    }

    [Fact]
    public void  ClosedOnSunday()
    {
        // Given 
        var stubbedSundayClock = new Mock<ISystemTime>();
        stubbedSundayClock.Setup(c => c.GetCurrent())
            .Returns(new DateTime(2023, 6, 18, 9, 5, 00));
        BusinessClockService clock = new BusinessClockService(stubbedSundayClock.Object);

        // When
        GetStatusResponse response = clock.GetCurrentStatus();


        // Then
        Assert.False(response.Open);
    }

    [Theory]
    [InlineData("6/19/2023 9:00:00 AM")] // monday
    [InlineData("6/19/2023 4:59:59 PM")] // monday
    public void OpenTimes(string dateTime)
    {
        var stubbedClock = new Mock<ISystemTime>();
        stubbedClock.Setup(c => c.GetCurrent()).Returns(DateTime.Parse(dateTime));
        var clock = new BusinessClockService(stubbedClock.Object);

        GetStatusResponse response = clock.GetCurrentStatus();

        Assert.True(response.Open);
    }

    [Theory]
    [InlineData("6/19/2023 8:59:59 AM")] // monday
    [InlineData("6/19/2023 5:00:00 PM")] // monday
    public void ClosedTimes(string dateTime)
    {
        var stubbedClock = new Mock<ISystemTime>();
        stubbedClock.Setup(c => c.GetCurrent()).Returns(DateTime.Parse(dateTime));
        var clock = new BusinessClockService(stubbedClock.Object);

        GetStatusResponse response = clock.GetCurrentStatus();

        Assert.False(response.Open);
    }

}

//public class FakeTimeIsSaturday : ISystemTime
//{
//    public DateTime GetCurrent()
//    {
//        return new DateTime(2023, 6, 17, 9, 5, 00);
//    }
//}

//public class FakeTimeIsSunday : ISystemTime
//{
//    public DateTime GetCurrent()
//    {
//        return new DateTime(2023, 6, 18, 9, 5, 00);
//    }
//}