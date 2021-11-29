using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoIs.Models
{
    public class PilotDbModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public List<int> PilotTypes { get; set; }
    }
}
