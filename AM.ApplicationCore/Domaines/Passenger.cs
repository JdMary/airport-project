﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
