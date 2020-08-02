using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testWork.Models
{
    class Driver : Worker
    {
        int rate = 0;
        int time = 0;
        public Driver(int _rate, int _time)
        {
            rate = _rate;
            time = _time;
        }
        public override int GetSalary()
        {
            return rate * time;
        }
    }
}
