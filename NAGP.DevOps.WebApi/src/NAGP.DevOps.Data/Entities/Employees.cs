using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAGP.DevOps.Data.Entities
{
    public class Employees
    {
        public long Id { get; set; }

        public string? Name { get; set; }

        public int Age { get; set; }

        public DateTime DateOfJoining { get; set; }

    }
}
