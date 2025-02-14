using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domaine;
using AM.ApplicationCore.Domaines;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethods
    {
        public List<DateTime> getFlightDates(string destination);
        void showFlightDetails(Plane plane);
        public int ProgrammedFlightNumber(DateTime startDate);
        public double DurationAverage(string destination);
        public IEnumerable<Flight> OrderedDurationFlights();
        public IEnumerable<Traveller> SeniorTravellers(Flight flight);



    }
}
