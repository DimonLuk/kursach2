using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Gtk;
using KursachAttemp2.Models;
using KursachAttemp2.View;

public partial class MainWindow : Gtk.Window, IGraph
{
    public string Path_ { get; set; }
    private List<VBox> _ways_stops_container;
    private List<CustomGtkEntry> _ways_container;
    private List<CustomGtkEntry> _stop_time_container;
    private List<CustomGtkEntry> _stop_title_container;
    private List<CustomGtkEntry> _stop_position_container;
    private CustomGtkEntry previousFoundObject;
    private Graph graph;
    public Graph Graph
    {
        get{ return graph; }
        set{ graph = value; }
    }
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        search_category.AppendText("Way");
        search_category.AppendText("Stop title");
        search_category.AppendText("Stop time");
        search_category.AppendText("Position");
        search_category.Active = 0;
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        if(Path_ != null)
        {
            KursachAttemp2.Models.Graph.Serialize(graph, Path_);
        }
        Application.Quit();
        a.RetVal = true;
    }
    protected void ShowWays(Graph g)
    {
        int counter = 0;
        foreach (Way w in g.Ways)
        {
            var builder = new StringBuilder();
            builder.Append("way_");
            builder.Append(counter);


            var tmp_way_title = new Label();
            tmp_way_title.Name = "way_title";
            tmp_way_title.LabelProp = "Way title:";

            var tmp_way_title_value = new CustomGtkEntry(counter, 0, "wayTitle");
            tmp_way_title_value.Name = "way_title_value";
            tmp_way_title_value.Text = w.Title;
            tmp_way_title_value.Changed += DataBinding;
            _ways_container.Add(tmp_way_title_value);

            var tmp_way_type_value = new CustomGtkEntry(counter, 0, "wayType");
            tmp_way_type_value.Name = "way_type";
            tmp_way_type_value.Text = w.Type;
            tmp_way_type_value.Changed += DataBinding;

            /*var tmp_way_start_time = new global::Gtk.Label();
            tmp_way_start_time.Name = "way_start_time";
            tmp_way_start_time.LabelProp = global::Mono.Unix.Catalog.GetString("Sarts at");

            var tmp_way_start_time_value = new Label;
            tmp_way_start_time_value.Name = "way_start_time_value";
            tmp_way_start_time_value.LabelProp = global::Mono.Unix.Catalog.GetString(w[0].StartTimeString);*/

            builder = new StringBuilder();
            builder.Append("hbox_");
            builder.Append(counter);

            var delete_way_button = new CustomGtkButton(counter, 0, "way");
            delete_way_button.Label = "Delete";
            delete_way_button.Clicked += WayOrStopDeleting;

            var tmp_hbox1_way_info_container = new HBox();
            tmp_hbox1_way_info_container.Name = builder.ToString();
            tmp_hbox1_way_info_container.Spacing = 6;
            tmp_hbox1_way_info_container.Add(tmp_way_title);
            tmp_hbox1_way_info_container.Add(tmp_way_title_value);
            tmp_hbox1_way_info_container.Add(delete_way_button);
            tmp_hbox1_way_info_container.Add(tmp_way_type_value);
            //tmp_hbox1_way_info_container.Add(tmp_way_start_time);
            //tmp_hbox1_way_info_container.Add(tmp_way_start_time_value);


            var tmp_way_container = new VBox();//Local container
            tmp_way_container.Name = "vbox4";
            tmp_way_container.Spacing = 6;

            tmp_way_container.Add(tmp_hbox1_way_info_container);

            var tmp_main_container = new VBox();//Local container
            tmp_main_container.Name = "main_way_stop_info_container";
            tmp_main_container.Spacing = 6;

            tmp_main_container.Add(tmp_way_container);
            ShowStops(w, tmp_main_container, counter);
            _ways_stops_container.Add(tmp_main_container);

            way_container.Add(tmp_main_container);
            counter++;
        }
    }
    protected void ShowStops(Way w, VBox vBox, int wayIndex)
    {
        int counter = 0;
        var t1 = new Label();
        t1.Name = "stop_title_value";
        t1.LabelProp = "Stop name";

        var t2 = new Label();
        t2.Name = "stop_time_value";
        t2.LabelProp = "Arrive time DD:HH:MM";

        var t2_1 = new Label();
        t2.Name = "stop_time_value";
        t2.LabelProp = "Position";

        var t3 = new HBox();
        t3.Name = "table_head";
        t3.Spacing = 6;
        t3.Add(t1);
        t3.Add(t2);
        t3.Add(t2_1);
        vBox.Add(t3);
        foreach (Stop s in w)
        {
            var builder = new StringBuilder();
            builder.Append("stop_");
            builder.Append(counter);


            var tmp_way_title = new CustomGtkEntry(wayIndex, counter, "stopTitle");
            tmp_way_title.Name = "stop_title_value";
            tmp_way_title.Text = s.Title;
            tmp_way_title.Changed += DataBinding;
            _stop_title_container.Add(tmp_way_title);

            var tmp_stop_time = new CustomGtkEntry(wayIndex, counter, "stopTime");
            tmp_stop_time.Name = "stop_time_value";
            tmp_stop_time.Text = s.StartTimeString;
            tmp_stop_time.Changed += DataBinding;
            _stop_time_container.Add(tmp_stop_time);

            var tmp_stop_position = new CustomGtkEntry(wayIndex, counter, "stopPosition");
            tmp_stop_position.Name = "stop_time_value";
            tmp_stop_position.Text = s.Position.ToString();
            tmp_stop_position.Changed += DataBinding;
            _stop_position_container.Add(tmp_stop_position);

            builder = new StringBuilder();
            builder.Append("hbox_stop_");
            builder.Append(counter);

            var delete_stop_button = new CustomGtkButton(wayIndex, counter, "stop");
            delete_stop_button.Label = "Delete stop";
            delete_stop_button.Clicked += WayOrStopDeleting;

            var tmp_hbox1_stop_info_container = new HBox();
            tmp_hbox1_stop_info_container.Name = builder.ToString();
            tmp_hbox1_stop_info_container.Spacing = 6;
            tmp_hbox1_stop_info_container.Add(tmp_way_title);
            tmp_hbox1_stop_info_container.Add(tmp_stop_time);
            tmp_hbox1_stop_info_container.Add(tmp_stop_position);
            tmp_hbox1_stop_info_container.Add(delete_stop_button);

            vBox.Add(tmp_hbox1_stop_info_container);

            counter++;
        }
        var add_stop_title = new CustomGtkEntry(wayIndex, counter, "stopTitle");

        var add_stop_time = new CustomGtkEntry(wayIndex, counter, "stopTitle");

        var add_stop_position = new CustomGtkEntry(wayIndex, counter, "stopTitle");

        var add_stop_button = new CustomGtkButton(wayIndex, counter, "addStop", add_stop_title, add_stop_time, add_stop_position);
        add_stop_button.Label = "Add stop";
        add_stop_button.Clicked += AddStopHandler;
        var hBox = new HBox();
        hBox.Add(add_stop_title);
        hBox.Add(add_stop_time);
        hBox.Add(add_stop_position);
        hBox.Add(add_stop_button);
        vBox.Add(hBox);
    }
    protected void AddStopHandler(object sender, EventArgs e)
    {
        var b = (CustomGtkButton)sender;
        if(b.Type == "addStop")
        {
            var title = (CustomGtkEntry)b.TitleEntry;
            var time = (CustomGtkEntry)b.TimeEntry;
            var position = (CustomGtkEntry)b.PositionEntry;
            try
            {
                if (title.Text != "" && time.Text != "" && position.Text != "")
                {
                    var tmp = time.Text.Split(':');
                    var tmpTime = new DateTime(2018, 12, Convert.ToInt32(tmp[0]), Convert.ToInt32(tmp[1]), Convert.ToInt32(tmp[2]), 0);
                    double tmpDistance = 0;
                    try
                    {
                        tmpDistance = Convert.ToDouble(position.Text);
                    }
                    catch(FormatException)
                    {
                        position.Text = "";   
                    }
                    if(graph.Ways[b.WayIndex].Count > 0 && tmpDistance <= graph.Ways[b.WayIndex][graph.Ways[b.WayIndex].Count - 1].Position)
                    {
                        position.Text = "";
                    }
                    if (graph.Ways[b.WayIndex].Count > 0 && tmpTime <= graph.Ways[b.WayIndex][graph.Ways[b.WayIndex].Count - 1].StartTime)
                    {
                        time.Text = "";
                    }
                    if(title.Text != "" && time.Text != "" && position.Text != "")
                    {
                        graph.Ways[b.WayIndex].Add(new Stop(title.Text, time.Text, Convert.ToDouble(position.Text)));
                        KursachAttemp2.Models.Graph.Serialize(graph, Path_);
                        BuildGraph();
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                time.Text = "";
            }
            catch(FormatException)
            {
                time.Text = "";
            }
        }
    }
    protected void WayOrStopDeleting(object sender, EventArgs e)
    {
        var m = (CustomGtkButton)sender;
        if(m.Type == "way")
        {
            graph.Ways.RemoveAt(m.WayIndex);
            graph.BuildMatrix();
            if (_ways_stops_container != null)
            {
                foreach (VBox b in _ways_stops_container)
                    way_container.Remove(b);
            }
            _ways_stops_container = new List<VBox>();
            _ways_container = new List<CustomGtkEntry>();
            _stop_time_container = new List<CustomGtkEntry>();
            _stop_title_container = new List<CustomGtkEntry>();
            _stop_position_container = new List<CustomGtkEntry>();
            ShowWays(graph);
            Child.ShowAll();
        }
        else if(m.Type == "stop")
        {
            graph.Ways[m.WayIndex].RemoveAt(m.StopIndex);
            if(graph.Ways[m.WayIndex].Count == 0)
            {
                graph.Ways.RemoveAt(m.WayIndex);
            }
            graph.BuildMatrix();
            if (_ways_stops_container != null)
            {
                foreach (VBox b in _ways_stops_container)
                    way_container.Remove(b);
            }
            _ways_stops_container = new List<VBox>();
            _ways_container = new List<CustomGtkEntry>();
            _stop_time_container = new List<CustomGtkEntry>();
            _stop_title_container = new List<CustomGtkEntry>();
            _stop_position_container = new List<CustomGtkEntry>();
            ShowWays(graph);
            Child.ShowAll();
        }
    }
    protected void DataBinding(object sender, EventArgs e)
    {
        var m = (CustomGtkEntry)sender;
        if (m.Type == "wayTitle")
        {
            graph.Ways[m.WayIndex].Title = m.Text;
        }
        else if(m.Type == "wayType")
        {
            graph.Ways[m.WayIndex].Type = m.Text;
        }
        else if (m.Type == "stopTitle")
        {
            if (m.Text != "")
            {
                graph.Ways[m.WayIndex][m.StopIndex].Title = m.Text;
                graph.BuildMatrix();
            }

        }
        else if (m.Type == "stopTime")
        {
            try
            {
                var tmp = m.Text.Split(':');
                var tmpTime = new DateTime(2018, 12, Convert.ToInt32(tmp[0]), Convert.ToInt32(tmp[1]), Convert.ToInt32(tmp[2]), 0);
                //graph.Ways[m.WayIndex][m.StopIndex].StartTime =  tmpTime >= graph.Ways[m.WayIndex][m.StopIndex-1].StartTime?tmpTime:graph.Ways[m.WayIndex][m.StopIndex].StartTime;
                if(graph.Ways[m.WayIndex].Count > 0 && m.StopIndex >= 0 && tmpTime > graph.Ways[m.WayIndex][m.StopIndex - 1].StartTime)
                {
                    graph.Ways[m.WayIndex][m.StopIndex].StartTime = tmpTime;
                    graph.BuildMatrix();
                }

            }
            catch(IndexOutOfRangeException)
            {}
            catch(ArgumentOutOfRangeException)
            {}
            catch(FormatException)
            {}
        }
        else if(m.Type == "stopPosition")
        {
            try
            {
                var tmp = Convert.ToDouble(m.Text);
                if(graph.Ways[m.WayIndex].Count > 0 && m.StopIndex - 1 >= 0 && tmp > graph.Ways[m.WayIndex][m.StopIndex - 1].Position)
                {
                    graph.Ways[m.WayIndex][m.StopIndex].Position = Convert.ToDouble(m.Text);
                    graph.BuildMatrix();
                }
            }
            catch(FormatException)
            {
                m.Text = "";
            }
        }
    }

    protected void activated_handler(object sender, EventArgs e)
    {
        Synchronize();
        var w = new FileChoosing(this, BuildGraph_);
        w.Show();
    }
    protected void Synchronize()
    {
        if (graph != null && Path_ != null)
            KursachAttemp2.Models.Graph.Serialize(graph, Path_);
    }
    public void BuildGraph()
    {
        try
        {
             if (_ways_stops_container != null)
            {
                foreach (VBox b in _ways_stops_container)
                    way_container.Remove(b);
            }
            _ways_stops_container = new List<VBox>();
            _ways_container = new List<CustomGtkEntry>();
            _stop_time_container = new List<CustomGtkEntry>();
            _stop_title_container = new List<CustomGtkEntry>();
            _stop_position_container = new List<CustomGtkEntry>();
            graph = Graph.Deserialize(Path_);
            ShowWays(graph);
            this.Child.ShowAll();
        }
        catch (FileNotFoundException)
        {
            var w = new KursachAttemp2.View.FileNotFoundDialog(this);
            w.Show();
        }
    }
    public static void BuildGraph_(IGraph w)
    {
        w.BuildGraph();
    }

    protected void OnNewActivatedHandler(object sender, EventArgs e)
    {
        Synchronize();
        var w1 = new FileChoosing(this, DoNothing);
        w1.Show();  

    }
    public void DoNothing(IGraph w)
    {
        //Synchronize();
        var s = new AddToExistingWayWindow(this);
        s.Show();
    }

    protected void OnFindPathActionActivatedHandler(object sender, EventArgs e)
    {
        if(Path_ != null)
        {
            //Synchronize();
            var w = new FindPathWindow(this);
            w.Show();            
        } 
        else
        {
            var w = new FileNotFoundDialog(this, ()=>{
                var w1 = new FileChoosing(this, BuildGraph_);
                w1.Show();
            }, "Please select a folder where info is contained");
        }

    }

    protected void FindStopOrWayClickedHandler(object sender, EventArgs e)
    {
        if(Path_ != null)
        {
            switch(search_category.Active)
            {
                case 0:
                    {
                        foreach (var w in _ways_container)
                        {
                            if (w.Text == find_entry.Text && previousFoundObject == null)
                            {   
                                w.GrabFocus();
                                previousFoundObject = w;
                                break;
                            }
                            else if(w.Text == find_entry.Text && previousFoundObject != null)
                            {
                                if (previousFoundObject == w)
                                    continue;
                                w.GrabFocus();
                                previousFoundObject = w;
                                break;
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        foreach (var w in _stop_title_container)
                        {
                            if (w.Text == find_entry.Text && previousFoundObject == null)
                            {
                                w.GrabFocus();
                                previousFoundObject = w;
                                break;
                            }
                            else if (w.Text == find_entry.Text && previousFoundObject != null)
                            {
                                if (previousFoundObject == w)
                                    continue;
                                w.GrabFocus();
                                previousFoundObject = w;
                                break;
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        foreach (var w in _stop_time_container)
                        {
                            if (w.Text == find_entry.Text && previousFoundObject == null)
                            {
                                w.GrabFocus();
                                previousFoundObject = w;
                                break;
                            }
                            else if (w.Text == find_entry.Text && previousFoundObject != null)
                            {
                                if (previousFoundObject == w)
                                    continue;
                                w.GrabFocus();
                                previousFoundObject = w;
                                break;
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        foreach (var w in _stop_position_container)
                        {
                            if (w.Text == find_entry.Text && previousFoundObject == null)
                            {
                                w.GrabFocus();
                                previousFoundObject = w;
                                break;
                            }
                            else if (w.Text == find_entry.Text && previousFoundObject != null)
                            {
                                if (previousFoundObject == w)
                                    continue;
                                w.GrabFocus();
                                previousFoundObject = w;
                                break;
                            }
                        }
                        break;
                    }
            }
        }
    }
}
