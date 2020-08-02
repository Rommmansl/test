using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testWork.Models
{
    class Category : Decorator
    {
        string category_name;
        public Category(Worker p, string perem) : base(p)
        {
            category_name = perem;
        }
        public override int GetSalary()
        {
            if (category_name.ToString() == "A")
            {
                return (Convert.ToInt32(worker.GetSalary()) * 125 / 100);
            }
            if (category_name.ToString() == "B")
            {
                return (Convert.ToInt32(worker.GetSalary()) * 115 / 100);
            }
            if (category_name.ToString() == "C")
            {
                return Convert.ToInt32(worker.GetSalary());
            }
            else
            {
                return worker.GetSalary();
            }
        }
    }
}
