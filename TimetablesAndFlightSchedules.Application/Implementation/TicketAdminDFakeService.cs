using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Domain.Entities;
using TimetablesAndFlightSchedules.Infrastructure.Database;

namespace TimetablesAndFlightSchedules.Application.Implementation
{
    public class TicketAdminDFakeService : ITicketAdminService
    {
        public IList<Ticket> Select()
        {
            return DatabaseFake.Tickets;
        }

        public void Create(Ticket ticket)
        {
            if (DatabaseFake.Tickets != null &&
                DatabaseFake.Tickets.Count > 0)
            {
                ticket.Id = DatabaseFake.Tickets.Last().Id + 1;
            }
            else
            {
                ticket.Id = 1;
            }

            if (DatabaseFake.Tickets != null)
                DatabaseFake.Tickets.Add(ticket);
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Ticket? ticket =
                DatabaseFake.Tickets.FirstOrDefault(ticket => ticket.Id == id);

            if (ticket != null)
            {
                deleted = DatabaseFake.Tickets.Remove(ticket);
            }

            return deleted;
        }

        public void Edit(Ticket ticketUpdated)
        {
            Ticket? ticket = DatabaseFake.Tickets.FirstOrDefault(v => v.Id == ticketUpdated.Id);
            if (ticket != null)
            {
                ticket.TicketType = ticketUpdated.TicketType;
                ticket.Price = ticketUpdated.Price;
                ticket.NumberOfTickets = ticketUpdated.NumberOfTickets;
            }
        }

    }
}
