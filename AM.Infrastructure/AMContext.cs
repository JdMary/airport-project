using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domaine;
using AM.ApplicationCore.Domaines;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure
{
    public class AMContext: DbContext
    {
        //1 DBset
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers{ get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        //2 chaine de connexion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb; 
                                      Initial Catalog=4Arctic4;Integrated Security=true"); 
            base.OnConfiguring(optionsBuilder); }

    }
}
