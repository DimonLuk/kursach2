
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;

	private global::Gtk.Action FileAction;

	private global::Gtk.Action FileAction1;

	private global::Gtk.Action openAction;

	private global::Gtk.Action newAction;

	private global::Gtk.Action FindPathAction;

	private global::Gtk.VBox vbox5;

	private global::Gtk.MenuBar menubar5;

	private global::Gtk.HBox hbox1;

	private global::Gtk.Entry find_entry;

	private global::Gtk.ComboBox search_category;

	private global::Gtk.Button find_button;

	private global::Gtk.ScrolledWindow GtkScrolledWindow;

	private global::Gtk.VBox way_container;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup("Default");
		this.FileAction = new global::Gtk.Action("FileAction", global::Mono.Unix.Catalog.GetString("File"), null, null);
		this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString("File");
		w1.Add(this.FileAction, null);
		this.FileAction1 = new global::Gtk.Action("FileAction1", global::Mono.Unix.Catalog.GetString("File"), null, null);
		this.FileAction1.ShortLabel = global::Mono.Unix.Catalog.GetString("File");
		w1.Add(this.FileAction1, null);
		this.openAction = new global::Gtk.Action("openAction", global::Mono.Unix.Catalog.GetString("_Open"), null, "gtk-open");
		this.openAction.ShortLabel = global::Mono.Unix.Catalog.GetString("_Open");
		w1.Add(this.openAction, null);
		this.newAction = new global::Gtk.Action("newAction", global::Mono.Unix.Catalog.GetString("New"), null, "gtk-new");
		this.newAction.ShortLabel = global::Mono.Unix.Catalog.GetString("New");
		w1.Add(this.newAction, null);
		this.FindPathAction = new global::Gtk.Action("FindPathAction", global::Mono.Unix.Catalog.GetString("Find path"), null, null);
		this.FindPathAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Find path");
		w1.Add(this.FindPathAction, null);
		this.UIManager.InsertActionGroup(w1, 0);
		this.AddAccelGroup(this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("Finding ways");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox5 = new global::Gtk.VBox();
		this.vbox5.Name = "vbox5";
		this.vbox5.Spacing = 6;
		// Container child vbox5.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString("<ui><menubar name=\'menubar5\'><menu name=\'FileAction1\' action=\'FileAction1\'><menui" +
				"tem name=\'openAction\' action=\'openAction\'/><menuitem name=\'newAction\' action=\'ne" +
				"wAction\'/></menu><menu name=\'FindPathAction\' action=\'FindPathAction\'/></menubar>" +
				"</ui>");
		this.menubar5 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget("/menubar5")));
		this.menubar5.Name = "menubar5";
		this.vbox5.Add(this.menubar5);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.menubar5]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox5.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.find_entry = new global::Gtk.Entry();
		this.find_entry.CanFocus = true;
		this.find_entry.Name = "find_entry";
		this.find_entry.IsEditable = true;
		this.find_entry.InvisibleChar = '●';
		this.hbox1.Add(this.find_entry);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.find_entry]));
		w3.Position = 0;
		// Container child hbox1.Gtk.Box+BoxChild
		this.search_category = global::Gtk.ComboBox.NewText();
		this.search_category.Name = "search_category";
		this.hbox1.Add(this.search_category);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.search_category]));
		w4.Position = 1;
		w4.Expand = false;
		w4.Fill = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.find_button = new global::Gtk.Button();
		this.find_button.CanFocus = true;
		this.find_button.Name = "find_button";
		this.find_button.UseUnderline = true;
		this.find_button.Label = global::Mono.Unix.Catalog.GetString("Find");
		this.hbox1.Add(this.find_button);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.find_button]));
		w5.Position = 2;
		w5.Expand = false;
		w5.Fill = false;
		this.vbox5.Add(this.hbox1);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.hbox1]));
		w6.Position = 1;
		w6.Expand = false;
		w6.Fill = false;
		// Container child vbox5.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		global::Gtk.Viewport w7 = new global::Gtk.Viewport();
		w7.ShadowType = ((global::Gtk.ShadowType)(0));
		// Container child GtkViewport.Gtk.Container+ContainerChild
		this.way_container = new global::Gtk.VBox();
		this.way_container.Name = "way_container";
		this.way_container.Spacing = 6;
		w7.Add(this.way_container);
		this.GtkScrolledWindow.Add(w7);
		this.vbox5.Add(this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.GtkScrolledWindow]));
		w10.Position = 2;
		this.Add(this.vbox5);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 435;
		this.DefaultHeight = 335;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.openAction.Activated += new global::System.EventHandler(this.activated_handler);
		this.newAction.Activated += new global::System.EventHandler(this.OnNewActivatedHandler);
		this.FindPathAction.Activated += new global::System.EventHandler(this.OnFindPathActionActivatedHandler);
		this.find_button.Clicked += new global::System.EventHandler(this.FindStopOrWayClickedHandler);
	}
}
