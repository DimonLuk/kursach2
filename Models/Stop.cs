using System;
namespace KursachAttemp2.Models
{
    [Serializable]
    public class Stop
    {
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public double Position { 
            get
            {
                return _position;
            } set
            {
                if (value >= 0)
                    _position = value;
                else
                    throw new ArgumentException();
            }
        }
        private double _position;
        public string StartTimeString
        {
            get 
            {
                return String.Format("{0:00}", Convert.ToInt32(StartTime.Day)) + ":" + StartTime.ToString("HH:mm");    
            }    
        }
        public Stop()
        {
            
        }
        public Stop(string title, string startTime, double position)
        {
            Title = title;
            var tmp = startTime.Split(':');
            StartTime = new DateTime(2018, 12, Convert.ToInt32(tmp[0]), Convert.ToInt32(tmp[1]), Convert.ToInt32(tmp[2]), 0);
            if (position >= 0)
                _position = position;
            else
                throw new ArgumentException();
        }
        public static double operator - (Stop s1, Stop s2)
        {
            return s1.StartTime.Subtract(s2.StartTime).TotalHours;
        }
    }
}
