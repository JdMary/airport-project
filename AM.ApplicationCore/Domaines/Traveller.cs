using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domaines
{
    public class Traveller : Passenger
    {
        public string HealthInformation { get; set; }
        public string Nationality { get; set; }
        public override void PassenerType()
        {
            base.PassenerType();
            Console.WriteLine("iam Traveller");
        }
    }
}
