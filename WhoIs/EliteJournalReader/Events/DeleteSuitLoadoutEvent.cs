using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EliteJournalReader.Events
{
    public class DeleteSuitLoadoutEvent : JournalEvent<DeleteSuitLoadoutEvent.DeleteSuitLoadoutEventArgs>
    {
        public DeleteSuitLoadoutEvent() : base("DeleteSuitLoadout") { }

        public class DeleteSuitLoadoutEventArgs : JournalEventArgs
        {
            public long SuitID { get; set; }
            public string SuitName { get; set; }
            public long LoadoutID { get; set; }
            public string LoadoutName { get; set; }
        }
    }
}