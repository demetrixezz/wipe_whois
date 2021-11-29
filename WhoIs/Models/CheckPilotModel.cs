using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoIs.Models
{
    public class CheckPilotModel
    {
        public string Name { get; set; }

        public bool IsPilotInDB { get; set; }

        public bool noPilotTypes { get; set; }

        public bool IsFriend { get; set; }

        public bool IsEnemy { get; set; }

        public bool IsWorstEnemy { get; set; }

        public bool IsObserver { get; set; }

        public bool IsGuest { get; set; }

        public bool IsClogger { get; set; }

        public bool IsCheater { get; set; }

        public bool IsSpear { get; set; }

        public bool IsOther { get; set; }

        
    }
}
