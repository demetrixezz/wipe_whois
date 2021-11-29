using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoIs.Models
{
    public class CheckSquadModel
    {
        public string Name { get; set; }

        public bool IsSquadInDB { get; set; }

        public bool noSquadTypes { get; set; }

        public bool IsEnemy { get; set; }

        public bool IsAlly { get; set; }

        public bool IsEmpire { get; set; }

        public bool IsFederal { get; set; }

        public bool IsSuspicious { get; set; }
    }
}
