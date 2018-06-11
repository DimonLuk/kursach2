using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Gtk;
using KursachAttemp2.Models;

namespace KursachAttemp2.View
{
    public partial class AddToExistingWayWindow : Gtk.Window
    {
        private IGraph _parent;
        private List<VBox> _container;
        private Way way;
        private string way_title;
        private Graph g;
        public AddToExistingWayWindow(IGraph w) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            _parent = w;
        }

        protected void OnStartAddingButtonClicked(object sender, EventArgs e)
        {
            try
            {
                int numberOfStops = Convert.ToInt32(num_of_stops.Text);
                string wayName = way_title_entry.Text;
                way_title = wayName;
                if (wayName == "" || numberOfStops <= 0 || num_of_stops.Text == "")
                {
                    num_of_stops.Text = "";
                    way_title_entry.Text = "";
                    numberOfStops = 0;
                    Clear();
                }
                Clear();
                _container = new List<VBox>();
                for (int i = 0; i < numberOfStops;i++)
                {
                    ShowStopsGetters();
                }
                Child.ShowAll();
            }
            catch(FormatException)
            {
                num_of_stops.Text = "";
                way_title_entry.Text = "";
                Clear(); 
            }
        }
        public void Clear()
        {
            if (_container != null)
            {
                foreach (VBox v in _container)
                {
                    stop_getting_info_container.Remove(v);
                }
            }
            _container = new List<VBox>();
        }
        public void ShowStopsGetters()
        {
            var stop_title_label = new Label();
            stop_title_label.Name = "stop_title_label";
            stop_title_label.LabelProp = "Write stop's title";

            var stop_title_entry = new CustomGtkEntry(0,0, "title");
            stop_title_label.Name = "stop_title_entry";

            var stop_time_label = new Label();
            stop_time_label.Name = "stop_title_label";
            stop_time_label.LabelProp = "Write stop's time in format: DD:HH:MM";

            var stop_time_entry = new CustomGtkEntry(0,0, "time");
            stop_title_label.Name = "stop_time_entry";

            var stop_position_label = new Label();
            stop_position_label.LabelProp = "Write stop's position";

            var stop_position_entry = new CustomGtkEntry(0,0,"position");
            stop_position_label.Name = "stop_time_entry";

            var hbox = new HBox();
            hbox.Add(stop_title_label);
            hbox.Add(stop_title_entry);
            hbox.Add(stop_time_label);
            hbox.Add(stop_time_entry);
            hbox.Add(stop_position_label);
            hbox.Add(stop_position_entry);

            var vbox = new VBox();
            vbox.Add(hbox);
            _container.Add(vbox);

            stop_getting_info_container.Add(vbox);
        }

        protected void OnAddAllButtonClicked(object sender, EventArgs e)
        {
            bool isPostProcess = true;
            if(_container != null)
            {
                List<Stop> stops = new List<Stop>();
                foreach(VBox v in _container)
                {
                    foreach(HBox h in v.AllChildren)
                    {
                        string title = "";
                        string time = "";
                        double position = -1;
                        foreach(Widget w in h.AllChildren)
                        {
                            if(w.ToString() == "KursachAttemp2.Models.CustomGtkEntry")
                            {
                                
                                var ent = (CustomGtkEntry)w;
                                if (ent.Type == "time" && ent.Text != "")
                                {
                                    time = ent.Text;
                                    try
                                    {
                                        var tmp = time.Split(':');
                                        var tmpTime = new DateTime(2018, 12, Convert.ToInt32(tmp[0]), Convert.ToInt32(tmp[1]), Convert.ToInt32(tmp[2]), 0);
                                        if(stops.Count > 0 && tmpTime <= stops[stops.Count-1].StartTime)
                                        {
                                            ent.Text = "";
                                            return;
                                        }
                                    }
                                    catch(ArgumentOutOfRangeException)
                                    {
                                        ent.Text = "";
                                        return;
                                    }
                                    catch(IndexOutOfRangeException)
                                    {
                                        //ent.Text = "";
                                        //return;
                                    }
                                }
                                else if (ent.Type == "title" && ent.Text != "")
                                {
                                    title = ent.Text;
                                }
                                else if(ent.Type == "position" && ent.Text != "")
                                {
                                    try
                                    {
                                        position = Convert.ToDouble(ent.Text);
                                        if(stops.Count > 0 && position <= stops[stops.Count - 1].Position)
                                        {
                                            ent.Text = "";
                                        }
                                    }
                                    catch(FormatException)
                                    {
                                        ent.Text = "";
                                        return;
                                    }
                                }
                            }
                            if (title != "" && time != "" && position >= 0)
                                stops.Add(new Stop(title, time, position));
                        }
                    }
                }

                try
                {
                    if (stops.Count == 0)
                    {
                        isPostProcess = false;
                        return;
                    }
                    stops[0].Position = 0;
                    way = new Way(way_title, stops);
                    way.Type = way_type_entry.Text;
                    g = Graph.Deserialize(_parent.Path_);
                    /*List<string> count = new List<string>();
                    for (int i = 0; i < g.Ways.Count; i++)
                    {
                        for (int j = 0; j < g.Ways[i].Count;j++)
                        {
                            bool contains = false;
                            foreach(string s in count)
                            {
                                if (s == g.Ways[i][j].Title)
                                    contains = true;
                            }
                            if(!contains)
                            {
                                count.Add(g.Ways[i][j].Title);
                            }
                        }
                    }
                    for (int j = 0; j < way.Count;j++)
                    {
                        bool contains = false;
                        foreach (string s in count)
                        {
                            if (s == way[j].Title)
                                contains = true;
                        }
                        if (!contains)
                        {
                            count.Add(way[j].Title);
                        }
                    }*/
                    g.Ways.Add(way);
                    g = new Graph(10, g.Ways);
                    _parent.Graph = g;
                    KursachAttemp2.Models.Graph.Serialize(g, _parent.Path_);

                }    
                catch(FileNotFoundException)
                {
                    List<string> count = new List<string>();
                    for (int j = 0; j < way.Count; j++)
                    {
                        bool contains = false;
                        foreach (string s in count)
                        {
                            if (s == way[j].Title)
                                contains = true;
                        }
                        if (!contains)
                        {
                            count.Add(way[j].Title);
                        }
                    }
                    var list_way = new List<Way>();
                    list_way.Add(way);
                    g = new Graph(count.Count, list_way);
                    _parent.Graph = g;
                    KursachAttemp2.Models.Graph.Serialize(g, _parent.Path_);
                }
                finally
                {
                    if (isPostProcess)
                    {
                        (new AddToExistingWayWindow(_parent)).Show();
                        _parent.BuildGraph();
                        Destroy();
                    }
                }
            }
        }
    }
}
