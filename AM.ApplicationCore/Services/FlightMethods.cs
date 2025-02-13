using System;
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
        public List<Flight> flights {  get; set;} = new List<Flight>();
 
public List<DateTime> getFlightDates(string destination)
        {
            List<DateTime> dates = new List<DateTime>();
            for (int i = 0; i < flights.Count; i++)
            {

                if (flights[i].Destination == destination)
                {
                    dates.Add(flights[i].FlightDate);

                }

            }
            return dates;
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
            switch (filterType)
            {
                case "Departure":
                    for (int i = 0; i < flights.Count; i++)
                    {
                        if (flights[i].Departure == filterValue)
                        {
                            Console.WriteLine(flights[i]);
                        }
                    }

                    break;
                case "Destination":
                    for (int i = 0; i < flights.Count; i++)
                    {
                        if (flights[i].Destination == filterValue)
                        {
                            Console.WriteLine(flights[i]);
                        }
                    }
                    break;
                case "EffectiveArrival":
                    for (int i = 0; i < flights.Count; i++)
                    {
                        if (flights[i].EffectiveArrival == DateTime.Parse(filterValue))
                        {
                            Console.WriteLine(flights[i]);
                        }
                    }
                    break;

                case "EstimatedDuration":
                    for (int i = 0; i < flights.Count; i++)
                    {
                        if (flights[i].EstimatedDuration == int.Parse(filterValue))
                        {
                            Console.WriteLine(flights[i]);
                        }
                    }
                    break;
                case "FlightDate":
                    for (int i = 0; i < flights.Count; i++)
                    {
                        if (flights[i].FlightDate == DateTime.Parse(filterValue))
                        {
                            Console.WriteLine(flights[i]);
                        }
                    }
                    break;
            }
        }
        //var est un type  anonyme qui peut contenir tous les types indéfinis des variables 
        //public void GetFlightsEnumerable(string filterType, string filterValue)
        //{
        //    IEnumerable<Flight> filteredFlights = flights;

        //    switch (filterType)
        //    {
        //        case "Departure":
        //            filteredFlights = flights.Where(f => f.Departure == filterValue);
        //            break;
        //        case "Destination":
        //            filteredFlights = flights.Where(f => f.Destination == filterValue);
        //            break;
        //        case "EffectiveArrival":
        //            if (DateTime.TryParse(filterValue, out DateTime arrivalDate))
        //                filteredFlights = flights.Where(f => f.EffectiveArrival == arrivalDate);
        //            else
        //                Console.WriteLine("Invalid date format for EffectiveArrival.");
        //            break;
        //        case "EstimatedDuration":
        //            if (int.TryParse(filterValue, out int duration))
        //                filteredFlights = flights.Where(f => f.EstimatedDuration == duration);
        //            else
        //                Console.WriteLine("Invalid number format for EstimatedDuration.");
        //            break;
        //        case "FlightDate":
        //            if (DateTime.TryParse(filterValue, out DateTime flightDate))
        //                filteredFlights = flights.Where(f => f.FlightDate == flightDate);
        //            else
        //                Console.WriteLine("Invalid date format for FlightDate.");
        //            break;
        //        default:
        //            Console.WriteLine("Invalid filter type.");
        //            return;
        //    }

        //    foreach (var flight in filteredFlights)
        //    {
        //        Console.WriteLine(flight);
        //    }



        //}
        //// Simple LINQ function example
        //public List<string> GetAllDestinations()
        //{
        //    return flights.Select(f => f.Destination).Distinct().ToList();
        //}

        //// Another LINQ function example
        //public Flight GetLongestDurationFlight()
        //{
        //    return flights.OrderByDescending(f => f.EstimatedDuration).FirstOrDefault();
        //}

        //// Different LINQ function example
        //public double GetAverageFlightDuration()
        //{
        //    return flights.Average(f => f.EstimatedDuration);
        //}

        public void showFlightDetails(Plane plane)
        {
         
            var query=from f in flights 
                      where f.Plane == plane
                      select new { f.FlightDate, f.Destination };
         foreach (var flight in query) 
                Console.WriteLine("Destination :" + flight.Destination + " FlightDate : "+ flight.FlightDate);
                      
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //return (from f in flights
            //            where f.FlightDate.Date == startDate || f.FlightDate.Date < startDate.AddDays(7)
            //            select f).Count();
            
             var query = from f in flights
                         where DateTime.Compare( startDate, f.FlightDate) <=0 && (f.FlightDate - startDate ).TotalDays<=7
                         select f;
            return query.Count();
            
         }

        public double DurationAverage(string destination)
        {
            var q = from f in flights
                    where f.Destination == destination
                    select f.EstimatedDuration;
            return q.Average();
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            var q= from f in flights 
                   orderby f.EstimatedDuration descending
                   select f;
            return q;   
                   
        }
       

        IEnumerable<Passenger> SeniorTravellers(Flight flight)
        {
            //var q = from item in flight.Passengers
            //        where item.GetType() == typeof(Traveller)
            //        orderby item.BirthDate
            //        select item;

            var q = from item in flight.Passengers.OfType<Traveller>()
                    orderby item.BirthDate
                    select item;
            return q.Take(3);
        }
    }


}
