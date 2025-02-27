using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domaines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.configuration
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasMany(f => f.Passengers)
                .WithMany(f => f.Flights)
                .UsingEntity(t => t.ToTable("flight_pass_table"));
            builder.HasOne(f => f.Plane)
                .WithMany(p => p.Flights)
                //.HasForeignKey(fk=>fk.PlaneFk); commented because it is done already with annottion
            
        }
    }
}
