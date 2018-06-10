using System;
using Gtk;
namespace KursachAttemp2.Models
{
    public class CustomGtkButton : Button
    {
        public int WayIndex { get; set; }
        public int StopIndex { get; set; }
        public string Type { get; set; }
        public object TitleEntry { get; private set; }
        public object TimeEntry { get; private set; }
        public object PositionEntry { get; private set; }
        public CustomGtkButton(int wayIndex, int stopIndex, string type, object titleEntry = null, object timeEntry = null, object positionEntry = null)
            : base()
        {
            WayIndex = wayIndex;
            StopIndex = stopIndex;
            Type = type;
            TitleEntry = titleEntry;
            TimeEntry = timeEntry;
            PositionEntry = positionEntry;
        }
    }
}
