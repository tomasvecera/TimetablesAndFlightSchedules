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
    public class TicketAdminService : ITicketAdminService
    {
        TimetablesAndFlightSchedulesDbContext _timetablesAndFlightSchedulesDbContext;

        public TicketAdminService(TimetablesAndFlightSchedulesDbContext timetablesAndFlightSchedulesDbContext)
        {
            _timetablesAndFlightSchedulesDbContext = timetablesAndFlightSchedulesDbContext;
        }

        public IList<Ticket> Select()
        {
            return _timetablesAndFlightSchedulesDbContext.Tickets.ToList();
        }

        public void Create(Ticket ticket)
        {
            if (_timetablesAndFlightSchedulesDbContext.Tickets != null)
            {
                _timetablesAndFlightSchedulesDbContext.Tickets.Add(ticket);
                _timetablesAndFlightSchedulesDbContext.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Ticket? ticket =
                _timetablesAndFlightSchedulesDbContext.Tickets.FirstOrDefault(ticket => ticket.Id == id);

            if (ticket != null)
            {
                _timetablesAndFlightSchedulesDbContext.Tickets.Remove(ticket);
                _timetablesAndFlightSchedulesDbContext.SaveChanges();

                deleted = true;
            }

            return deleted;
        }

        public void Edit(Ticket ticketUpdated)
        {
            Ticket? ticket = 
                _timetablesAndFlightSchedulesDbContext.Tickets.FirstOrDefault(v => v.Id == ticketUpdated.Id);
            if (ticket != null)
            {
                ticket.TicketType = ticketUpdated.TicketType;
                ticket.Price = ticketUpdated.Price;
                ticket.NumberOfTickets = ticketUpdated.NumberOfTickets;

                _timetablesAndFlightSchedulesDbContext.SaveChanges();
            }
        }

    }
}
