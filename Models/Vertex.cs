using System;
using System.Collections.Generic;

namespace KursachAttemp2.Models
{
    [Serializable]
    public class Vertex
    {
        private List<Vertex> _adjencent = new List<Vertex>();
        private List<double> _times = new List<double>();
        private List<double> _distances = new List<double>();

        public List<Vertex> Adjacent { get => _adjencent; }
        public List<double> Times { get => _times; }
        public List<double> Distances { get => _distances; }

        public double Distance { get; set; }
        public double Time { get; set; }

        public int Index { get; set; }
        public string Name { get; set; }

        public bool Marked { get; set; }
        public Vertex CameFrom { get; set; }

        public Vertex(int index, string name)
        {
            Index = index;
            Name = name;
            Distance = Double.MaxValue/2;
            Time = Double.MaxValue/2;
            Marked = false;
            CameFrom = null;
        }
    }
}
