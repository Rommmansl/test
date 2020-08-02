using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models
{
    abstract class Worker
    {
        public Worker()
        {
        }
        public abstract int GetSalary();
    }
}
