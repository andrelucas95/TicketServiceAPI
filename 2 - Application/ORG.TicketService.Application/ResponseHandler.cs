using System.Net;

namespace ORG.TicketService.Application;

public class ResponseHandler
{
    private readonly List<string> _messages;
    public ResponseHandler()
    {
        _messages = new List<string>();
    }
    
    public bool Success { get; private set; }
    public HttpStatusCode StatusCode { get; private set; }
    public dynamic Data { get; private set; }
    public IReadOnlyCollection<string> Messages => _messages.AsReadOnly();
    
    public static ResponseHandler CreateSuccessResponse()
    {
        return new ResponseHandler() { Success = true };
    }
    
    public static ResponseHandler CreateFailResponse()
    {
        return new ResponseHandler() { Success = false };
    }
    
    public ResponseHandler WithStatusCode(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
        return this;
    }
    
    public ResponseHandler WithData(dynamic data)
    {
        Data = data;
        return this;
    }
    
    public ResponseHandler WithMessage(string message)
    {
        _messages.Add(message);
        return this;
    }
    
    public ResponseHandler WithMessages(IEnumerable<string> messages)
    {
        _messages.AddRange(messages);
        return this;
    }
    
    public void AddMessage(string message)
    {
        _messages.Add(message);
    }
}