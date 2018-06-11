using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

namespace KursachAttemp2.Models
{
    [Serializable]
    public class Way : IEnumerable<Stop>
    {
        public string Title { get; set; }
        private List<Stop> Stops { get; set; }
        public DateTime StartTime { get { return Stops[0].StartTime; } }
        public int Count { get { return Stops.Count; } }
        public string Type { get; set; }
        public Way()
        {

        }
        public Way(string title, List<Stop> stops = null)
        {
            Title = title;
            if (stops == null)
                Stops = new List<Stop>();
            else
                Stops = stops;
        }

        public IEnumerator<Stop> GetEnumerator()
        {
            for (int i = 0; i < Stops.Count; i++)
            {
                yield return Stops[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return GetEnumerator();
        }
        public Stop this[int i]
        {
            get
            {
                return Stops[i];
            }
            set
            {
                Stops[i] = value;
            }
        }
        public void Add(Stop stop)
        {
            if (Stops.Count == 0)
                stop.Position = 0;
            Stops.Add(stop);
        }
        public static void Serialize(Way way, string path)
        {
            using(var fs = new FileStream(path, FileMode.Create))
            {
                try
                {
                    var formater = new BinaryFormatter();
                    formater.Serialize(fs, way);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public static Way Deserialize(string path)
        {
            Way way = null;
            using(var fs = new FileStream(path, FileMode.Open))
            {
                try
                {
                    var formatter = new BinaryFormatter();
                    way = (Way)formatter.Deserialize(fs);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine(e);
                }
            }
            return way;
        }
        public void RemoveAt(int index)
        {
            Stops.RemoveAt(index);
        }
    }
}
