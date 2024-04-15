using System;

namespace Task1
{
    public class Event
    {
        public Event()
        {
            Description = "Event description";
        }
        public string Description { get; set; }
        public DateTime Time { get; set; }
    }
}