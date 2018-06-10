using System;
using Gtk;
namespace KursachAttemp2.Models
{
    public class CustomGtkEntry : Entry
    {
        public int WayIndex { get; private set; }
        public int StopIndex { get; private set; }
        public string Type { get; private set; }
        public CustomGtkEntry(int wayIndex, int stopIndex, string type)
            : base()
        {
            WayIndex = wayIndex;
            StopIndex = stopIndex;
            Type = type;
        }
    }
}
