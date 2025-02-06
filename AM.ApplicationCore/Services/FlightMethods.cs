using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domaines;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> flights = new List<Flight>();

        public List<DateTime> getFlightDates(string destination)
        {
            List<DateTime> dates = new List<DateTime>();
            for(int i =0;i<flights.Count;i++)
            {
                if(flights[i].Destination == destination)
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
                    for(int i = 0;i<flights.Count;i++)
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



    }


}
