﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domaines
{
    public class Staff : Passenger
    {
        public DateTime EmploymentDate { get; set; }
        public string Function { get; set; }
        [DataType(DataType.Currency)]
        public double Salary { get; set; }
        public override void PassenerType()
        {
            //base signifies super like in java
            base.PassenerType();
            Console.WriteLine("I am staff ");
        }
    }
}
