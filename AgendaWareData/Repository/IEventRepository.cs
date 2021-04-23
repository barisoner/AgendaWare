using AgendaWare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgendaWareData.Repository
{
    public interface IEventRepository
    {
        IQueryable<Event> Events { get; }

        void CreateEvent(Event @event);

        void DeleteEvent(int eventid);

        Event GetById(int eventId);

        void UpdateEvent(Event @event);
    }
}
