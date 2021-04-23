using AgendaWare.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaWareData.Entities
{
    public class AgendaWareDbContext:DbContext
    {
        public AgendaWareDbContext(DbContextOptions<AgendaWareDbContext> options) : base(options)
        {
        }
      
        public DbSet<Event> Events { get; set; }
    }
}
