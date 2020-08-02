using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testWork.Models
{
    abstract class Decorator : Worker
    {
        protected Worker worker;
        public Decorator(Worker work)
        {
            this.worker = work;
        }
    }
}
