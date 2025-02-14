// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domaine;
using AM.ApplicationCore.Domaines;
using AM.ApplicationCore.Services;

Console.WriteLine("Hello, World!");
//Plane p=new Plane();
//Console.WriteLine(p.ToString());
//Passenger passenger = new Passenger
//{
//    FirstName = "Mariem",
//    LastName = "Jrad"
//};
//Passenger p2 = new Passenger
//{
//    FirstName = "Rami",
//    LastName = "Tabib",
//    EmailAddress = "rami@esprit.tn"
//};
//Staff staff = new Staff
//{
//    FirstName = "kiddy",
//    LastName = "biddy"
//};
//Traveller traveller = new Traveller
//{
//    FirstName = "kiddy",
//    LastName = "travelller",
//};
//Console.WriteLine(passenger.checkProfile("Jrad","Mariem"));
//Console.WriteLine(p2.checkProfileCombined("Tabib", "Rami"));
//staff.PassenerType();
/////instance of service
FlightMethods fm = new FlightMethods();
fm.flights = TestData.listFlights;
List<DateTime> dates = fm.getFlightDates("Paris");
foreach (DateTime d in dates)
{
    Console.WriteLine(d.ToString());
}

Console.WriteLine("SHOW FLIGHT DETAILS");

fm.showFlightDetails(TestData.BoingPlane);

Console.WriteLine(fm.ProgrammedFlightNumber(DateTime.Parse("2022-01-01")));
foreach (Passenger pass in fm.SeniorTravellers(TestData.flight1))
{
    Console.WriteLine(pass.BirthDate);
}