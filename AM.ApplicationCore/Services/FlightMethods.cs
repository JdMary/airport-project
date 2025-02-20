using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domaine;
using AM.ApplicationCore.Domaines;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> flights { get; set; } = new List<Flight>();

        public List<DateTime> getFlightDates(string destination)
        {

            //old manner

            //List<DateTime> dates = new List<DateTime>();
            //for (int i = 0; i < flights.Count; i++)
            //{

            //    if (flights[i].Destination == destination)
            //    {
            //        dates.Add(flights[i].FlightDate);

            //    }

            //}
            //return dates;

            //lambda expression:
            return flights.Where(f => f.Destination == destination).Select(f => f.FlightDate).ToList();

        }
        public List<DateTime> getFlightDatesWithForeach(string destination)
        {
            List<DateTime> dates = new List<DateTime>();
            foreach (Flight flight in flights)
            {
                if (flight.Destination == destination)
                {
                    dates.Add(flight.FlightDate);

                }
            }
            return dates;
             

        }
        public void GetFlights(string filterType, string filterValue)
        {
            IEnumerable<Flight> query;
            switch (filterType)
            {
                case "Departure":
                    query = flights.Where(f => f.Departure == filterValue);


                    break;
                case "Destination":
                    query = flights.Where(f => f.Destination == filterValue);

                    break;
                case "EffectiveArrival":
                    query = flights.Where(f => f.EffectiveArrival == DateTime.Parse(filterValue));

                    break;

                case "EstimatedDuration":
                    query = flights.Where(f => f.EstimatedDuration == int.Parse(filterValue));

                    break;
                case "FlightDate":
                    query = flights.Where(f => f.FlightDate == DateTime.Parse(filterValue));

                    break;
            }
        }
        //var est un type  anonyme qui peut contenir tous les types indéfinis des variables 
       


        public void showFlightDetails(Plane plane)
        {

            //var query = from f in flights
            //               where f.Plane == plane
            //               select new { f.FlightDate, f.Destination };
            //   foreach (var flight in query)
            //       Console.WriteLine("Destination :" + flight.Destination + " FlightDate : " + flight.FlightDate);
            flights.Where(f => f.Plane == plane).ToList().ForEach(f => Console.WriteLine("Destination: " + f.Destination + " | FlightDate: " + f.FlightDate));

        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //return (from f in flights
            //            where f.FlightDate.Date == startDate || f.FlightDate.Date < startDate.AddDays(7)
            //            select f).Count();



            //var query = from f in flights
            //            where DateTime.Compare(startDate, f.FlightDate) <= 0 && (f.FlightDate - startDate).TotalDays <= 7
            //            select f;
            //return query.Count();

            return flights.Where(f => DateTime.Compare(startDate, f.FlightDate) <= 0 && DateTime.Compare(f.FlightDate, startDate.AddDays(7)) <= 0).Count();



        }

        public double DurationAverage(string destination)
        {
            //var q = from f in flights
            //        where f.Destination == destination
            //        select f.EstimatedDuration;
            //return q.Average();

            return flights.Where(f => f.Destination == destination).Select(f => f.EstimatedDuration).Average();

        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            //var q = from f in flights
            //        orderby f.EstimatedDuration descending
            //        select f;
            //return q;
            return flights.OrderByDescending(f => f.EstimatedDuration);


        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            //var q = from item in flight.Passengers
            //        where item.GetType() == typeof(Traveller)
            //        orderby item.BirthDate
            //        select item;

            //var q = from item in flight.Passengers.OfType<Traveller>()
            //        orderby item.BirthDate
            //        select item;
            //return q.Take(3);

            return flight.Passengers.OfType<Traveller>().OrderBy(p => p.BirthDate).Take(3);

        }
        public void DestinationGroupedFlights()
        {
            //IEnumerable<IGrouping<string, Flight>> q = from f in flights.GroupBy(f => f.Destination);
            //var query = from f in flights
            //            group f by f.Destination;
            //foreach (var group in query)
            //{
            //    Console.WriteLine("destination: "+group.Key);
            //    foreach (var f in group)
            //    {
            //        Console.WriteLine("Decollage: " + f.FlightDate);
            //    }
            //}



            var query = Flights.GroupBy(f => f.Destination);
            foreach (var group in query)
            {
                Console.WriteLine("Destination: " + group.Key);
                foreach (var f in group)
                {
                    Console.WriteLine("Décollage:  " + f.FlightDate);
                }
            }
        }

    }


}
