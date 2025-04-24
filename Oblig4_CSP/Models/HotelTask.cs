using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig4_CSP.Models
{
    internal class HotelTask
    {
        public Room room { get; set; }
        public RoomStatus type { get; set; }
        public TaskStats status { get; set; }
        public string description { get; set; }

        public HotelTask(Room rom, RoomStatus tt, string desc) { room = rom; type = tt; description = desc; status = TaskStats.New; }
    }
}
