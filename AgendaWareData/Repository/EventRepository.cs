using AgendaWare.Models;
using AgendaWareData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaWareData.Repository
{
    public class EventRepository : IEventRepository
    {

        private AgendaWareDbContext _context;

        public EventRepository(AgendaWareDbContext context)
        {
            _context = context;
        }

        public IQueryable<Event> Events => _context.Events;

        public void CreateEvent(Event @event)
        {
            _context.Events.Add(@event);
            _context.SaveChanges();
        }

        public void DeleteEvent(int eventid)
        {
            var @event = GetById(eventid);

            if (@event != null)
            {
                _context.Events.Remove(@event);
                _context.SaveChanges();
            }
        }

        public Event GetById(int eventId)
        {
            return _context.Events.FirstOrDefault(i => i.id == eventId);
        }

        public void UpdateEvent(Event @event)
        {
            _context.Events.Update(@event);
            _context.SaveChanges();
        }
    }
}
