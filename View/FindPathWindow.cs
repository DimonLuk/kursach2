using System;
using KursachAttemp2.Models;
using Gtk;
using System.Collections.Generic;

namespace KursachAttemp2.View
{
    public partial class FindPathWindow : Gtk.Window
    {
        private IGraph _parent;
        private List<VBox> _control_container;
        public FindPathWindow(IGraph parent) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            _parent = parent;
            type_of_search.AppendText("Time");
            type_of_search.AppendText("Distance");
            type_of_search.Active = 0;
        }

        protected void OnButtonFindClickedHanlder(object sender, EventArgs e)
        {
            string startTitle = start_postion_title.Text;
            string stopTitle = stop_position_title.Text;
            if (startTitle == "" || stopTitle == "")
            {
                var w = new FileNotFoundDialog(_parent, () => { }, "Please fill all fields");
            }
            _parent.Graph.BuildMatrix();
            switch(type_of_search.Active)
            {
                case 0:
                    {
                        _parent.Graph.WayBetween(startTitle, stopTitle);
                        break;
                    }
                case 1:
                    {
                        _parent.Graph.WayBetween(startTitle, stopTitle, false);
                        break;
                    }
            }
            if (_control_container != null)
            {
                foreach (VBox v in _control_container)
                {
                    path_main_container.Remove(v);
                }
            }
            _control_container = new List<VBox>();
            try
            {
                _parent.Graph.CountChanges(ShowPath);
                int numOfChanges = -1;
                if(num_of_changes_entry.Text != "")
                {
                    numOfChanges = Convert.ToInt32(num_of_changes_entry.Text);
                    if (numOfChanges <= _parent.Graph.Changes)
                        (new FileNotFoundDialog(_parent, ()=>{}, "Too much changes on the way", "Bad way")).Show();
                }
            }
            catch(NoWayException)
            {
                (new FileNotFoundDialog(_parent, () => { }, "No way", "No way")).Show();
            }
            catch(FormatException)
            {}
            Child.ShowAll();

        }
        private void ShowPath(string wayTitle, string wayType,string stopTitle, string arriveTime, double position)
        {
            var title_label = new Label();
            title_label.Name = "title_label";
            title_label.LabelProp = wayTitle;

            var way_type = new Label();
            way_type.LabelProp = wayType;

            var title_stop_label = new Label();
            title_stop_label.Name = "title_stop_label";
            title_stop_label.LabelProp = stopTitle;

            var time_stop_label = new Label();
            time_stop_label.Name = "time_stop_label";
            time_stop_label.LabelProp = arriveTime;

            var time_position_label = new Label();
            time_position_label.Name = "time_stop_label";
            time_position_label.LabelProp = position.ToString();

            var hbox = new HBox();
            hbox.Add(title_label);
            hbox.Add(way_type);
            hbox.Add(title_stop_label);
            hbox.Add(time_stop_label);
            hbox.Add(time_position_label);

            var vbox = new VBox();
            vbox.Add(hbox);
            _control_container.Add(vbox);

            path_main_container.Add(vbox);

        }
    }
}
