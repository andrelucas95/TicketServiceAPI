namespace ORG.TicketService.Tests;

[Collection(nameof(TicketCollection))]
public class TicketTest
{
    private readonly TicketTestsFixture _fixture;

    public TicketTest(TicketTestsFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void ShouldFinishTicket()
    {
        var ticket = _fixture.GenerateTicket();
        
        ticket.Finish(DateTime.Now);
        
        Assert.NotNull(ticket.FinishedAt);
    }
    
    [Fact]
    public void ShouldCancelTicket()
    {
        var ticket = _fixture.GenerateTicket();
        
        ticket.Cancel(DateTime.Now);
        
        Assert.NotNull(ticket.CanceledAt);
    }

    [Fact]
    public void ShouldNotFinishTicketAlreadyFinished()
    {
        var ticket = _fixture.GenerateFinishedTicket();
        Assert.Throws<Exception>(() => ticket.Finish(DateTime.Now));
    }
    
    [Fact]
    public void ShouldNotCancelTicketAlreadyCanceled()
    {
        var ticket = _fixture.GenerateCanceledTicket();
        Assert.Throws<Exception>(() => ticket.Cancel(DateTime.Now));
    }
}