using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domaines
{
    public class Passenger
    {
        [Display(Name = "Date of birth"),DataType(DataType.Date)]

        public DateTime BirthDate { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string EmailAddress {  get; set; }
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Name should be between 3 and 25 characters.")]
        public string FirstName {  get; set; }
        //public int Id {  get; set; } commentedbecause itis no loonger used as a primary key 
        public string LastName { get; set; }
        [Key, StringLength(7)]
        public string PassportNumber { get; set; }
        [RegularExpression(@"^\d{8}$",ErrorMessage ="le phone number ")]
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
