﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testWork.Models
{
    class Technician : Worker
    {
        int salary = 0;
        public Technician(int _salary)
        {
            salary = _salary;
        }
        public override int GetSalary()
        {
            return salary;
        }
    }
}
