
// This file has been generated by the GUI designer. Do not modify.
namespace KursachAttemp2.View
{
	public partial class AddToExistingWayWindow
	{
		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.VBox vbox8;

		private global::Gtk.HBox hbox5;

		private global::Gtk.Label label13;

		private global::Gtk.Entry way_title_entry;

		private global::Gtk.Label label14;

		private global::Gtk.Entry num_of_stops;

		private global::Gtk.Button start_adding_way_button;

		private global::Gtk.VBox stop_getting_info_container;

		private global::Gtk.Button add_way_button;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget KursachAttemp2.View.AddToExistingWayWindow
			this.Name = "KursachAttemp2.View.AddToExistingWayWindow";
			this.Title = global::Mono.Unix.Catalog.GetString("AddToExistingWayWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child KursachAttemp2.View.AddToExistingWayWindow.Gtk.Container+ContainerChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			global::Gtk.Viewport w1 = new global::Gtk.Viewport();
			w1.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child GtkViewport.Gtk.Container+ContainerChild
			this.vbox8 = new global::Gtk.VBox();
			this.vbox8.Name = "vbox8";
			this.vbox8.Spacing = 6;
			// Container child vbox8.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.label13 = new global::Gtk.Label();
			this.label13.Name = "label13";
			this.label13.LabelProp = global::Mono.Unix.Catalog.GetString("Write way title:");
			this.hbox5.Add(this.label13);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.label13]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.way_title_entry = new global::Gtk.Entry();
			this.way_title_entry.CanFocus = true;
			this.way_title_entry.Name = "way_title_entry";
			this.way_title_entry.IsEditable = true;
			this.way_title_entry.InvisibleChar = '●';
			this.hbox5.Add(this.way_title_entry);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.way_title_entry]));
			w3.Position = 1;
			// Container child hbox5.Gtk.Box+BoxChild
			this.label14 = new global::Gtk.Label();
			this.label14.Name = "label14";
			this.label14.LabelProp = global::Mono.Unix.Catalog.GetString("Write num of stops");
			this.hbox5.Add(this.label14);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.label14]));
			w4.Position = 2;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.num_of_stops = new global::Gtk.Entry();
			this.num_of_stops.CanFocus = true;
			this.num_of_stops.Name = "num_of_stops";
			this.num_of_stops.IsEditable = true;
			this.num_of_stops.InvisibleChar = '●';
			this.hbox5.Add(this.num_of_stops);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.num_of_stops]));
			w5.Position = 3;
			// Container child hbox5.Gtk.Box+BoxChild
			this.start_adding_way_button = new global::Gtk.Button();
			this.start_adding_way_button.CanFocus = true;
			this.start_adding_way_button.Name = "start_adding_way_button";
			this.start_adding_way_button.UseUnderline = true;
			this.start_adding_way_button.Label = global::Mono.Unix.Catalog.GetString("Start adding");
			this.hbox5.Add(this.start_adding_way_button);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.start_adding_way_button]));
			w6.Position = 4;
			w6.Expand = false;
			w6.Fill = false;
			this.vbox8.Add(this.hbox5);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox8[this.hbox5]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox8.Gtk.Box+BoxChild
			this.stop_getting_info_container = new global::Gtk.VBox();
			this.stop_getting_info_container.Name = "stop_getting_info_container";
			this.stop_getting_info_container.Spacing = 6;
			this.vbox8.Add(this.stop_getting_info_container);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox8[this.stop_getting_info_container]));
			w8.Position = 1;
			// Container child vbox8.Gtk.Box+BoxChild
			this.add_way_button = new global::Gtk.Button();
			this.add_way_button.CanFocus = true;
			this.add_way_button.Name = "add_way_button";
			this.add_way_button.UseUnderline = true;
			this.add_way_button.Label = global::Mono.Unix.Catalog.GetString("Add all");
			this.vbox8.Add(this.add_way_button);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox8[this.add_way_button]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			w1.Add(this.vbox8);
			this.GtkScrolledWindow.Add(w1);
			this.Add(this.GtkScrolledWindow);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 680;
			this.DefaultHeight = 300;
			this.Show();
			this.start_adding_way_button.Clicked += new global::System.EventHandler(this.OnStartAddingButtonClicked);
			this.add_way_button.Clicked += new global::System.EventHandler(this.OnAddAllButtonClicked);
		}
	}
}
