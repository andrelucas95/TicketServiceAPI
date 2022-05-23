using System.ComponentModel;
using ORG.TicketService.Domain.Enums;

namespace ORG.TicketService.Domain.Entities
{
    public class Ticket
    {
        public Ticket() { }
        public Ticket(string title, string description, TicketPriorityType priority)
        {
            Title = title ?? throw new ArgumentNullException(title);
            Description = description ?? throw new ArgumentNullException(description);
            Priority = priority;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketPriorityType Priority { get; set; }
        public DateTime OpenedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public DateTime? CanceledAt { get; set; }

        public void Finish(DateTime finishDate)
        {
            if (!CanAct("finish")) throw new Exception();
            
            FinishedAt = finishDate;
        }
        
        public void Cancel(DateTime cancelDate)
        {
            if (!CanAct("cancel")) throw new Exception();
            
            CanceledAt = cancelDate;
        }

        public bool CanAct(string action)
        {
            return action switch
            {
                "finish" => (!FinishedAt.HasValue && !CanceledAt.HasValue),
                "cancel" => (!FinishedAt.HasValue && !CanceledAt.HasValue),
                _ => throw new InvalidEnumArgumentException()
            };
        }
    }
}