using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoIs.Models
{
    public class SquadDbModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public List<int> SquadTypes { get; set; }
    }
}
