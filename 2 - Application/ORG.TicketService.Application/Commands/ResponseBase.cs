using System.Collections.ObjectModel;

namespace ORG.TicketService.Application.Commands;

public class ResponseBase
{
    private readonly IList<string> _messages = new List<string>();

    public IEnumerable<string> Errors { get; }
    public object Result { get; }

    public ResponseBase() => Errors = new ReadOnlyCollection<string>(_messages);

    public ResponseBase(object result) : this() => Result = result;

    public ResponseBase AddError(string message)
    {
        _messages.Add(message);
        return this;
    }
}