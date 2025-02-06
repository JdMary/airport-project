using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domaines
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }
        public string EmailAddress {  get; set; }
        public string FirstName {  get; set; }
        public int Id {  get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public int TelNumber { get; set; }
        public ICollection<Flight> Flights { get; set; }
        public bool checkProfile(string nom,string prenom)
        {
            return nom == LastName && prenom == FirstName;
        }
        public bool checkProfile(string nom, string prenom,string email)
        {
            return nom == LastName && prenom == FirstName && email == EmailAddress;
        }
        //this function combines the above functions and we used null in parameters which makes it flexible to use
        public bool checkProfileCombined(string nom, string prenom, String email=null)
        {
            if(email == null)
            {
                return nom == LastName && prenom ==FirstName;
            }
            return nom == LastName && prenom == FirstName && email == EmailAddress;

        }
        public virtual void PassenerType()
        {
            Console.WriteLine("i am oassenger mimi <3");
        }

    }
}
