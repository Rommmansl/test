using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testWork.Models
{
    class Bonus : Decorator
    {
        int bonus = 0;
        public Bonus(Worker p, int _bonus) : base(p)
        {
            bonus = _bonus;
        }
        public override int GetSalary()
        {
            return worker.GetSalary() + bonus;
        }
    }
}
