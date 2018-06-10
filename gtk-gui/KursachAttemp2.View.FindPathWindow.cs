
// This file has been generated by the GUI designer. Do not modify.
namespace KursachAttemp2.View
{
	public partial class FindPathWindow
	{
		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Label label2;

		private global::Gtk.Entry start_postion_title;

		private global::Gtk.Label label3;

		private global::Gtk.Entry stop_position_title;

		private global::Gtk.Label label1;

		private global::Gtk.Entry num_of_changes_entry;

		private global::Gtk.ComboBox type_of_search;

		private global::Gtk.Button button1;

		private global::Gtk.VBox vbox3;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Label label5;

		private global::Gtk.Label label6;

		private global::Gtk.Label label7;

		private global::Gtk.VBox path_main_container;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget KursachAttemp2.View.FindPathWindow
			this.Name = "KursachAttemp2.View.FindPathWindow";
			this.Title = global::Mono.Unix.Catalog.GetString("FindPathWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child KursachAttemp2.View.FindPathWindow.Gtk.Container+ContainerChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			global::Gtk.Viewport w1 = new global::Gtk.Viewport();
			w1.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child GtkViewport.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Insert start position name/title");
			this.hbox1.Add(this.label2);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.label2]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.start_postion_title = new global::Gtk.Entry();
			this.start_postion_title.CanFocus = true;
			this.start_postion_title.Name = "start_postion_title";
			this.start_postion_title.IsEditable = true;
			this.start_postion_title.InvisibleChar = '●';
			this.hbox1.Add(this.start_postion_title);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.start_postion_title]));
			w3.Position = 1;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Insert end position name/title");
			this.hbox1.Add(this.label3);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.label3]));
			w4.Position = 2;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.stop_position_title = new global::Gtk.Entry();
			this.stop_position_title.CanFocus = true;
			this.stop_position_title.Name = "stop_position_title";
			this.stop_position_title.IsEditable = true;
			this.stop_position_title.InvisibleChar = '●';
			this.hbox1.Add(this.stop_position_title);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.stop_position_title]));
			w5.Position = 3;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Num of changes(optionally)");
			this.hbox1.Add(this.label1);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.label1]));
			w6.Position = 4;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.num_of_changes_entry = new global::Gtk.Entry();
			this.num_of_changes_entry.CanFocus = true;
			this.num_of_changes_entry.Name = "num_of_changes_entry";
			this.num_of_changes_entry.IsEditable = true;
			this.num_of_changes_entry.InvisibleChar = '●';
			this.hbox1.Add(this.num_of_changes_entry);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.num_of_changes_entry]));
			w7.Position = 5;
			// Container child hbox1.Gtk.Box+BoxChild
			this.type_of_search = global::Gtk.ComboBox.NewText();
			this.type_of_search.Name = "type_of_search";
			this.hbox1.Add(this.type_of_search);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.type_of_search]));
			w8.Position = 6;
			w8.Expand = false;
			w8.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.button1 = new global::Gtk.Button();
			this.button1.CanFocus = true;
			this.button1.Name = "button1";
			this.button1.UseUnderline = true;
			this.button1.Label = global::Mono.Unix.Catalog.GetString("Find");
			this.hbox1.Add(this.button1);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.button1]));
			w9.Position = 7;
			w9.Fill = false;
			this.vbox1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Stop\'s way");
			this.hbox3.Add(this.label5);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.label5]));
			w11.Position = 0;
			w11.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label6 = new global::Gtk.Label();
			this.label6.Name = "label6";
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString("Stop\'s title");
			this.hbox3.Add(this.label6);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.label6]));
			w12.Position = 1;
			w12.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label7 = new global::Gtk.Label();
			this.label7.Name = "label7";
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString("Arrive time");
			this.hbox3.Add(this.label7);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.label7]));
			w13.Position = 2;
			w13.Fill = false;
			this.vbox3.Add(this.hbox3);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.hbox3]));
			w14.Position = 0;
			w14.Expand = false;
			w14.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.path_main_container = new global::Gtk.VBox();
			this.path_main_container.Name = "path_main_container";
			this.path_main_container.Spacing = 6;
			this.vbox3.Add(this.path_main_container);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.path_main_container]));
			w15.Position = 1;
			this.vbox1.Add(this.vbox3);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.vbox3]));
			w16.Position = 1;
			w1.Add(this.vbox1);
			this.GtkScrolledWindow.Add(w1);
			this.Add(this.GtkScrolledWindow);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 1080;
			this.DefaultHeight = 300;
			this.Show();
			this.button1.Clicked += new global::System.EventHandler(this.OnButtonFindClickedHanlder);
		}
	}
}