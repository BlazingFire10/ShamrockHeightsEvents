using System;
using Microsoft.EntityFrameworkCore;

namespace ShamrockHeightsEvents.Models
{
        public class EventsDBContext : DbContext
        {
            public EventsDBContext(DbContextOptions<EventsDBContext> options) : base(options)
            {

            }

            public DbSet<Event> Events { get; set; }
        }

}
