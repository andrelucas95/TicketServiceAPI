namespace ORG.TicketService.Domain;

public class DomainResponseHandler
{
    private readonly List<string> _messages;
    public DomainResponseHandler()
    {
        _messages = new List<string>();
    }
    
    public bool Success { get; private set; }
    public dynamic Data { get; private set; }
    
    public IReadOnlyCollection<string> Messages => _messages.AsReadOnly();
    
    public static DomainResponseHandler CreateSuccessResponse()
    {
        return new DomainResponseHandler() { Success = true };
    }
    
    public static DomainResponseHandler CreateFailResponse()
    {
        return new DomainResponseHandler() { Success = false };
    }
    
    public DomainResponseHandler WithData(dynamic data)
    {
        Data = data;
        return this;
    }
    
    public DomainResponseHandler WithMessage(string message)
    {
        _messages.Add(message);
        return this;
    }
    
    public DomainResponseHandler WithMessages(IEnumerable<string> messages)
    {
        _messages.AddRange(messages);
        return this;
    }
    
    public void AddMessage(string message)
    {
        _messages.Add(message);
    }
}