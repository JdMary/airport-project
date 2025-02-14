IEnumerable<T> → Use when you only need to iterate over elements (read-only).

ICollection<T> → Use when you need to modify elements but don't need index-based access.

IList<T> → Use when you need full list functionality, including indexing.

```
public void showFlightDetails(Plane plane)
{
    var query = flights
        .Where(f => f.Plane == plane)  
        .Select(f => new { f.FlightDate, f.Destination }); 

    foreach (var flight in query)
        Console.WriteLine($"Destination: {flight.Destination}, FlightDate: {flight.FlightDate}");
}

```
+ Where(f => f.Plane == plane) → Filters the flights collection based on the given plane.
+ Select(f => new { f.FlightDate, f.Destination }) → Extracts only necessary properties.
