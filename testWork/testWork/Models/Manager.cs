using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models
{
    class Manager : Worker
    {
        int salary = 0;
        public Manager(int _salary)
        {
            salary = _salary;
        }
        public override int GetSalary()
        {
            return salary;
        }
    }
}
