using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using C5;

namespace KursachAttemp2.Models
{
    [Serializable]
    public class Graph
    {
        public enum Statuses
        {
            NO_WAY_EXISTS = -1,
            WAY_EXISTS = 1
        }
        public delegate void ProccesPath(string wayTitle, string stopTitle, string starttime, double position);
        private IndexKeyMatrix<string, double> _timeMatrix;
        private IndexKeyMatrix<string, double> _distanceMatrix;
        private IndexKeyMatrix<string, double> _workMatrix;
        private List<Vertex> _vertexes;
        private int[,] _wayMatrix;
        private Stack<string> path;
        private Stack<double> pathDisplay;
        public int Changes { get; private set; }
        public int NumberOfUniquePoints { get; private set; }
        private bool isByTime = false;
        private List<Way> _ways;
        public List<Way> Ways
        {
            get
            {
                return _ways;
            }
            private set
            {
                _ways = value;
                waysLength = _ways.Count;
            }
        }
        private int waysLength;
        public Graph(int numberOfUniquePoints, List<Way> ways)
        {
            NumberOfUniquePoints = numberOfUniquePoints;
            path = new Stack<string>();
            pathDisplay = new Stack<double>();
            _vertexes = new List<Vertex>();
            Ways = ways;
            waysLength = Ways.Count;
            BuildMatrix();
            //BuildList();
        }
        private void BuildList()
        {
            for (int i = 0; i < NumberOfUniquePoints; i++)
                _vertexes.Add(new Vertex(i, _timeMatrix[i]));
            for (int i = 0; i < NumberOfUniquePoints; i++)
            {
                var tmp = _vertexes[i];
                for (int j = 0; j < NumberOfUniquePoints; j++)
                {
                    if (_timeMatrix[i, j] != 0 && i != j)
                    {
                        tmp.Adjacent.Add(_vertexes[j]);
                        tmp.Times.Add(_timeMatrix[i, j]);
                        tmp.Distances.Add(_timeMatrix[i, j]);
                    }
                }
            }
            foreach(var v in _vertexes)
            {
                Console.Write($"{v.Name}");
                Console.WriteLine();
                foreach(var u in v.Adjacent)
                {
                    Console.Write($"{u.Name}, ");
                }
                Console.WriteLine();
            }
        }
        private void Dijkstra(string src, bool isByDistance = false)
        {
            PriorityQueue<Vertex> heap = new PriorityQueue<Vertex>();
            if (!isByDistance)
            {
                heap = new PriorityQueue<Vertex>(Comparer<Vertex>.Create((v1, v2) =>
                {
                    if (v1.Time < v2.Time) return 1;
                    if (v1.Time == v2.Time) return 0;
                    if (v1.Time > v2.Time) return -1;
                    return 0;
                }));
            } 
            else if(isByDistance)
            {
                heap = new PriorityQueue<Vertex>(Comparer<Vertex>.Create((v1, v2) =>
                {
                    if (v1.Distance < v2.Distance) return 1;
                    if (v1.Distance == v2.Distance) return 0;
                    if (v1.Distance > v2.Distance) return -1;
                    return 0;
                }));
            }
            foreach(var v in _vertexes)
            {
                heap.push(v);
            }
            _vertexes[_timeMatrix[src]].Time = 0;
            _vertexes[_timeMatrix[src]].Distance = 0;
            while(heap.Count != 0)
            {
                Vertex u = heap.pop();
                u.Marked = true;
                for (int i = 0; i < u.Adjacent.Count;i++)
                {
                    Vertex v = u.Adjacent[i];
                    if(v.Marked == false)
                    {
                        if (!isByDistance)
                        {
                            if (v.Time > u.Time + u.Times[i])
                            {
                                v.Time = u.Time + u.Times[i];
                                v.CameFrom = u;
                            }
                        }
                        else
                        {
                            if (v.Distance > u.Distance + u.Distances[i])
                            {
                                v.Distance = u.Distance + u.Distances[i];
                                v.CameFrom = u;
                            }
                        } 
                    }
                }
                heap.heapify();
            }
            foreach(var v in _vertexes)
            {
                Console.WriteLine();
                Console.Write($"{v.Name}:{v.Time}, ");
            }
        }
        private void CountNumberOfUniquePoints()
        {
            List<string> count = new List<string>();
            for (int i = 0; i < Ways.Count; i++)
            {
                for (int j = 0; j < Ways[i].Count; j++)
                {
                    bool contains = false;
                    foreach (string s in count)
                    {
                        if (s == Ways[i][j].Title)
                            contains = true;
                    }
                    if (!contains)
                    {
                        count.Add(Ways[i][j].Title);
                    }
                }
            }
            NumberOfUniquePoints = count.Count;
        }
        public void BuildMatrix()
        {
            CountNumberOfUniquePoints();
            _timeMatrix = new IndexKeyMatrix<string, double>(NumberOfUniquePoints);
            _distanceMatrix = new IndexKeyMatrix<string, double>(NumberOfUniquePoints);
            _wayMatrix = new int[NumberOfUniquePoints, NumberOfUniquePoints];
            for (int i = 0; i < NumberOfUniquePoints; i++)
            {
                for (int j = 0; j < NumberOfUniquePoints; j++)
                {
                    _timeMatrix[i, j] = 0;
                    _distanceMatrix[i, j] = 0;
                    _wayMatrix[i, j] = 0;
                }
            }
            foreach (Way way in Ways)
            {
                for (int k = 0; k < way.Count - 1; k++)
                {
                    double dTime = Math.Abs(way[k+1] - way[k]);
                    double dDistance = Math.Abs(way[k + 1].Position - way[k].Position);
                    _timeMatrix.Add(dTime, way[k].Title, way[k + 1].Title);
                    //_timeMatrix.Add(dTime, way[k + 1].Title, way[k].Title);
                    _distanceMatrix.Add(dDistance, way[k].Title, way[k + 1].Title);
                    //_distanceMatrix.Add(dDistance, way[k + 1].Title, way[k].Title);
                }
            }
            _vertexes = new List<Vertex>();
            BuildList();
        }

