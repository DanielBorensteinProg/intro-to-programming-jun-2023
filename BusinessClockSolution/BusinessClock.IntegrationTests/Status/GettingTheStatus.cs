
using Alba;
using BusinessClockApi.Models;
using System.Net;

namespace BusinessClock.IntegrationTests.Status;

public class GettingTheStatus
{
    [Fact]
    public async Task OpenHours()
    {
        var host = await AlbaHost.For<Program>();

       var response = await host.Scenario(api =>
        {
            api.Get.Url("/status");
            api.StatusCodeShouldBeOk();
        });

        Assert.NotNull(response); // did we get something back?
        GetStatusResponse? responseMessage = response.ReadAsJson<GetStatusResponse>();
        Assert.NotNull(responseMessage);
        Assert.True(responseMessage.Open);
        Assert.Null(responseMessage.OpensAt);
    }

    [Fact]
    public async Task ClosedHours()
    {
        var host = await AlbaHost.For<Program>();

        var response = await host.Scenario(api =>
        {
            api.Get.Url("/status");
            api.StatusCodeShouldBeOk();
        });

        Assert.NotNull(response); // did we get something back?
        GetStatusResponse? responseMessage = response.ReadAsJson<GetStatusResponse>();
        Assert.NotNull(responseMessage);
        Assert.False(responseMessage.Open);
        Assert.NotNull(responseMessage.OpensAt);
    }
}