        /*private void FindTheShortestWays()
        {
            for (int i = 0; i < NumberOfUniquePoints; i++)
            {
                for (int j = 0; j < NumberOfUniquePoints;j++)
                {
                    if(i!=j && _workMatrix[i,j] == 0) {
                        _workMatrix[i, j] = Int32.MaxValue;
                    }
                }
            }
            for (int k = 0; k < NumberOfUniquePoints; k++)
            {
                for (int i = 0; i < NumberOfUniquePoints; i++)
                {
                    for (int j = 0; j < NumberOfUniquePoints; j++)
                    {
                        if (_workMatrix[i, j] > _workMatrix[i, k] + _workMatrix[k, j])
                        {
                            _workMatrix[i, j] = _workMatrix[i, k] + _workMatrix[k, j];
                            _wayMatrix[i, j] = k;
                        }
                    }
                }
            }
        }
        private void FindShortestPathBetween(int start, int find)
        {
            if (_wayMatrix[start, find] == 0)
            {
                return;
            }
            else
            {
                path.Push(_workMatrix[_wayMatrix[start, find]]);
                FindShortestPathBetween(_wayMatrix[start, find], start);
                FindShortestPathBetween(_wayMatrix[start, find], find);
                return;
            }
        }*/
        public void WayBetween(string start_, string stop_, bool isByTime = true)
        {
            int start = _timeMatrix[start_];
            int stop = _timeMatrix[stop_];
            this.isByTime = isByTime;
            pathDisplay = new Stack<double>();
            Dijkstra(start_, !isByTime);
            var curr = _vertexes[_timeMatrix[stop_]];
            while(true)
            {
                if(curr.CameFrom == null)
                {
                    path.Push(curr.Name);
                    break;
                }
                path.Push(curr.Name);
                curr = curr.CameFrom;
            }
            foreach(var v in _vertexes)
            {
                v.Distance = Double.MaxValue/2;
                v.Time = Double.MaxValue/2;
                v.CameFrom = null;
                v.Marked = false;
            }
        }
        public static T DeepClone<T>(T a)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, a);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }
        public static Stack<double> ReverseStack(Stack<double> a)
        {
            Stack<double> temp = new Stack<double>();

            //While the passed stack isn't empty, pop elements from the passed stack onto the temp stack
            while (a.Count != 0)
                temp.Push(a.Pop());

            return temp;
        }
        public void CountChanges(ProccesPath p)
        {
             var pr = DeepClone<Stack<string>>(path);
            var ctrl = new Stack<double>();
            while(pr.Count >= 1)
            {
                string t = pr.Pop();
                double min = 1214546400000000000;
                for (int i = 0; i < Ways.Count; i++)
                {
                    for (int j = 0; j < Ways[i].Count; j++)
                    {
                        if(Ways[i][j].Title == t)
                        {
                            if(isByTime && Convert.ToDouble(Ways[i][j].StartTime.Ticks) < min)
                            {
                                min = Convert.ToDouble(Ways[i][j].StartTime.Ticks);
                            }
                            else if(!isByTime && Ways[i][j].Position < min)
                            {
                                min = Ways[i][j].Position;
                            }
                        }
                   }
                }
                ctrl.Push(min);
            }
            ctrl = ReverseStack(ctrl);
            string saver = "";
            string test = "";
            string test2 = "";
            double dataSaver = -1;
            double data = -1;
            double data2 = -1;
            int prevI = 0;
            Changes = 0;
            bool contains = false;
            int length = path.Count;
            try
                {
                bool first = true;
                test = path.Pop();
                test2 = path.Pop();
                data = ctrl.Pop();
                data2 = ctrl.Pop();

                for (int i = 0; ;i++)
                {
                    if (i == Ways.Count)
                    {
                        i = 0;
                    }
                    for (int j = 0; j < Ways[i].Count - 1;j++)
                    {
                        if(Ways[i][j].Title == test && j == 0 && first /*&& 
                           (((isByTime && data == Convert.ToDouble(Ways[i][j].StartTime.Ticks)) || (!isByTime && data == Ways[i][j].Position)) && (((isByTime && data2 == Convert.ToDouble(Ways[i][j+1].StartTime.Ticks)) || (!isByTime && data2 == Ways[i][j+1].Position))))*/)
                        {
                            prevI = i;
                            p(Ways[i].Title, test, Ways[i][j].StartTimeString, Ways[i][j].Position);
                            saver = test;
                            test = test2;
                            test2 = path.Pop();
                            dataSaver = data;
                            data = data2;
                            data2 = ctrl.Pop();
                            first = false;
                            j = 0;
                        } else if(j != 0 && Ways[i][j].Title == test && (Ways[i][j+1].Title == test2 || Ways[i][j-1].Title == test2)/* &&
                                  (((isByTime && data == Convert.ToDouble(Ways[i][j].StartTime.Ticks)) || (!isByTime && data == Ways[i][j].Position)) && (((isByTime && data2 == Convert.ToDouble(Ways[i][j + 1].StartTime.Ticks)) || (!isByTime && data2 == Ways[i][j + 1].Position)) || ((isByTime && data2 == Convert.ToDouble(Ways[i][j - 1].StartTime.Ticks)) || (!isByTime && data2 == Ways[i][j - 1].Position))))*/)
                        {
                            prevI = i;
                            p(Ways[i].Title, test, Ways[i][j].StartTimeString, Ways[i][j].Position);
                            saver = test;
                            test = test2;
                            test2 = path.Pop();
                            dataSaver = data;
                            data = data2;
                            data2 = ctrl.Pop();
                            first = false;
                            j = 0;
                        }
                        else if(Ways[i][j].Title == test && j == 0 && (Ways[i][j + 1].Title == test2) && !first /*&& (((isByTime && data == Convert.ToDouble(Ways[i][j].StartTime.Ticks)) || (!isByTime && data == Ways[i][j].Position)) && (((isByTime && data2 == Convert.ToDouble(Ways[i][j + 1].StartTime.Ticks)) || (!isByTime && data2 == Ways[i][j + 1].Position))))*/)
                        {
                            p(Ways[i].Title, test, Ways[i][j].StartTimeString, Ways[i][j].Position);
                            if(i != prevI)
                            {
                                Changes++;
                                prevI = i;
                            }
                            saver = test;
                            test = test2;
                            test2 = path.Pop();
                            dataSaver = data;
                            data = data2;
                            data2 = ctrl.Pop();
                            j = 0;
                        }
                        else if(j != 0 && Ways[i][j].Title == test && (Ways[i][j + 1].Title == test2 || Ways[i][j - 1].Title == test2) /*&&
                                (((isByTime && data == Convert.ToDouble(Ways[i][j].StartTime.Ticks)) || (!isByTime && data == Ways[i][j].Position)) && (((isByTime && data2 == Convert.ToDouble(Ways[i][j + 1].StartTime.Ticks)) || (!isByTime && data2 == Ways[i][j + 1].Position)) || ((isByTime && data2 == Convert.ToDouble(Ways[i][j - 1].StartTime.Ticks)) || (!isByTime && data2 == Ways[i][j - 1].Position))))*/)
                        {
                            p(Ways[i].Title, test, Ways[i][j].StartTimeString, Ways[i][j].Position);
                            if(i != prevI)
                            {
                                Changes++;
                                prevI = i;
                            }
                            saver = test;
                            test = test2;
                            test2 = path.Pop();
                            dataSaver = data;
                            data = data2;
                            data2 = ctrl.Pop();
                        }
                        else if(Ways[i][j+1].Title == test && (Ways[i][j-1].Title == test2) &&
                                j+1 == Ways[i].Count-1 && first /*&& ((isByTime && data2 == Convert.ToDouble(Ways[i][j + 1].StartTime.Ticks)) || (!isByTime && data2 == Ways[i][j + 1].Position))*/)
                        {
                            prevI = i;
                            p(Ways[i].Title, test, Ways[i][j].StartTimeString, Ways[i][j].Position);
                            saver = test;
                            test = test2;
                            test2 = path.Pop();
                            dataSaver = data;
                            data = data2;
                            data2 = ctrl.Pop();
                            first = false;
                            j = 0;
                        }
                        else if(Ways[i][j+1].Title == test && (Ways[i][j - 1].Title == test2) &&
                                j+1 == Ways[i].Count-1 && !first /*&& ((isByTime && data2 == Convert.ToDouble(Ways[i][j + 1].StartTime.Ticks)) || (!isByTime && data2 == Ways[i][j + 1].Position))*/)
                        {
                            p(Ways[i].Title, test, Ways[i][j].StartTimeString, Ways[i][j].Position);
                            if (i != prevI)
                            {
                                Changes++;
                                prevI = i;
                            }
                            saver = test;
                            test = test2;
                            test2 = path.Pop();
                            dataSaver = data;
                            data = data2;
                            data2 = ctrl.Pop();
                        }
                    }

                
                }
         


            } catch(InvalidOperationException)
            {
                dataSaver = data;
                data = data2;
                int i;
                if (length == 2)
                {
                    prevI = 0;
                    for (i = 0; i < Ways.Count; i++)
                    {
                        for (int j = 0; j < Ways[i].Count; j++)
                        {
                            if (Ways[i][j].Title == saver /*&& ((isByTime && dataSaver == Convert.ToDouble(Ways[i][j].StartTime.Ticks)) || (!isByTime && dataSaver == Ways[i][j].Position))*/)
                            {
                                prevI = i;
                            }
                        }
                    }
                    for (i = 0; i < Ways[prevI].Count; i++)
                    {
                        if (Ways[prevI][i].Title == test/* && ((isByTime && data == Convert.ToDouble(Ways[prevI][i].StartTime.Ticks)) || (!isByTime && data == Ways[prevI][i].Position))*/)
                            contains = true;
                    }
                }
                else
                    contains = true;
                if(!contains)
                    throw new NoWayException();
                string starttime = "";
                double position = 0;
                for (i = 0; i < Ways[prevI].Count;i++)
                {
                    if(Ways[prevI][i].Title == test /*&& ((isByTime && data == Convert.ToDouble(Ways[prevI][i].StartTime.Ticks)) || (!isByTime && data == Ways[prevI][i].Position))*/)
                    {
                        starttime = Ways[prevI][i].StartTimeString;
                        position = Ways[prevI][i].Position;
                        break;
                    }
                }
                try
                {
                    p(Ways[prevI].Title, test, starttime, Ways[prevI][i].Position);
                } catch(ArgumentOutOfRangeException)
                {
                    throw new NoWayException();
                }
            } catch(ArgumentOutOfRangeException)
            {
                throw new NoWayException();
            }
            finally
            {
                if(contains)
                    p("Changes: " + Changes, "","", 0);
            }
        }
        public static void Serialize(Graph g, string path)
        {
                DirectoryInfo di = new DirectoryInfo(path);

                try
                {
                    foreach (FileInfo file in di.GetFiles())
                    {
                        if (Regex.IsMatch(file.Name, @"Graph.data") || Regex.IsMatch(file.Name, @"(Way)[0-9]+(\.data)"))
                        {
                            file.Delete();
                        }
                    }
                }
                catch (FileNotFoundException)
                { }
            if (g.Ways.Count == 0)
                return;
            using (var fs = new FileStream(path+"Graph"+".data", FileMode.Create))
            {
                try
                {
                    var formater = new BinaryFormatter();
                    for (int i = 0; i < g.Ways.Count;i++)
                    {
                        using (var fs2=new FileStream(path+"Way"+i+".data", FileMode.Create))
                        {
                            formater.Serialize(fs2, g.Ways[i]);
                        }
                    }
                    formater.Serialize(fs, g);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public static Graph Deserialize(string path)
        {
            Graph g = null;
            using (var fs = new FileStream(path+ "Graph" +".data", FileMode.Open))
            {
                try
                {
                    var formatter = new BinaryFormatter();
                    g = (Graph)formatter.Deserialize(fs);
                    int length = g.waysLength;
                    g.Ways = new List<Way>();
                    for (int i = 0; i < length;i++)
                    {
                        try
                        {
                            using (var fs2 = new FileStream(path + "Way" + i + ".data", FileMode.Open))
                            {
                                g.Ways.Add((Way)formatter.Deserialize(fs2));
                                g.Ways = g.Ways;
                            }
                        }
                        catch(FileNotFoundException)
                        {
                            break;
                        }
                    }

                }
                catch (SerializationException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            return g;
        }
    }
}
